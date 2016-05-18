using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanSatGroundStation
{
    public delegate void TelemetryPacketAvailableHandler(TelemetryPacket telemetryPacket);
    public delegate void ImagePacketAvailableHandler(ImagePacket imagePacket);

    public class Packet
    {
        private byte teamIdHighByte;
        private byte teamIdLowByte;

        private int missionTimeHour;
        private int missionTimeMin;
        private int missionTimeSec;
        private int missionTime100thOfSec;


        public byte TeamIdHighByte
        {
            get
            {
                return teamIdHighByte;
            }
            set
            {
                teamIdHighByte = value;
            }
        }
        
        public byte TeamIdLowByte
        {
            get
            {
                return teamIdLowByte;
            }
            set
            {
                teamIdLowByte = value;
            }
        }

        public int MissionTimeHour
        {
            get
            {
                return missionTimeHour;
            }

            set
            {
                missionTimeHour = value;
            }
        }

        public int MissionTimeMin
        {
            get
            {
                return missionTimeMin;
            }

            set
            {
                missionTimeMin = value;
            }
        }

        public int MissionTimeSec
        {
            get
            {
                return missionTimeSec;
            }

            set
            {
                missionTimeSec = value;
            }
        }

        public int MissionTime100thOfSec
        {
            get
            {
                return missionTime100thOfSec;
            }

            set
            {
                missionTime100thOfSec = value;
            }
        }

        public void updateWithPacket(Packet packet)
        {
            this.TeamIdHighByte = packet.TeamIdHighByte;
            this.TeamIdLowByte = packet.TeamIdLowByte;
            this.MissionTimeHour = packet.MissionTimeHour;
            this.MissionTimeMin = packet.MissionTimeMin;
            this.MissionTimeSec = packet.MissionTimeSec;
            this.MissionTime100thOfSec = packet.MissionTime100thOfSec;
        }
    }


    public class TelemetryPacket : Packet
    {
       
        private int packetCount;
        private float altitudeInMeters;
        private float pressureInPascals;
        private float airspeedInMetersPerSec;
        private float temperatureInCelcius;
        private double gpsLatitude;
        private double gpsLongitude;
        private float gpsAltitude;
        private int gpsSatNumber;
        private float gpsSpeedInMetersPerSec;

        public int PacketCount
        {
            get
            {
                return packetCount;
            }

            set
            {
                packetCount = value;
            }
        }

        public float AltitudeInMeters
        {
            get
            {
                return altitudeInMeters;
            }

            set
            {
                altitudeInMeters = value;
            }
        }

        public float PressureInPascals
        {
            get
            {
                return pressureInPascals;
            }

            set
            {
                pressureInPascals = value;
            }
        }

        public float AirspeedInMetersPerSec
        {
            get
            {
                return airspeedInMetersPerSec;
            }

            set
            {
                airspeedInMetersPerSec = value;
            }
        }

        public float TemperatureInCelcius
        {
            get
            {
                return temperatureInCelcius;
            }

            set
            {
                temperatureInCelcius = value;
            }
        }

        public double GpsLatitude
        {
            get
            {
                return gpsLatitude;
            }

            set
            {
                gpsLatitude = value;
            }
        }

        public double GpsLongitude
        {
            get
            {
                return gpsLongitude;
            }

            set
            {
                gpsLongitude = value;
            }
        }

        public float GpsAltitude
        {
            get
            {
                return gpsAltitude;
            }

            set
            {
                gpsAltitude = value;
            }
        }

        public int GpsSatNumber
        {
            get
            {
                return gpsSatNumber;
            }

            set
            {
                gpsSatNumber = value;
            }
        }

        public float GpsSpeedInMetersPerSec
        {
            get
            {
                return gpsSpeedInMetersPerSec;
            }

            set
            {
                gpsSpeedInMetersPerSec = value;
            }
        }

        public void updateWithBinaryData(byte[] telemetryDataBinary)
        {
            //Convert the binary data to Csv Ascii string
            String telemetryCsvString = Encoding.ASCII.GetString(telemetryDataBinary);
            updateWithCsvData(telemetryCsvString);
        }

        public void updateWithCsvData(String csvString)
        {
            /* <PACKET COUNT> (int) ,<ALT SENSOR> (float .x), <PRESSURE>(float .xx),<SPEED>(float .xx), <TEMP>(float .x),<VOLTAGE> (float .x),
    * <GPS LATITUDE>(double .xxxxxx) ,<GPSLONGITUDE> (double .xxxxxx) ,<GPS ALTITUDE> (flaot .x),<GPS SAT NUM>(int),<GPS SPEED>(float .xx)*/

            int numberOfTelemetryValues = 11;

            String[] telemetryValues = csvString.Trim().Split(',');
            if(telemetryValues.Length != numberOfTelemetryValues)
            {
                //TODO:
                System.Diagnostics.Debug.WriteLine("Telemetry packet number of values is invalid: expected: "
                    + numberOfTelemetryValues + " found: " + telemetryValues.Length
                    + " csvString: " + csvString);
                return;
            }


            int packetCount = 0;
            if(int.TryParse(telemetryValues[0], out packetCount))
            {
                this.PacketCount = packetCount;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Packet count value: " + telemetryValues[0]);
            }

            


        }

        public String toString()
        {
            //TODO:
            return "";
        }
    }

    public class ImagePacket: Packet
    {

    }

    class PacketParser
    {
        private static volatile PacketParser packetParserInstance;
        public const byte TEAM_ID_HIGH_BYTE = 0x68;
        public const byte TEAM_ID_LOW_BYTE = 0x25;

        public const byte TELEMETRY_PACKET_TYPE = 0xE0;
        public const byte IMAGE_PACKET_TYPE = 0xE1;

        public const int RECIEVE_PACKET_DATA_OFFSET = 11;

        public static event TelemetryPacketAvailableHandler telemetryPacketAvailableHandler;
        public static event ImagePacketAvailableHandler imagePacketAvailableHandler;

        /*Includes 8byte 64 bitsource address +  2 byte 16 bit source address +
        1 byte recieve options + 2 bytes team ID + 4 Bytes mission time + 1 Byte Packet Type = 18 */
        public const int PACKET_PARSER_MIN_RECIEVE_PACKET_LENGTH = 18; 

        public static PacketParser Instance
        {
            get
            {
                
               if (packetParserInstance == null)
               {
                   packetParserInstance = new PacketParser();                        
               }

                return packetParserInstance;
            }
        }


        public void parse(XBeeIncomingPacket incomingPacket)
        {
            byte[] packetDataArray = incomingPacket.PacketData;

            //Conver the packet data array to a stack of bytes
            Stack<byte> packetDataStack = new Stack<byte>();
            foreach(byte b in packetDataArray.Reverse())
            {
                packetDataStack.Push(b);
            }
            
            if(incomingPacket.FrameType == XBeeIncomingPacket.XBEE_FRAME_TYPE.RECIEVE_PACKET)
            {
                if(packetDataStack.Count < PACKET_PARSER_MIN_RECIEVE_PACKET_LENGTH)
                {
                    System.Diagnostics.Debug.WriteLine("Incoming packet data is less than minimum recive packet length: Length: " 
                        + packetDataStack.Count + " PacketData: " 
                        + BitConverter.ToString(packetDataArray));
                    return;
                }

                //Parsing has to be done in the correct order
                //Each parse function removes the data that is parsed from the stack

                //NOTE: We don't care about the source address and option bytes
                //First parse the 64bit source address 
                byte[] sourceAddress64Bit = parse64BitSourceAddress(packetDataStack);

                //Then parse the 16bit source address
                byte[] sourceAddress16Bit = parse16BitSourceAddress(packetDataStack);

                //Then parse the option byte
                byte optionByte = parseOptionByte(packetDataStack);


                Packet parsedPacket = new Packet();

                // Parse team id bytes, expects 2 bytes 
                byte[] teamIdBytes = parseTeamIdBytes(packetDataStack);


                parsedPacket.TeamIdHighByte = teamIdBytes[0];
                parsedPacket.TeamIdLowByte = teamIdBytes[1];
               
                //Check if the team Id is correct
                if (parsedPacket.TeamIdHighByte == TEAM_ID_HIGH_BYTE && parsedPacket.TeamIdLowByte == TEAM_ID_LOW_BYTE)
                {
                    // Continue
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Invalid team id recieve in packet data: " +
                        "TeamIDHighByte: " + parsedPacket.TeamIdHighByte.ToString("X2") +
                        "TeamIDLowByte: " + parsedPacket.TeamIdLowByte.ToString("X2") +
                        " PacketData: " +
                        BitConverter.ToString(packetDataArray));
                    return;
                }


                // Parse the mission time bytes, expects 4 bytes
                byte[] missionTimeBytes = parseMissionTimeBytes(packetDataStack);
                parsedPacket.MissionTimeHour = missionTimeBytes[0];
                parsedPacket.MissionTimeMin = missionTimeBytes[1];
                parsedPacket.MissionTimeSec = missionTimeBytes[2];
                parsedPacket.MissionTime100thOfSec = missionTimeBytes[3];
               

                //Get the packet type from the packet Data
                byte packetType = parsePacketTypeByte(packetDataStack);
  
                //From now on parse based on the packet type
                switch(packetType)
                {
                    case TELEMETRY_PACKET_TYPE:
                        TelemetryPacket newTelemetryPacket  = parseTelemetryPacket(packetDataStack);
                        newTelemetryPacket.updateWithPacket(parsedPacket);
                        telemetryPacketAvailableHandler?.Invoke(newTelemetryPacket);
                        break;
                    case IMAGE_PACKET_TYPE:
                        ImagePacket newImagePacket = parseImagePacket(packetDataStack);
                        newImagePacket.updateWithPacket(parsedPacket);
                        imagePacketAvailableHandler?.Invoke(newImagePacket);
                        break;

                    default:
                        System.Diagnostics.Debug.WriteLine("Uknown Packet Type: " + packetType +
                             " PacketData: " +
                        BitConverter.ToString(packetDataArray));
                        break;
                }            
            }
        }

        private ImagePacket parseImagePacket(Stack<byte> packetDataStack)
        {
            ImagePacket imagePacket = new ImagePacket();
            //TODO: Actual parsing

            return imagePacket;
        }

        private TelemetryPacket parseTelemetryPacket(Stack<byte> packetDataStack)
        {
            TelemetryPacket telemetryPacket = new TelemetryPacket();
            telemetryPacket.updateWithBinaryData(packetDataStack.ToArray());

            return telemetryPacket;
        }

        private byte parsePacketTypeByte(Stack<byte> packetDataStack)
        {
            return packetDataStack.Pop();
        }

        private byte[] parseMissionTimeBytes(Stack<byte> packetDataStack)
        {
            return popNBytesFromStack(packetDataStack, 4);
        }

        private byte[] parseTeamIdBytes(Stack<byte> packetDataStack)
        {
            return popNBytesFromStack(packetDataStack, 2);
        }

        private byte parseOptionByte(Stack<byte> packetDataStack)
        {
            return packetDataStack.Pop();
        }

        private byte[] parse16BitSourceAddress(Stack<byte> packetDataStack)
        {
            return popNBytesFromStack(packetDataStack, 2);
        }

        private byte[] parse64BitSourceAddress(Stack<byte> packetDataStack)
        {
            return popNBytesFromStack(packetDataStack, 8);
        }

        private byte[] popNBytesFromStack(Stack<byte> stack, int n)
        {
            byte[] returnedBytes = new byte[n];
            for (int i = 0; i < returnedBytes.Length; i++)
            {
                returnedBytes[i] = stack.Pop();
            }
            return returnedBytes;
        }
    }
}
