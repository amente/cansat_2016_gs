using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanSatGroundStation
{
    //<API_HEADER><TEAM ID>,<PACKET COUNT>,<MISSION_TIME>,<ALT>,<TEMP>,<VOLTAGE>,<LUM_IDX><STATUS>
    // 7E 00 1C 90 00 13 A2 00 40 70 E1 23 0A 5B 01 23 05 00 B0 1C 57 9F FC 7A F3 00 00 00 00 00 00 8E
    // <---------API HEADER-----------------------> <------------------PACKET DATA ------------------><CheckSum>
    public class TelemetryPacket
    {
        
        public static int API_PACKET_SIZE = 64 ; // 72 Hex String chars 34 bytes total
        public static int API_HEADER_SIZE = 30;  // 30 Hex String chars
        public static int API_FRAME_DATA_OFFSET = 30; // 30 Hex String chars = 15 bytes
        public static int PACKET_DATA_SIZE = 32; //32 Hex String chars = 16 bytes
        public static int PACKET_COUNT_IDX = 4;  // 4 Hex Strings
        public static int MISSION_TIME_IDx = 8;
        public static int ALT_IDX = 12;      
        public static int TEMPERATURE_IDX = 16;
        public static int SOURCE_VOLT_IDX = 20;
        public static int LUM_IDX = 24;             
        public static int PACKET_FROM_IDX = 28;       
        public static int UMBRELLA_DEPLOYED_IDX = 30;
        public static int PAYLOAD_DEPLOYED_IDX = 31;
                

        private Boolean isPayload = true;

        
        public static string TEAM_ID = "2305" ;

        public double temperature;
        public double altitude;
        public UInt16 missionTime; // Mission time in seconds.
        public UInt16 packetCount;
        public int batVoltage;
        public int lux;       
        public bool payloadDeployed = false;
        public bool umbrellaDeployed = false;

        String[] packetArray;
        String packetString;
                
        public TelemetryPacket(String telemetry)
        {
            
            isPayload = checkIfFromPayload(telemetry); // This should be done first before conversions

            temperature = getShortInt(telemetry.Substring(TEMPERATURE_IDX, 4)) * 0.1; // unvonverted temp is in 0.1 celsious
            altitude = getShortInt(telemetry.Substring(ALT_IDX, 4))*0.1; // Altitude expected is in 100m's
            missionTime = getUShortInt(telemetry.Substring(MISSION_TIME_IDx, 4));
            packetCount = getUShortInt(telemetry.Substring(PACKET_COUNT_IDX, 4));
            batVoltage = getShortInt(telemetry.Substring(SOURCE_VOLT_IDX,4));
                   

            lux = getUnsignedShortInt(telemetry.Substring(LUM_IDX,4))*16;
            
            payloadDeployed = telemetry.Substring(PAYLOAD_DEPLOYED_IDX, 1) == "F";
            umbrellaDeployed = telemetry.Substring(UMBRELLA_DEPLOYED_IDX, 1) == "F";
            
            packetArray = new String[] { 
                TEAM_ID,
                packetCount.ToString(), 
                missionTime.ToString(),
                altitude.ToString("F1"),
                temperature.ToString("F1"),
                batVoltage.ToString("F1"),
                lux.ToString()                              
            };

            packetString = String.Join(",",packetArray);
        }   
       
       
        public String[] toArray()
        {
            return packetArray;
        }

        public String toString()
        {
            return packetString;
        }

        private Int16 getShortInt(String hexText){
            return Int16.Parse(hexText, System.Globalization.NumberStyles.HexNumber);
        }

        private UInt16 getUShortInt(String hexText)
        {
            return UInt16.Parse(hexText, System.Globalization.NumberStyles.HexNumber);
        }

        private Int32 getLongInt(String hexText)
        {
            return Int32.Parse(hexText, System.Globalization.NumberStyles.HexNumber);
        }

        private UInt16 getUnsignedShortInt(String hexText)
        {
            return UInt16.Parse(hexText, System.Globalization.NumberStyles.HexNumber);
        }

        /**
         * @return true if from payload, false otherwise 
         */
        private Boolean checkIfFromPayload(String telemetry){
            return telemetry.Substring(PACKET_FROM_IDX, 2) == "00";
        }

        public Boolean isFromPayload()
        {
            return isPayload;
        }


        private double[] light_sensor_conversion(UInt16 ch0,UInt16 ch1){
            double lux, ir_lux;
            double ratio = Convert.ToDouble(ch1) / ch0;

            if (ratio > 0 && ratio <= 0.52)
            {
                ir_lux = 0.0593 * ch0 * Math.Pow(ratio, 1.4);
                lux = 0.0315 * ch0 - ir_lux;
            }
            else if (ratio > 0.52 && ratio <= 0.65)
            {
                ir_lux = 0.0291 * ch1;
                lux = 0.0229 * ch0 - ir_lux;
            }
            else if (ratio > 0.65 && ratio <= 0.80)
            {
                ir_lux = 0.0180 * ch1;
                lux = 0.0157 * ch0 - ir_lux;
            }
            else if (ratio > 0.8 && ratio <= 1.3)
            {
                ir_lux = 0.00260 * ch1;
                lux = 0.00338 * ch0;
            }
            else
            {
                lux = 0;
                ir_lux = 0;
            }           
            return new double[2]{lux,ir_lux};
        }


    }

    
}