using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private byte packetType;


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

        public byte PacketType
        {
            get
            {
                return packetType;
            }

            set
            {
                packetType = value;
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
            this.packetType = packet.PacketType;
        }

        public byte[] getPacketHeader()
        {
            List<byte> headerBytesList = new List<byte>();

            headerBytesList.Add(TeamIdHighByte);
            headerBytesList.Add(TeamIdLowByte);
            headerBytesList.Add((byte)MissionTimeHour);
            headerBytesList.Add((byte)MissionTimeMin);
            headerBytesList.Add((byte)MissionTimeSec);
            headerBytesList.Add((byte)MissionTime100thOfSec);
            headerBytesList.Add(PacketType);

            return headerBytesList.ToArray();
        }
    }


    public class TelemetryPacket : Packet
    {
       
        private int packetCount;
        private float altitudeInMeters;
        private float pressureInPascals;
        private float airspeedInMetersPerSec;
        private float temperatureInCelcius;
        private float voltage;
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

        public float SourceVoltage
        {
            get
            {
                return voltage;
            }

            set
            {
                voltage = value;
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

            updateWithTelemetryValues(telemetryValues);          
                    

        }

        public void parsePacketCountValue(String stringPacketCountValue)
        {
            int packetCount = 0;
            if (int.TryParse(stringPacketCountValue, out packetCount))
            {
                this.PacketCount = packetCount;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Packet count value: " + stringPacketCountValue);
            }
        }

        public void parseAltitudeValue(String stringAltitudeValue)
        {
            float altitude = 0;
            if (float.TryParse(stringAltitudeValue, out altitude))
            {
                this.AltitudeInMeters = altitude;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Altitude value: " + stringAltitudeValue);
            }
        }

        public void parsePressureValue(String stringPressureValue)
        {
            float pressure = 0;
            if (float.TryParse(stringPressureValue, out pressure))
            {
                this.PressureInPascals = pressure;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Pressure value: " + stringPressureValue);
            }
        }

        public void parseAirSpeedValue(String stringAirSpeedValue)
        {
            float airSpeed = 0;
            if (float.TryParse(stringAirSpeedValue, out airSpeed))
            {
                this.AirspeedInMetersPerSec = airSpeed;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid AirSpeed value: " + stringAirSpeedValue);
            }
        }

        public void parseTemperatureValue(String stringTemperatureValue)
        {
            float temperature = 0;
            if (float.TryParse(stringTemperatureValue, out temperature))
            {
                this.TemperatureInCelcius = temperature;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Temperature value: " + stringTemperatureValue);
            }
        }

        public void parseVoltageValue(String stringVoltageValue)
        {
            float voltage;
            if (float.TryParse(stringVoltageValue, out voltage))
            {
                this.voltage = voltage;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Voltage value: " + stringVoltageValue);
            }
        }

        public void parseGpsLatitudeValue(String stringGpsLatitudeValue)
        {
            float gpsLatitudeValue;
            if (float.TryParse(stringGpsLatitudeValue, out gpsLatitudeValue))
            {
                this.GpsLatitude = gpsLatitudeValue;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid GPS latitude value: " + stringGpsLatitudeValue);
            }
        }


        public void parseGpsLongitudeValue(String stringGpsLongitudeValue)
        {
            float gpsLongitudeValue;
            if (float.TryParse(stringGpsLongitudeValue, out gpsLongitudeValue))
            {
                this.GpsLongitude = gpsLongitudeValue;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid GPS longitude value: " + stringGpsLongitudeValue);
            }
        }


        public void parseGpsAltitudeValue(String stringGpsAltitudeValue)
        {
            float gpsAltitudeValue;
            if (float.TryParse(stringGpsAltitudeValue, out gpsAltitudeValue))
            {
                this.GpsAltitude = gpsAltitudeValue;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid GPS altitude value: " + stringGpsAltitudeValue);
            }
        }

        public void parseGpsSatNumberValue(String stringGpsSatNumberValue)
        {
            int gpsSatNumberValue;
            if (int.TryParse(stringGpsSatNumberValue, out gpsSatNumberValue))
            {
                this.GpsSatNumber = gpsSatNumberValue;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid GPS sat number value: " + stringGpsSatNumberValue);
            }

        }

        public void parseGpsSpeedValue(String stringGpsSpeedValue)
        {
            float gpsSpeedValue;
            if (float.TryParse(stringGpsSpeedValue, out gpsSpeedValue))
            {
                this.GpsSpeedInMetersPerSec = gpsSpeedValue;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid GPS speed value: " + stringGpsSpeedValue);
            }

        }

        public void updateWithTelemetryValueAtIndex(String stringTelemetryValue, int index)
        {
            /* <PACKET COUNT> (int) ,<ALT SENSOR> (float .x), <PRESSURE>(float .xx),<SPEED>(float .xx), <TEMP>(float .x),<VOLTAGE> (float .x),
* <GPS LATITUDE>(double .xxxxxx) ,<GPSLONGITUDE> (double .xxxxxx) ,<GPS ALTITUDE> (flaot .x),<GPS SAT NUM>(int),<GPS SPEED>(float .xx)*/
            switch (index)
            {
                case 0:
                    parsePacketCountValue(stringTelemetryValue);
                    break;
                case 1:
                    parseAltitudeValue(stringTelemetryValue);
                    break;
                case 2:
                    parsePressureValue(stringTelemetryValue);
                    break;
                case 3:
                    parseAirSpeedValue(stringTelemetryValue);
                    break;
                case 4:
                    parseTemperatureValue(stringTelemetryValue);
                    break;
                case 5:
                    parseVoltageValue(stringTelemetryValue);
                    break;
                case 6:
                    parseGpsLatitudeValue(stringTelemetryValue);
                    break;
                case 7:
                    parseGpsLongitudeValue(stringTelemetryValue);
                    break;
                case 8:
                    parseGpsAltitudeValue(stringTelemetryValue);
                    break;
                case 9:
                    parseGpsSatNumberValue(stringTelemetryValue);
                    break;
                case 10:
                    parseGpsSpeedValue(stringTelemetryValue);
                    break;
            }
        }

        public void updateWithTelemetryValues(String[] telemetryValues)
        {
           for (int i = 0; i < telemetryValues.Length; i++)
            {
                String stringTelemetryValue = telemetryValues[i];
                updateWithTelemetryValueAtIndex(stringTelemetryValue, i);
            }
        }

        public String[] toStringArray()
        {
            IList<String> csvTelemetryString = new List<String>
            {
                PacketCount.ToString(),
                AltitudeInMeters.ToString(),
                PressureInPascals.ToString(),
                AirspeedInMetersPerSec.ToString(),
                TemperatureInCelcius.ToString(),
                SourceVoltage.ToString(),
                GpsLatitude.ToString(),
                GpsLongitude.ToString(),
                GpsAltitude.ToString(),
                GpsSatNumber.ToString(),
                gpsSpeedInMetersPerSec.ToString()
            };

            return csvTelemetryString.ToArray();
        }

        public String toString()
        {
            return toCsvString();
        }

        public String toCsvString()
        {
            String[] telemetryStringArray = toStringArray();
            return string.Join(",", telemetryStringArray);
        }

        public byte[] getBinaryDataWithHeader()
        {
            String telemetryCsvString = toCsvString();
            byte[] telemetryCsvStringBytes = Encoding.ASCII.GetBytes(telemetryCsvString);
            byte[] headerBytes = getPacketHeader();

            List<byte> telemetryDataBytesWithHeaderList = new List<byte>();
            telemetryDataBytesWithHeaderList.AddRange(headerBytes);
            telemetryDataBytesWithHeaderList.AddRange(telemetryCsvStringBytes);

            return telemetryDataBytesWithHeaderList.ToArray();

        }
    }

    public class ImagePacket: Packet
    {
        private byte imageChunkOffsetHigh;
        private byte imageChunkOffsetLow;

        private byte[] imageDataBytes;

        public byte ImageChunkOffsetHigh
        {
            get
            {
                return imageChunkOffsetHigh;
            }

            set
            {
                imageChunkOffsetHigh = value;
            }
        }

        public byte ImageChunkOffsetLow
        {
            get
            {
                return imageChunkOffsetLow;
            }

            set
            {
                imageChunkOffsetLow = value;
            }
        }

        public byte[] ImageDataBytes
        {
            get
            {
                return imageDataBytes;
            }

            set
            {
                imageDataBytes = value;
            }
        }

        public int ImageChunkOffset
        {
            get
            {
                return ((UInt16)ImageChunkOffsetLow | ((UInt16)ImageChunkOffsetHigh << 8));
            }
            set
            {
                ImageChunkOffsetHigh = (byte)(value >> 8);
                ImageChunkOffsetLow = (byte)(value & 0x00FF);
            }
        }


        private byte[] toBinaryPacketData()
        {
            byte[] imagePacketBytes = null;
            if (imageDataBytes != null)
            {
                imagePacketBytes = new byte[ImageDataBytes.Length + 2];
                imagePacketBytes[0] = ImageChunkOffsetHigh;
                imagePacketBytes[1] = ImageChunkOffsetLow;
                for(int i=0; i<ImageDataBytes.Length; i++)
                {
                    imagePacketBytes[i + 2] = ImageDataBytes[i];
                }
                return imagePacketBytes;
            }

            return imagePacketBytes;
        }

        public void updateWithBinaryData(byte[] imagePacketBinaryData)
        {
            if(imagePacketBinaryData.Length < 2)
            {
                Debug.WriteLine("Image packet binary data is less than the minimum lenght 2. Actual Length " +
                    imagePacketBinaryData.Length);
                return;
            }
            //First two bytes are the image chunk count
            imageChunkOffsetHigh = imagePacketBinaryData[0];
            ImageChunkOffsetLow = imagePacketBinaryData[1];

            Debug.WriteLine("Offset: " + ImageChunkOffset);

            ImageDataBytes = new byte[imagePacketBinaryData.Length - 2]; 

            for(int i=0; i< ImageDataBytes.Length; i++)
            {
                ImageDataBytes[i] = imagePacketBinaryData[i + 2];
            }

        }
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
            IEnumerable<byte> packetDataArrayReverse = packetDataArray.Reverse();

            //Conver the packet data array to a stack of bytes
            Stack<byte> packetDataStack = new Stack<byte>();
            foreach(byte b in packetDataArray.Reverse())
            {
                packetDataStack.Push(b);
            }
            
            if(incomingPacket.FrameType == XBee.XBEE_FRAME_TYPE.RECIEVE_PACKET)
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
                        //Debug.WriteLine(BitConverter.ToString(newImagePacket.ImageDataBytes));
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
            imagePacket.updateWithBinaryData(packetDataStack.ToArray());

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
