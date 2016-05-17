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

namespace CanSatGroundStation
{
    public partial class GroundStationControl : Form
    {
       
        PayloadGraphForm payloadGraphForm;       
        DataTableForm payloadTableForm;
        CommandForm commandForm;
        ConfigForm configForm;
        StatusForm statusForm;
        

        public GroundStationControl()
        {
            InitializeComponent();

            XBee.xbeeRawByteAvaialbleHandler += RawByteAvialableHandler;
            XBee.xbeeIncomingPacketAvaialbleHandler += IncomingPacketAvaialble;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            payloadGraphForm = new PayloadGraphForm();
            payloadGraphForm.Text = "Telemetry Chart";           
            payloadTableForm = new DataTableForm();

            payloadGraphForm.Show();
            payloadTableForm.Show();

            commandForm = new CommandForm();         
            commandForm.Show();

            configForm = new ConfigForm();
            statusForm = new StatusForm();
            statusForm.Show();
        }
               
        private void RawByteAvialableHandler(byte rawByte)
        {
            commandForm.appendRawData(rawByte);
            Logger.Instance.logRawByte(rawByte);
        }

        private void ValidPacketAvailable(TelemetryPacket packet)
        {
           //payloadTableForm.AddData(packet.toArray());
           //payloadGraphForm.addPacket(packet);
           //statusForm.setPayloadData(packet);                
           

            //telemetryForm.appendValidData(packet);
           //Logger.Instance.logValid(packet);
        }

        private void IncomingPacketAvaialble(XBeeIncomingPacket packet)
        {
            //Debug.WriteLine("Incoming Packet Frame Type: " + packet.FrameType.ToString());
        }

        private void mnuTelemetry_Click(object sender, EventArgs e)
        {
            commandForm.Show();
        }
        private void mnuDataGraphs_Click(object sender, EventArgs e)
        {
            payloadGraphForm.Show();
        }
        private void mnuDataTable_Click(object sender, EventArgs e)
        {
            payloadTableForm.Show();
        }

        private void btnTelemetry_Click(object sender, EventArgs e)
        {
            commandForm.Show();
            commandForm.BringToFront();
        }

        private void btnGraphs_Click(object sender, EventArgs e)
        {
            payloadGraphForm.Show();            
            payloadGraphForm.BringToFront();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            payloadTableForm.Show();
            payloadTableForm.BringToFront();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            configForm.Show();
        }

        private void btnStatus_Click_1(object sender, EventArgs e)
        {
            statusForm.Show();
        }
    }
}
