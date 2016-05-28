using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;
namespace CanSatGroundStation
{
    // Delegate methods to be notified for events

    public delegate void XBeeIncomingPacketAvailableHandler(XBeeIncomingPacket packet);
    public delegate void XBeeRawByteAvailableHandler(byte rawByte);

    public class XBeeIncomingPacket
    {

        private byte[] packetLengthBytes = new byte[2];
        private XBee.XBEE_FRAME_TYPE frameType;
        private byte[] packetData;

        public XBee.XBEE_FRAME_TYPE FrameType
        {
            get
            {
                return frameType;
            }
            set
            {
                frameType = value;
            }
        }

        public byte[] PacketData
        {
            get
            {
                return packetData;
            }
        }

        public int PacketDataLength
        {
            get
            {
                return (packetLengthBytes[1] | packetLengthBytes[0] << 8) - 1; //Excludes the frame type byte
            }
        }

        public void setPacketLengthByte(byte value, int bytePos)
        {
            if(bytePos < packetLengthBytes.Length)
            {
                packetLengthBytes[bytePos] = value;
                if(bytePos == 1)
                {
                    // We have all length bytes. We can initialize the packetData array
                    packetData = new byte[PacketDataLength];
                }
            }
        }

        public void setPacketDataByte(byte byteValue, int bytePos)
        {
            if (packetData != null && bytePos < packetData.Length)
            {
                packetData[bytePos] = byteValue;
            }
            else
            {
                Debug.WriteLine("Error setting packet data byte: bytePos: " + 
                    bytePos + " is out of bound. packetData length:  " + packetData.Length);
            }
        }

        public void verifyChecksum(byte checksumByte)
        {
            //TODO:
        }
       

        public static byte[] createIncomingRecievePacket(byte[] packetData)
        {
            byte[] sourceAddress64Bit = new byte[8];
            byte[] sourceAddress16Bit = new byte[2];
            byte receiveOption = 0x41;

            return createIncomingRecievePacket(packetData, sourceAddress64Bit , sourceAddress16Bit, receiveOption);
        }

        public static byte[] createIncomingRecievePacket(byte[] packetData, byte[] sourceAddress64Bit, byte[] sourceAddress16Bit, byte receiveOption)
        {
            int dataLengthWithSourceAddressAndOption = packetData.Length + sourceAddress64Bit.Length + sourceAddress16Bit.Length + 1;
            byte[] recievePacket = new byte[5 + dataLengthWithSourceAddressAndOption]; // 1 byte start delimiter + 2 byte length + 1 byte frame type + 1 byte checksum = 5

            int writeOffset = 0;

            //Start delimiter
            recievePacket[writeOffset] =  XBee.XBEE_PACKET_START_DELIMITER;
            writeOffset ++;

            //Length bytes between, length field and checksum
            int length = dataLengthWithSourceAddressAndOption + 1; // Include the frame type;
            recievePacket[writeOffset] = (byte)(length >> 8); //MSB
            writeOffset ++;
            recievePacket[writeOffset] = (byte)(length & 0x00FF); //LSB
            writeOffset ++;

            //Frame type
            recievePacket[writeOffset] = XBee.RECIEVE_PACKET_FRAME_TYPE;
            writeOffset++;

            //TODO:Next 8 bytes are 64 bit source address, leave empty
            writeOffset += sourceAddress64Bit.Length;

            //TODO:Next 2 bytes are 16 bit source address, leave empty
            writeOffset += sourceAddress16Bit.Length;

            //Next 1 byte is recieve option
            recievePacket[writeOffset] = receiveOption;
            writeOffset++;

            for(int i=0;  i < packetData.Length; i++)
            {
                recievePacket[i + writeOffset] = packetData[i];
            }

            //TODO: Leave checksum byte empty 

            return recievePacket;
        }

        public static XBee.XBEE_FRAME_TYPE toFrameType(byte frameTypeByte)
        {
            switch(frameTypeByte)
            {
                case XBee.RECIEVE_PACKET_FRAME_TYPE:
                    return XBee.XBEE_FRAME_TYPE.RECIEVE_PACKET;
                case XBee.TRANSMIT_STATUS_FRAME_TYPE:
                    return XBee.XBEE_FRAME_TYPE.TRANSMIT_STATUS;
                default:
                    return XBee.XBEE_FRAME_TYPE.UNKNOWN_FRAME_TYPE;
            }
        }

    }


    public class XBeeOutgoingPacket
    {

        private byte startDelimiter = XBee.XBEE_PACKET_START_DELIMITER;
        private byte[] packetLengthBytes = new byte[2];
        private XBee.XBEE_FRAME_TYPE frameType;
        private byte frameId;
        byte[] destAddress64Bit = new byte[8];
        byte[] destAddress16Bit = new byte[2];
        byte broadcastRadius;
        byte options;
        byte[] packetData = new byte[1];
        byte checksum;

        public XBeeOutgoingPacket()
        {
            //TODO: Fix hardcoded values
            frameType = XBee.XBEE_FRAME_TYPE.TRANSMIT_REQUEST;
            frameId = 0x01;
            destAddress64Bit = new byte[] {0x00, 0x13, 0xA2, 0x00, 0x41, 0x47, 0x13, 0x7C};
            destAddress16Bit = new byte[] {0xFF, 0xFE};
            broadcastRadius = 0x00;
            options = 0x00;
        }

        public byte[] PacketData
        {
            get
            {
                return packetData;
            }
            set
            {
                packetData = value;
                updatePacketLength();
                updateChecksum();                
            }
        }

        private void updatePacketLength()
        {
            int lengthWithData = 14 + packetData.Length;
            packetLengthBytes[0] = (byte)((lengthWithData & 0xFF00) >> 8);
            packetLengthBytes[1] = (byte)(lengthWithData & 0x00FF);
            
        }

        private void updateChecksum()
        {
            int sum = 0;

            sum += frameId;
            sum += (int)frameType;

            foreach(byte b in destAddress64Bit)
            {
                sum += (int)b;
            }

            foreach(byte b in destAddress16Bit)
            {
                sum += (int)b;
            }

            sum += broadcastRadius;
            sum += options;

            foreach(byte b in PacketData)
            {
                sum += b;
            }

            sum &= 0xFF;
            checksum = (byte)(0xFF - sum);
        }

        public byte[] toByteArray()
        {
            List<byte> outGoingBytesList = new List<byte>();

            //Construct the outgoing packet

            outGoingBytesList.Add(startDelimiter);

            outGoingBytesList.AddRange(packetLengthBytes);

            outGoingBytesList.Add((byte)frameType);

            outGoingBytesList.Add(frameId);

            outGoingBytesList.AddRange(destAddress64Bit);

            outGoingBytesList.AddRange(destAddress16Bit);

            outGoingBytesList.Add(broadcastRadius);

            outGoingBytesList.Add(options);

            outGoingBytesList.AddRange(PacketData);

            outGoingBytesList.Add(checksum);

            return outGoingBytesList.ToArray();
        }

    }

    public class XBee
    {
        private static volatile XBee xbee;
        private static object syncRoot = new Object();        
        private static SerialPort serialPort;

        public const byte XBEE_PACKET_START_DELIMITER = 0x7E;
        private static int INCOMING_PACKET_BUFFER_SIZE = 200;

        public static event XBeeIncomingPacketAvailableHandler xbeeIncomingPacketAvaialbleHandler;
        public static event XBeeRawByteAvailableHandler xbeeRawByteAvaialbleHandler;

        private static byte[] incomingPacketBuffer = new byte[INCOMING_PACKET_BUFFER_SIZE];

        private static bool xbeeAPIFrameParsingStarted = false;
        private static int incomingPacketFrameIndex = 0;
        private static XBeeIncomingPacket incomingPacket;

        public const byte RECIEVE_PACKET_FRAME_TYPE = 0x90;
        public const byte TRANSMIT_STATUS_FRAME_TYPE = 0x8B;
        public const byte TRANSMIT_REQUEST_FRAME_TYPE = 0x10;

        public enum XBEE_FRAME_TYPE
        {
            RECIEVE_PACKET = RECIEVE_PACKET_FRAME_TYPE,
            TRANSMIT_STATUS = TRANSMIT_STATUS_FRAME_TYPE,
            TRANSMIT_REQUEST = TRANSMIT_REQUEST_FRAME_TYPE,
            UNKNOWN_FRAME_TYPE
        }


        private XBee(){}

        public static XBee Instance
        {
            get
            {
                // use a lock for additional thread safety
                lock (syncRoot)
                {
                    if (xbee == null)
                    {
                        xbee = new XBee();                        
                        serialPort = new SerialPort();
                        serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceivedHandler);
                    }
                }
                return xbee;
            }
        }        

        public static void IncomingByteHandler(byte incomingByte)
        {
            xbeeRawByteAvaialbleHandler?.Invoke(incomingByte);

            if (xbeeAPIFrameParsingStarted)
            {
                if (incomingPacketFrameIndex > 0 && incomingPacketFrameIndex <= 2)
                {
                    //Byte 1 and 2 are length bytes
                    //Debug.WriteLine("Parsing Length byte: " + incomingByte.ToString("X2"));
                    incomingPacket.setPacketLengthByte(incomingByte, incomingPacketFrameIndex - 1);
                }
                else if(incomingPacketFrameIndex == 3)
                {
                    //Debug.WriteLine("Parsing Frame Type byte: " + incomingByte.ToString("X2"));
                    incomingPacket.FrameType = XBeeIncomingPacket.toFrameType(incomingByte);
                }
                else if((incomingPacketFrameIndex - 4) < incomingPacket.PacketDataLength)
                {
                    //Debug.WriteLine("Parsing Packet Data Byte: " + incomingByte.ToString("X2"));
                    incomingPacket.setPacketDataByte(incomingByte, incomingPacketFrameIndex - 4);
                }
                else
                {
                    //Expect checksum byte
                    //Debug.WriteLine("Parsing Checksum Byte: " + incomingByte.ToString("X2"));
                    incomingPacket.verifyChecksum(incomingByte);


                    xbeeIncomingPacketAvaialbleHandler?.Invoke(incomingPacket);

                    incomingPacketFrameIndex = 0;
                    xbeeAPIFrameParsingStarted = false;
                }

                incomingPacketFrameIndex++;

            }
            else if (incomingByte == XBEE_PACKET_START_DELIMITER)
            {
                //Debug.WriteLine("Parsing Start Delimiter Byte: " + incomingByte.ToString("X2"));
                xbeeAPIFrameParsingStarted = true;
                incomingPacket = new XBeeIncomingPacket();
                incomingPacketFrameIndex = 1;
            }
        }
     
        public static void SerialPortDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                return;
            }

            int numberOfBytesToRead = serialPort.BytesToRead;

            while(numberOfBytesToRead > 0)
            {
                byte incomingByte = (byte)serialPort.ReadByte();
                IncomingByteHandler(incomingByte);
                numberOfBytesToRead --;
            }
        }

        public void sendOutGoingPacket(XBeeOutgoingPacket packet)
        {
            if(serialPort.IsOpen)
            {
                byte[] bytesToSend = packet.toByteArray();
                serialPort.Write(bytesToSend, 0, bytesToSend.Length);
            }
            else
            {
                Debug.WriteLine("XBee can't send outgoing packet, serial port is not open. ");
            }
        }

        public void closeSerialPort()
        {
            serialPort.Close();
        }

        public void openSerialPort(String name, int baud)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.PortName = name;
                serialPort.BaudRate = baud;
                serialPort.Open();
            }
        }

        public bool serialPortIsOPen()
        {
            return serialPort.IsOpen;
        }

    }
}
