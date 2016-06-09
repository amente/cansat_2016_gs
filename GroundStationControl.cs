using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;

namespace CanSatGroundStation
{
    
    public partial class GroundStationControl : Form
    {
       
        TelemetryChartsForm telemetryChartsForm;       
        TelemetryDataTableForm telemetryDataTableForm;
        CommandForm commandForm;
        ConfigForm configForm;
        StatusForm statusForm;

        Boolean pictureRecieveHasStarted = false;
        TimeCalculate pictureRecieveTimer = new TimeCalculate();

        public GroundStationControl()
        {
            InitializeComponent();

            //Initialize event handlers

            //Parsing and logging related events
            XBee.xbeeRawByteAvaialbleHandler += Logger.Instance.logRawByte;
            XBee.xbeeIncomingPacketAvaialbleHandler += IncomingXBeePacketAvailable;
            XBee.xbeeIncomingPacketAvaialbleHandler += PacketParser.Instance.parse;
            PacketParser.telemetryPacketAvailableHandler += Logger.Instance.logTelemetryPacket;
            PacketParser.imagePacketAvailableHandler += ImageReceiver.Instance.receiveImagePacket;

            //UI related events
            XBee.xbeeRawByteAvaialbleHandler += RawByteAvailableHandler;
            PacketParser.telemetryPacketAvailableHandler += TelemetryPacketAvailableHandler;
            PacketParser.imagePacketAvailableHandler += OnImagePacketAvailable;
            ImageReceiver.imageFileUpdateHandler += ImageFileUpdateHandler;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            telemetryChartsForm = new TelemetryChartsForm();
            telemetryChartsForm.Text = "Telemetry Chart";           
            telemetryDataTableForm = new TelemetryDataTableForm();

            telemetryChartsForm.Show();
            telemetryDataTableForm.Show();

            commandForm = new CommandForm();         
            commandForm.Show();

            configForm = new ConfigForm();
            statusForm = new StatusForm();
            statusForm.Show();
        }
               
        private void RawByteAvailableHandler(byte rawByte)
        {
            commandForm.appendRawData(rawByte);
        }

        private void TelemetryPacketAvailableHandler(TelemetryPacket telemetryPacket)
        {
            //payloadTableForm.AddData(packet.toArray());
            //payloadGraphForm.addPacket(packet);
            //statusForm.setPayloadData(packet);                


            telemetryChartsForm.updateChartsWithPacket(telemetryPacket);
            statusForm.updateWithTelemetryPacket(telemetryPacket);

        }

        private void IncomingXBeePacketAvailable(XBeeIncomingPacket packet)
        {
            //Debug.WriteLine("Incoming Packet Frame Type: " + packet.FrameType.ToString());
        }

        public void ImageFileUpdateHandler(Image image)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    this.pictureBox1.Image = image;
                    this.pictureBox1.Refresh();
                }
                catch(Exception e)
                {
                    //Debug.WriteLine("Image file is corrupted.");
                }

            });
        }

        private void PictureRecieveTimerChanged(int timeInSecs)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblPictureTransmissionTime.Text = timeInSecs.ToString();
            });
        }

        public void OnImagePacketAvailable(ImagePacket imagePacket)
        {
            if(!pictureRecieveHasStarted)
            {
                pictureRecieveHasStarted = true;
                pictureRecieveTimer.TimeInSecs = 0;
                pictureRecieveTimer.TheTimeChanged += PictureRecieveTimerChanged;
            }
            int numBytesRemaining = imagePacket.ImageChunkOffset;
            this.Invoke((MethodInvoker)delegate
            {
                labelRemainingImageBytes.Text = numBytesRemaining.ToString();
            });

            if(numBytesRemaining == 0)
            {
                pictureRecieveHasStarted = false;
                pictureRecieveTimer.TheTimeChanged -= PictureRecieveTimerChanged;
            }

        }

        private void mnuTelemetry_Click(object sender, EventArgs e)
        {
            commandForm.Show();
        }
        private void mnuDataGraphs_Click(object sender, EventArgs e)
        {
            telemetryChartsForm.Show();
        }
        private void mnuDataTable_Click(object sender, EventArgs e)
        {
            telemetryDataTableForm.Show();
        }

        private void btnTelemetry_Click(object sender, EventArgs e)
        {
            commandForm.Show();
            commandForm.BringToFront();
        }

        private void btnGraphs_Click(object sender, EventArgs e)
        {
            telemetryChartsForm.Show();            
            telemetryChartsForm.BringToFront();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            telemetryDataTableForm.Show();
            telemetryDataTableForm.BringToFront();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            configForm.Show();
        }

        private void btnStatus_Click_1(object sender, EventArgs e)
        {
            statusForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommandSender.Instance.sendTakePictureCommand();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommandSender.Instance.sendResetCameraCommand();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CommandSender.Instance.sendActivateReleaseOneCommand();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CommandSender.Instance.sendActivateReleaseTwoCommand();
        }
    }

    public class TimeCalculate
    {
        private Timer timer;

        private int timeInSecs = 0;

        public int TimeInSecs
        {
            get
            {
                return timeInSecs;
            }
            set
            {
                timeInSecs = value;
                OnTheTimeChanged(this.timeInSecs);
            }
        }

        public TimeCalculate()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 1000;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeInSecs += 1;
        }

        public delegate void TimerTickHandler(int timeInSecs);
        public event TimerTickHandler TheTimeChanged;

        protected void OnTheTimeChanged(int timeInSecs)
        {
            TheTimeChanged?.Invoke(timeInSecs);
        }
    }

}
