using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CanSatGroundStation
{
    class SerialPortSimulator
    {
        private int numBytesToRead = -1;
        private static byte[] data;
        private int byteReadIndex = 0;
        private Thread simulatorThread = new Thread(Simulate);


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
            simulatorThread.Start();
        }

        public void abort()
        {
            simulatorThread.Abort();
        }

        private static void Simulate()
        {
            while(true)
            {
                foreach(byte b in Data)
                {
                    XBee.IncomingByteHandler(b);
                    Thread.Sleep(5);
                }
                Thread.Sleep(1000);
            }
        }

    }
}
