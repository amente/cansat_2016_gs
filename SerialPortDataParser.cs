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
    public delegate void RawPacketAvailableHandler(String data);
    public delegate void DataRecieveTimoutHandler();

    class SerialPortDataParser
    {
        private static volatile SerialPortDataParser serialParser;
        private static object syncRoot = new Object();        
        private static SerialPort serialPort;

        private static byte XBEE_PACKET_START_DELIMITER = 0x7E;
        private static int INCOMING_PACKET_BUFFER_SIZE = 200;

        public static event RawPacketAvailableHandler rawPacketAvailable;
        public static event ValidPacketAvailableHandler validPacketAvailable;
        public static event DataRecieveTimoutHandler dataRecieveTimeout;             

        private static StringBuilder validBuffer;
        private static StringBuilder rawBuffer;

        private static byte[] incomingPacketBuffer = new byte[INCOMING_PACKET_BUFFER_SIZE];

        private static Stopwatch watchdog;

        private static bool xbeeAPIFrameParsingStarted = false;
        private static int incomingPacketFrameIndex = 0;
        private static byte[] incomingPacketLengthBytes = new byte[2];
 
        private SerialPortDataParser(){}

        public static SerialPortDataParser Instance
        {
            get
            {
                // use a lock for additional thread safety
                lock (syncRoot)
                {
                    if (serialParser == null)
                    {
                        serialParser = new SerialPortDataParser();                        
                        serialPort = new SerialPort();
                        validBuffer = new StringBuilder();
                        rawBuffer = new StringBuilder();
                        serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    }
                }
                return serialParser;
            }
        }


        private static void OnRawPacketAvailable(String data)
        {
            rawPacketAvailable?.Invoke(data);
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                return;
            }

            int numberOfBytesToRead = serialPort.BytesToRead;

            while(numberOfBytesToRead > 0)
            {
                byte incomingByte = (byte)serialPort.ReadByte();

                if(xbeeAPIFrameParsingStarted)
                {
                    if(incomingPacketFrameIndex > 0 && incomingPacketFrameIndex <=2)
                    {
                        //Byte 1 and 2 are length bytes

                    }

                }
                else if(incomingByte == XBEE_PACKET_START_DELIMITER)
                {
                    xbeeAPIFrameParsingStarted = true;
                    incomingPacketFrameIndex = 1;
                }

                numberOfBytesToRead --;
            }
        }

        private static void OnValidPacketAvaialbe(TelemetryPacket packet)
        {
            validPacketAvailable?.Invoke(packet);
        }

        // notifies listeners when valid packet is parsed from the API frame
        private static void parse(String data)
        {

            int numDataPackets = (data.Length - TelemetryPacket.API_FRAME_DATA_OFFSET)/TelemetryPacket.PACKET_DATA_SIZE;

            for (int i = 0; i < numDataPackets; i++)
            {                
                String telemetry = data.Substring(TelemetryPacket.API_FRAME_DATA_OFFSET + i * TelemetryPacket.PACKET_DATA_SIZE, TelemetryPacket.PACKET_DATA_SIZE);

                Console.WriteLine("Telemetry: " + telemetry);
                // First data validation, check team id
                if (!telemetry.Substring(0, 4).Equals(TelemetryPacket.TEAM_ID))
                {
                    //Not a valid team id
                    return;
                }

                OnValidPacketAvaialbe(new TelemetryPacket(telemetry));
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
