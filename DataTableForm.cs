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
    public partial class DataTableForm : Form
    {
        DataTable table = new DataTable();
        

        //<TEAM ID>,<PACKET COUNT>,<MISSION_TIME>,<ALT SENSOR>,<TEMP>,<VOLTAGE>,<LUX>
        public DataTableForm()
        {
            InitializeComponent();         

            table.Columns.Add("TEAM ID");
            table.Columns.Add("PACKET COUNT");
            table.Columns.Add("MISSION_TIME");
            table.Columns.Add("ALT SENSOR");
            table.Columns.Add("TEMPURATURE");
            table.Columns.Add("SOURCE VOLTAGE");
            table.Columns.Add("LUX");           
        }

        private void DataTableForm_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = table;
            //dgvData.FirstDisplayedScrollingRowIndex = (dgvData.RowCount>0)? dgvData.RowCount-1: 0;
        }

        
        public void AddData(object[] tableData)
        {
            if (table.Columns.Count != tableData.Length)
            {
                return;
            }

            table.Rows.Add(tableData);
            // Invoke an anonymous method on the thread of the form.
            this.Invoke((MethodInvoker) delegate
            {
                dgvData.Refresh();
                //dgvData.FirstDisplayedScrollingRowIndex = (dgvData.RowCount > 1) ? dgvData.RowCount - 1 : 0;
            });
        }

        private void DataTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }        

    }
}
