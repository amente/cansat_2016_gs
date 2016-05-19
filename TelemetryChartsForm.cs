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
    public partial class TelemetryChartsForm : Form
    {
        public TelemetryChartsForm()
        {
            InitializeComponent();
        }

        public void updateChartsWithPacket(TelemetryPacket telemetryPacket)
        {
            
            rtgTemperature.AddDataPoint(telemetryPacket.TemperatureInCelcius);            
            rtgAltitude.AddDataPoint(telemetryPacket.AltitudeInMeters);           
            rtgSourceVoltage.AddDataPoint(telemetryPacket.SourceVoltage);            
            rtgAirSpeed.AddDataPoint(telemetryPacket.AirspeedInMetersPerSec);           

            this.Invoke((MethodInvoker)delegate
            {
                rtgTemperature.Refresh();
                rtgAltitude.Refresh();
                rtgSourceVoltage.Refresh();
                rtgAirSpeed.Refresh();

                lblTemperature.Text = telemetryPacket.TemperatureInCelcius.ToString("F1");
                lblAltitude.Text = telemetryPacket.AltitudeInMeters.ToString("F1");
                lblSourceVoltage.Text = telemetryPacket.SourceVoltage.ToString();
                lblAirSpeed.Text = telemetryPacket.AirspeedInMetersPerSec.ToString();
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
