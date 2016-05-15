using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace CanSatGroundStation
{
    public partial class GroundStationControl : Form
    {
       
        PayloadGraphForm payloadGraphForm;       
        DataTableForm payloadTableForm;
        CommandForm telemetryForm;
        ConfigForm configForm;
        StatusForm statusForm;

        public GroundStationControl()
        {
            InitializeComponent();
            XBee.rawPacketAvailable += RawPacketAvailable;
            XBee.validPacketAvailable += ValidPacketAvailable;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            payloadGraphForm = new PayloadGraphForm();
            payloadGraphForm.Text = "Telemetry Chart";           
            payloadTableForm = new DataTableForm();

            payloadGraphForm.Show();
            payloadTableForm.Show();

            telemetryForm = new CommandForm();         
            telemetryForm.Show();

            configForm = new ConfigForm();
            statusForm = new StatusForm();
            statusForm.Show();
        }

        private void RawPacketAvailable(String data)
        {
            telemetryForm.appendRawData(data);            
            Logger.Instance.logRaw(data);
        }
       
        private void ValidPacketAvailable(TelemetryPacket packet)
        {
           payloadTableForm.AddData(packet.toArray());
           payloadGraphForm.addPacket(packet);
           statusForm.setPayloadData(packet);                
           

            telemetryForm.appendValidData(packet);
            Logger.Instance.logValid(packet);
        }

        private void mnuTelemetry_Click(object sender, EventArgs e)
        {
            telemetryForm.Show();
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
            telemetryForm.Show();
            telemetryForm.BringToFront();
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
