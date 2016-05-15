using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;
namespace CanSatGroundStation
{
    // Delegate methods to be notified for events
    public delegate void ValidPacketAvailableHandler(TelemetryPacket packet);
    public delegate void XBeeIncomingPacketAvailable(XBeeIncomingPacket packet);
    public delegate void RawPacketAvailableHandler(String data);


    public class XBeeIncomingPacket
    {
        private byte[] packetLengthBytes = new byte[2];
        private byte frameType;
        private byte[] packetData;

        public byte FrameType
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
        }

        public void verifyChecksum(byte checksumByte)
        {
            //TODO:
        }
       
    }


    class XBee
    {
        private static volatile XBee xbee;
        private static object syncRoot = new Object();        
        private static SerialPort serialPort;

        public static byte XBEE_PACKET_START_DELIMITER = 0x7E;
        private static int INCOMING_PACKET_BUFFER_SIZE = 200;

        public static event RawPacketAvailableHandler rawPacketAvailable;
        public static event ValidPacketAvailableHandler validPacketAvailable;
        public static event XBeeIncomingPacketAvailable xbeeIncomingPacketAvaialbleHandler;         

        private static byte[] incomingPacketBuffer = new byte[INCOMING_PACKET_BUFFER_SIZE];

        private static bool xbeeAPIFrameParsingStarted = false;
        private static int incomingPacketFrameIndex = 0;
        private static XBeeIncomingPacket incomingPacket;
 
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

        private static void OnRawPacketAvailable(String data)
        {
            rawPacketAvailable?.Invoke(data);
        }

        public static void IncomingByteHandler(byte incomingByte)
        {
            if (xbeeAPIFrameParsingStarted)
            {
                if (incomingPacketFrameIndex > 0 && incomingPacketFrameIndex <= 2)
                {
                    //Byte 1 and 2 are length bytes
                    incomingPacket.setPacketLengthByte(incomingByte, incomingPacketFrameIndex - 1);
                }
                else if(incomingPacketFrameIndex == 3)
                {
                    incomingPacket.FrameType = incomingByte;
                }
                else if((incomingPacketFrameIndex - 3) <= incomingPacket.PacketDataLength)
                {
                    incomingPacket.setPacketDataByte(incomingByte, incomingPacketFrameIndex - 4);
                }
                else
                {
                    //Expect checksum byte
                    incomingPacket.verifyChecksum(incomingByte);
                    xbeeIncomingPacketAvaialbleHandler(incomingPacket);

                    incomingPacketFrameIndex = 0;
                    xbeeAPIFrameParsingStarted = false;
                }

            }
            else if (incomingByte == XBEE_PACKET_START_DELIMITER)
            {
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

        private static void OnValidPacketAvaialbe(TelemetryPacket packet)
        {
            validPacketAvailable?.Invoke(packet);
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
