using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanSatGroundStation
{
    public partial class DataSimulatorForm : Form
    {
        public DataSimulatorForm()
        {
            InitializeComponent();
        }


        public byte[] getTelemetryData()
        {
            byte[] dataBytes = Encoding.ASCII.GetBytes("20.0");
            return XBeeIncomingPacket.createIncomingRecievePacket(dataBytes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!SerialPortSimulator.SimulationStarted)
            {
                Debug.WriteLine("Starting simulation");
                SerialPortSimulator.Data = getTelemetryData();
                SerialPortSimulator.SimulationStarted = true;
                button1.Text = "Stop Simulation";
            }
            else
            {
                Debug.WriteLine("Stopping simulation");
                SerialPortSimulator.SimulationStarted = false;
                button1.Text = "Start Simulation";
            }
        }
    }
}
