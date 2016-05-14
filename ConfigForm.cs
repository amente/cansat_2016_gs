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
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();           
            dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtLogDirectoryPath.Text = folderBrowserDialog1.SelectedPath;
            }
               
        
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
    }
}
