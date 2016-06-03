using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanSatGroundStation
{
    public delegate void ImageFileUpdateHandler(Image image);


    class BloomFilter
    {
        private byte[] filter;
        private int dataSize;

        public BloomFilter(int size)
        {
            dataSize = size;
            int filterSize = (int)(Math.Round(Convert.ToDouble(size) / 8));
            filter = new byte[filterSize];
            for(int i=0; i < filter.Length; i++)
            {
                filter[i] = 0x00;
            }
        }

        private int[] getIndexesFromPosition(int pos)
        {
            if (pos > dataSize)
            {
                Debug.WriteLine("Bloom filter error: pos=" + pos.ToString() + " dataSize=" + dataSize);
                return null;
            }

            int byteIndex = pos / 8;
            int bitPos = pos % 8;

            return new int[2]{byteIndex, bitPos};
        }

        public void set(int pos)
        {
            int[] indexes = getIndexesFromPosition(pos);
            if(indexes == null)
            {
                return;
            }

            int byteIndex = indexes[0];
            int bitPos = indexes[1];

            filter[byteIndex] |= ((byte)(0x01 << bitPos));

        }

        public void unset(int pos)
        {
            int[] indexes = getIndexesFromPosition(pos);
            if (indexes == null)
            {
                return;
            }

            int byteIndex = indexes[0];
            int bitPos = indexes[1];

            filter[byteIndex] &= ((byte)(~(0x01 << bitPos)));
        }

        public Boolean isSet(int pos)
        {
            int[] indexes = getIndexesFromPosition(pos);
            if (indexes == null)
            {
                return false;
            }

            int byteIndex = indexes[0];
            int bitPos = indexes[1];

            if((filter[byteIndex] & (byte)(0x01 << bitPos)) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public byte[] getFilter()
        {
            return filter;
        }
    }


    class ImageAcknowledgeHandler
    {        
        private int IMAGE_TYPICAL_NUM_PACKETS = 632;
        private List<BloomFilter> retransmitFilters = new List<BloomFilter>();
        
        public void addAcknowledgeFor(int imageChunkOffset)
        {
            int packetIndex = imageChunkOffset / 80;
            int filterIndex = packetIndex / IMAGE_TYPICAL_NUM_PACKETS;
            BloomFilter filter;
            if (filterIndex >= retransmitFilters.Count)
            {
                filter = new BloomFilter(IMAGE_TYPICAL_NUM_PACKETS);
                retransmitFilters.Add(filter);
            }
            else
            {
                filter = retransmitFilters.ElementAt(filterIndex);
            }

            filter.set(packetIndex);     
        }

        public List<byte[]> getAcknowledgeBytes()
        {
            List <byte[]> requests = new List<byte[]>();

            for(int i=0; i < retransmitFilters.Count; i++)
            {
                List < byte > requestBytes= new List<byte>();
                //The first byte identifies image ack packet
                requestBytes.Add(0xB1);
                //The second byte of a request is identifier for the filter
                requestBytes.Add((byte)i);
                byte[] filterBytes = retransmitFilters.ElementAt(i).getFilter();
                requestBytes.AddRange(filterBytes);
                requests.Add(requestBytes.ToArray());
            }

            return requests;
        }
    }

    class ImageReceiver
    {

        private static volatile ImageReceiver imageReceiver;

        private static String imageDirPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private static int MIN_IMAGE_BYTES_TO_WRITE_FILE = 5000;

        private static int IMAGE_RECIEVE_MAX_TIMEOUT = 25;

        private int lastReceivedChunkOffset = 0;

        public static event ImageFileUpdateHandler imageFileUpdateHandler;

        private List<byte> receivedImageDataBytes = new List<byte>();

        private static ImageAcknowledgeHandler imageAcknowledgeHandler = new ImageAcknowledgeHandler();

        private static int receivedImagesCount = 0;

        private static FileStream imageFileStream;

        private Boolean isRecievingImage = false;

        private static int imageRecievingSeconds = 0;

        private static Timer imageRecieveTimer = new Timer();       

        public static ImageReceiver Instance
        {
            get
            {                
                if (imageReceiver == null)
                {
                    imageReceiver = new ImageReceiver();
                    String imagePath = imageDirPath + "\\" + "image_" + DateTime.Now.ToString("HHmmsstt") + ".jpg";
                    imageFileStream = new FileStream(imagePath, FileMode.Create);

                    imageRecieveTimer = new Timer();
                    imageRecieveTimer.Tick += new EventHandler(Timer_Tick);
                    imageRecieveTimer.Interval = 1000;
                }
                return imageReceiver;
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            imageRecievingSeconds += 1;
            if(imageRecievingSeconds == IMAGE_RECIEVE_MAX_TIMEOUT)
            {  
                sendImageAcknowledge();
            }
        }

        public static void sendImageAcknowledge()
        {
            imageRecieveTimer.Stop();
            imageRecievingSeconds = 0;

            List<byte[]> imageAcks = imageAcknowledgeHandler.getAcknowledgeBytes();

            Debug.WriteLine("Sending image ack .......... " + imageAcks.Count);

            foreach(byte[] bytes in imageAcks)
            {
                XBeeOutgoingPacket acknowledgePacket = new XBeeOutgoingPacket();
                acknowledgePacket.PacketData = bytes;
                Debug.WriteLine("Length: " + bytes.Length.ToString() +  " Image ack bytes sent: " + BitConverter.ToString(acknowledgePacket.toByteArray()));
                XBee.Instance.sendOutGoingPacket(acknowledgePacket);
            }
        }

        public void receiveImagePacket(ImagePacket imagePacket)
        {
            if(!isRecievingImage)
            {
                isRecievingImage = true;
                imageRecieveTimer.Start();
            }

            imageAcknowledgeHandler.addAcknowledgeFor(imagePacket.ImageChunkOffset);

            if(imagePacket.ImageChunkOffset == 0)
            {
                sendImageAcknowledge();
            }

           /*receivedImageDataBytes.AddRange(imagePacket.ImageDataBytes);

            if (imagePacket.ImageChunkOffset != 0)
            {
                //Check if we need to update the image file
                int imageChunkOffsetDifference = imagePacket.ImageChunkOffset - lastReceivedChunkOffset;
                if (imageChunkOffsetDifference > MIN_IMAGE_BYTES_TO_WRITE_FILE)
                {
                    //updateImageFile();                    
                }
            }
            else
            {
                //We have received the last image chunk, update the image file and update the receiver state
                updateImageFile();
               
                receivedImagesCount++;
            }

            //Update the offset
            lastReceivedChunkOffset = imagePacket.ImageChunkOffset;  */
        }

        public void updateImageFile()
        {
            BinaryWriter binaryWritter = new BinaryWriter(imageFileStream);
            // This method is called when the serial port recieves data 
            try
            {
                using (binaryWritter)
                {
                    binaryWritter.Write(receivedImageDataBytes.ToArray());
                }

                receivedImageDataBytes.Clear();
                String currentImagePath = imageFileStream.Name;
                imageFileStream.Close();

                Image image = Image.FromFile(currentImagePath);
                imageFileUpdateHandler(image);
                
                String imagePath = imageDirPath + "\\" + "image_" + DateTime.Now.ToString("HHmmsstt") + ".jpg";
                imageFileStream = new FileStream(imagePath, FileMode.Create);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Problem writing image file: \n" + e.Message);
            }
            finally
            {
                //s1.Close();
            }

        }

    }
}
