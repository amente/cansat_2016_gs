using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace CanSatGroundStation
{
    class SerialPortSimulator
    {
        private int numBytesToRead = -1;
        private static byte[] data = new byte[0];
        private int byteReadIndex = 0;
        private Thread simulatorThread;
        private static volatile SerialPortSimulator simulatorInstance;
        private Boolean simulaterThreadIsRunning = false;
        private static Boolean simulationStarted = false;
        private static int intervalMs = 1000;

        public static SerialPortSimulator Instance
        {
            get
            {
                if (simulatorInstance == null)
                {
                    simulatorInstance = new SerialPortSimulator();
                }
                return simulatorInstance;
            }
        }

        public int BytesToRead
        {
            get
            {
                return numBytesToRead;
            }
        }

        public static byte[] Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public int readByte()
        {
            int returnValue = -1;
            if(byteReadIndex < data.Length)
            {
                returnValue =  (int)data[byteReadIndex];
                byteReadIndex++;
            }

            return returnValue;
        }

        public void start()
        {
            if (!simulaterThreadIsRunning)
            {
                try
                {
                    simulatorThread = new Thread(SimulateIntervalMs);
                    simulatorThread.Start();
                    simulaterThreadIsRunning = true;
                }
                catch (ThreadAbortException e)
                {
                    //It is ok to abort
                    Debug.WriteLine("SerialPortSimulator simulator aborted.");
                }
            }
        }

        public void abort()
        {
            if (simulatorThread != null && simulaterThreadIsRunning)
            {
                simulatorThread.Abort();
                simulaterThreadIsRunning = false;
            }
        }

        public static int SimulationIntevalMS
        {
            get
            {
                return intervalMs; ;
            }
            set
            {
                intervalMs = value;
            }
        }


        public static Boolean SimulationStarted
        {
            get
            {
                return simulationStarted;
            }

            set
            {
                simulationStarted = value;
            }
        }

        public static void SimulateIntervalMs()
        {

            while(true)
            {
                if (simulationStarted)
                {
                    Debug.WriteLine(BitConverter.ToString(Data));
                    foreach (byte b in Data)
                    {
                        XBee.IncomingByteHandler(b);
                        Thread.Sleep(5);
                    }
                    Thread.Sleep(intervalMs);
                }
            }
        }

    }
}
