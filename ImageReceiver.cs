using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CanSatGroundStation
{
    public delegate void ImageFileUpdateHandler(Image image);

    class ImageReceiver
    {

        private static volatile ImageReceiver imageReceiver;

        private static String imageDirPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private static int MIN_IMAGE_BYTES_TO_WRITE_FILE = 5000;

        private int lastReceivedChunkOffset = 0;

        public static event ImageFileUpdateHandler imageFileUpdateHandler;

        private List<byte> receivedImageDataBytes = new List<byte>();

        private static int receivedImagesCount = 0;

        private static FileStream imageFileStream;

        public static ImageReceiver Instance
        {
            get
            {                
                if (imageReceiver == null)
                {
                    imageReceiver = new ImageReceiver();
                    String imagePath = imageDirPath + "\\" + "image_" + DateTime.Now.ToString("HHmmsstt") + ".jpg";
                    imageFileStream = new FileStream(imagePath, FileMode.Create);
                }
                return imageReceiver;
            }
        }


        public void receiveImagePacket(ImagePacket imagePacket)
        {
           receivedImageDataBytes.AddRange(imagePacket.ImageDataBytes);

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
            lastReceivedChunkOffset = imagePacket.ImageChunkOffset;  
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
