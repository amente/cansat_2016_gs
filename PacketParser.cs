using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanSatGroundStation
{
    class Packet
    {
        private byte teamIDHighByte;
        private byte teamIDLowByte;

        private int missionTimeHour;
        private int missionTimeMin;
        private int missionTimeSec;
        private int missionTime100thOfSec;


        public byte TeamIDHighByte
        {
            get
            {
                return teamIDHighByte;
            }
            set
            {
                teamIDHighByte = value;
            }
        }
        
        public byte TeamIDLowByte
        {
            get
            {
                return teamIDLowByte;
            }
            set
            {
                teamIDLowByte = value;
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
    }

    class PacketParser
    {
        private static volatile PacketParser packetParserInstance;
        public const byte TEAM_ID_HIGH_BYTE = 0x68;
        public const byte TEAM_ID_LOW_BYTE = 0x25;

        public const byte TELEMETRY_PACKET_TYPE = 0xE0;
        public const byte IMAGE_PACKET_TYPE = 0xE1;

        public const int RECIEVE_PACKET_DATA_OFFSET = 11;

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
            byte[] packetData = incomingPacket.PacketData;

            int parseOffset = 0;

            if(incomingPacket.FrameType == XBeeIncomingPacket.XBEE_FRAME_TYPE.RECIEVE_PACKET)
            {
                if(packetData.Length < PACKET_PARSER_MIN_RECIEVE_PACKET_LENGTH)
                {
                    System.Diagnostics.Debug.WriteLine("Incoming packet data is less than minimum recive packet length: Length: " 
                        + packetData.Length + " PacketData: " 
                        + BitConverter.ToString(packetData));
                    return;
                }

                //The packet was a recieve packet 
                //The first 8 bytes are 64 bit source address
                parseOffset += 8;

                //The next 2 bytes are 16 bit source address
                parseOffset += 2;

                //The next 1 byte is the recieve options bytes
                parseOffset += 1;


                //The next 1 byte is the teamID High Byte
                byte teamIdHighByte = packetData[parseOffset];
                parseOffset += 1;
                //The next 1 byte is the teamID Low Byte
                byte teamIdLowByte = packetData[parseOffset];
                parseOffset += 1;

                //First two bytes are the team Id
                if (teamIdHighByte == TEAM_ID_HIGH_BYTE && teamIdLowByte == TEAM_ID_LOW_BYTE)
                {
                   // Continue
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Invalid team id recieve in packet data: " +
                        "TeamIDHighByte: " + teamIdHighByte.ToString("X2") +
                        "TeamIDLowByte: " + teamIdLowByte.ToString("X2") +
                        " PacketData: " +
                        BitConverter.ToString(packetData));
                     return;
                }

                //The next 4 bytes are mission Time
                //Next four bytes are mission time, 1byte Hour, 1byte Min, 1Byte Sec, 1Byte (1/100th) of a sec
                int missionTimeHour = packetData[parseOffset];
                parseOffset += 1;
                int missionTimeMin = packetData[parseOffset];
                parseOffset += 1;
                int missionTimeSec = packetData[parseOffset];
                parseOffset += 1;
                int missionTime100thOfSec = packetData[parseOffset];
                parseOffset += 1;

                //Next Byte will be the packet type
                byte packetType = packetData[parseOffset];
                parseOffset += 1;

                //TODO: Packet type enum, to parse telemetry and image packet


              
            }

        }
        
    }
}
