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
        private const byte TEST_STATE = 0xAA;
        private const byte LAUNCH_PAD_STATE = 0xBB;
        private const byte ASCENT_STATE = 0XCC;
        private const byte PRE_DEPLOYED_STATE = 0XDD;
        private const byte PAYLOAD_DEPLOYED_STATE = 0xEE;
        private const byte LANDED_STATE = 0xFF;


        public StatusForm()
        {
            InitializeComponent();
        }

        public void updateWithTelemetryPacket(TelemetryPacket telemetryPacket)
        {
            this.Invoke((MethodInvoker)delegate
            {
                String missionTime = telemetryPacket.MissionTimeHour + ":" + telemetryPacket.MissionTimeMin + ":" + telemetryPacket.MissionTimeSec;
                lblMissionTime.Text = missionTime;
                
                switch(telemetryPacket.MissionState)
                {
                    case TEST_STATE:
                        lblMissionState.Text = "TEST STATE";
                        break;
                    case LAUNCH_PAD_STATE:
                        lblMissionState.Text = "LAUNCH PAD STATE";
                        break;
                    case ASCENT_STATE:
                        lblMissionState.Text = "ASCENT STATE";
                        break;
                    case PRE_DEPLOYED_STATE:
                        lblMissionState.Text = "PRE DEPLOYED STATE";
                        break;
                    case PAYLOAD_DEPLOYED_STATE:
                        lblMissionState.Text = "PAYLOAD DEPLOYED STATE";
                        break;
                    case LANDED_STATE:
                        lblMissionState.Text = "LANDED STATE";
                        break;
                    default:
                        lblMissionState.Text = "UNKNOWN STATE";
                        break;
                }

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
