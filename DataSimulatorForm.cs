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
            TelemetryPacket telemetryPacket = new TelemetryPacket();
            telemetryPacket.TeamIdHighByte = PacketParser.TEAM_ID_HIGH_BYTE;
            telemetryPacket.TeamIdLowByte = PacketParser.TEAM_ID_LOW_BYTE;
            telemetryPacket.PacketType = PacketParser.TELEMETRY_PACKET_TYPE;

            //Update the packet with data from the UI
            telemetryPacket.TemperatureInCelcius = (float)numericUpDownTemperature.Value;
            telemetryPacket.AltitudeInMeters = (float)numericUpDownAltitude.Value;
            telemetryPacket.SourceVoltage = (float)numericUpDownSourceVoltage.Value;
            telemetryPacket.AirspeedInMetersPerSec = (float)numericUpDownAirspeed.Value;


            byte[] telemetryDataBytes = telemetryPacket.getBinaryDataWithHeader();
            return XBeeIncomingPacket.createIncomingRecievePacket(telemetryDataBytes);
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

        private void numericUpDownValueChanged(object sender, EventArgs e)
        {
            SerialPortSimulator.Data = getTelemetryData();
        }
    }
}
