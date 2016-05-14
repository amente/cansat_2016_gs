using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanSatGroundStation
{
    public partial class PayloadGraphForm : Form
    {
        public PayloadGraphForm()
        {
            InitializeComponent();
        }

        public void addPacket(TelemetryPacket packet)
        {
            rtgTemp.AddDataPoint(packet.temperature);            
            rtgAlt.AddDataPoint(packet.altitude);           
            rtgBat.AddDataPoint(packet.batVoltage);            
            rtgLux.AddDataPoint(packet.lux);           

            this.Invoke((MethodInvoker)delegate
            {
                rtgTemp.Refresh();
                rtgAlt.Refresh();
                rtgBat.Refresh();
                rtgLux.Refresh();

                lblTmp.Text = packet.temperature.ToString("F1");
                lblAlt.Text = packet.altitude.ToString("F1");
                lblVolt.Text = packet.batVoltage.ToString();
                lblLux.Text = packet.lux.ToString();
            });            
        }

        private void DataGraphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void lblAltitude_Click(object sender, EventArgs e)
        {

        }

        private void splTempurature_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void PayloadGraphForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
