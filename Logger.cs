using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.IO.Ports;


namespace CanSatGroundStation
{
    public class Logger
    {
        public static string VALID_LOG_FILE_NAME = "cansat_valid_log.txt";
        public static string RAW_LOG_FILE_NAME = "cansat_raw_log.txt";

        private static Logger logger;
        // Used to indicate first instance of a log operation so as include the data and time per session
        private bool appendedTimeToRaw = false; 
        private bool appendedTimeToValid = false;
        private String logDirPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);


        private Logger(){}

        public static Logger Instance
        {
            get
            {
                if (logger == null)
                {
                    logger = new Logger();                    
                }
                return logger;
            }
        }
        

        public void logRaw(String data)
        {
            FileStream s1 = new FileStream(logDirPath+"/"+RAW_LOG_FILE_NAME, FileMode.Append);
            StreamWriter sw = new StreamWriter(s1);
            // This method is called when the serial port recieves data 
            try
            {
                using (sw)
                {
                    if (!appendedTimeToRaw)
                    {
                        sw.WriteLine("\n**********" + System.DateTime.Now.ToString() + "**********");
                        appendedTimeToRaw = true;
                    }

                    sw.WriteLine(data);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Problem writing log file for raw data: \n" + e.Message);                
            }
            finally
            {
                s1.Close();
            }
        }

        public void logValid(TelemetryPacket packet)
        {
            // This method is called when a valid telemetry packet is parsed
            // This method is called when the serial port recieves data 
            FileStream s1 = new FileStream(logDirPath + "/" + VALID_LOG_FILE_NAME, FileMode.Append);
            StreamWriter sw = new StreamWriter(s1);
            try
            {
                using (sw)
                {
                    if (!appendedTimeToValid)
                    {
                        sw.WriteLine("\n**********" + System.DateTime.Now.ToString() + "**********");
                        appendedTimeToValid = true;
                    }

                    sw.WriteLine(packet.toString());
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Problem writing log file for valid data: \n" + e.Message);

            }
            finally
            {
                s1.Close();
            }
        }
        

        public void OpenValidLog()
        {
            Process.Start(VALID_LOG_FILE_NAME);
        }

        public void OpenRawLog()
        {
            Process.Start(RAW_LOG_FILE_NAME);
        }               

        public String getLogDirPath(){
            return logDirPath;
        }

        public void setLogDirPath(String p)
        {
            logDirPath = p;
        }
    }
}

