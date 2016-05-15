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
    public partial class StatusForm : Form
    {
        public StatusForm()
        {
            InitializeComponent();
        }

        public void setPayloadDeployed(bool payloadDeployed)
        {
           
        }

        public void setUmbrellaDeployed(bool umbrellaDeployed)
        {
        }
          
          

        public void setPayloadData(TelemetryPacket packet)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblPayloadVolt.Text = packet.batVoltage.ToString();
                lblPaloadAlt.Text = packet.altitude.ToString("F1");
                lblPayloadTmp.Text = packet.temperature.ToString("F1");
                lblPayloadTime.Text = packet.missionTime.ToString();

            });
           
        }

        public void setContainerData(TelemetryPacket packet)
        {
            this.Invoke((MethodInvoker)delegate
            {
                
                setPayloadDeployed(packet.payloadDeployed);
                setUmbrellaDeployed(packet.umbrellaDeployed);

            });            
        }
               

        private void StatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblPaloadAlt_Click(object sender, EventArgs e)
        {

        }

        private void lblContainerTmp_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
