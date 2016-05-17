using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Threading;

namespace CanSatGroundStation
{
    public partial class CommandForm : Form
    {
       
        static string[] comPorts;
        DataSimulatorForm dataSimulatorForm;

        public static int RAW_DATA_MAX_BYTES_PER_LINE = 20;
        private List<byte> rawDataByteBuffer = new List<byte>();

        public CommandForm()
        {
            InitializeComponent();
            refreshComPorts();
            this.comboBox2.Items.AddRange(new string[] { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400" });
            this.comboBox2.SelectedIndex = 3;
            dataSimulatorForm = new DataSimulatorForm();
            dataSimulatorForm.Hide();  
        }

        private void refreshComPorts()
        {
            comPorts = SerialPort.GetPortNames();
            if (comPorts.Length != 0)
            {
                this.comboBox1.Items.Clear();
                this.comboBox1.Items.AddRange(comPorts);
            }
            else
            {
                this.comboBox1.Items.Add("<N/A>");
            }
            this.comboBox1.SelectedIndex = 0;
        }


        private void btnClearLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to clear the log?", "Delete Log", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //manager.ClearLog();
                this.label4.Text = "0";
            }
        }
        
   
        public void appendRawData(byte rawByte)
        {
            rawDataByteBuffer.Add(rawByte);
            if (rawDataByteBuffer.Count == RAW_DATA_MAX_BYTES_PER_LINE)
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    this.richTextBox1.AppendText(BitConverter.ToString(rawDataByteBuffer.ToArray()));
                    this.richTextBox1.AppendText("\n");
                    this.label4.Text = (int.Parse(this.label4.Text) + rawDataByteBuffer.Count).ToString();
                    rawDataByteBuffer.Clear();
                }));
            }                                          
        }

        public void appendValidData(TelemetryPacket packet)
        {

            this.BeginInvoke(new EventHandler(delegate
            {
                if (packet.isFromPayload())
                {
                    
                    String s = packet.toString();     
                    rtbValidPacket.SelectionColor = Color.Blue;
                    rtbValidPacket.AppendText(s);
                    rtbValidPacket.AppendText("\n");                    
                }
                else
                {
                    String s = packet.toString();
                    rtbValidPacket.SelectionColor = Color.Orange;
                    rtbValidPacket.AppendText(s);
                    rtbValidPacket.AppendText("\n");                   
                }
            }));

        }
       
        private void TelemetryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void btnReadLog_Click(object sender, EventArgs e)
        {
            //manager.OpenLog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!XBee.Instance.serialPortIsOPen())
            {
                 String PortName = this.comboBox1.SelectedItem.ToString();
                 int BaudRate = int.Parse(this.comboBox2.SelectedItem.ToString());
                try
                {                   
                    XBee.Instance.openSerialPort(PortName, BaudRate);                  
                    updateWidgets(true);
                    abortSimulator();
                }
                catch(Exception e1)
                {
                    MessageBox.Show("Unable to open port: " + PortName+"\n"+e1.Message);
                    updateWidgets(false);
                }               

            }            
            else
            {
                XBee.Instance.closeSerialPort();               
                updateWidgets(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshComPorts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }

        //Update the widget according to the state of the serial port
        private void updateWidgets(Boolean serialPortIsConnected)
        {
            this.button1.Text = serialPortIsConnected ? "Disconnet" : "Connect";
            this.comboBox1.Enabled = !serialPortIsConnected;
            this.comboBox2.Enabled = !serialPortIsConnected;
            this.button2.Enabled = !serialPortIsConnected;          
            this.checkBox2.Enabled = !serialPortIsConnected;           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                richTextBox1.SelectionStart = richTextBox1.Text.Length; 
                richTextBox1.ScrollToCaret(); 
            }
        }

        private void TelemetryForm_Load(object sender, EventArgs e)
        {

        }

        private void tlpTelemetry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox senderCheckBox = sender as CheckBox;
            if(senderCheckBox.Checked)
            {
                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.button2.Enabled = false;
                startSimulator();
                showDataSimulatorForm();
            }
            else
            {
                this.comboBox1.Enabled = true;
                this.comboBox2.Enabled = true;
                this.button2.Enabled = true;
                abortSimulator();
                dataSimulatorForm.Hide();
            }
        }

        private void showDataSimulatorForm()
        {
            dataSimulatorForm.Show();
            dataSimulatorForm.BringToFront();
        }

        private void startSimulator()
        {
            SerialPortSimulator.Instance.start();
        }

        private void abortSimulator()
        {
            SerialPortSimulator.Instance.abort();
        }
    }
}
