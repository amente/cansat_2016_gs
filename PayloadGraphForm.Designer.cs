namespace CanSatGroundStation
{
    partial class PayloadGraphForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTmp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtgTemp = new CanSatGroundStation.RealTimeGraph();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAlt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtgAlt = new CanSatGroundStation.RealTimeGraph();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblVolt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtgBat = new CanSatGroundStation.RealTimeGraph();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblLux = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtgLux = new CanSatGroundStation.RealTimeGraph();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 17);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblTmp);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rtgTemp);
            this.panel2.Location = new System.Drawing.Point(443, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 166);
            this.panel2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.GreenYellow;
            this.label8.Location = new System.Drawing.Point(280, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 26);
            this.label8.TabIndex = 3;
            this.label8.Text = "°c";
            // 
            // lblTmp
            // 
            this.lblTmp.AutoSize = true;
            this.lblTmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTmp.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblTmp.Location = new System.Drawing.Point(223, 7);
            this.lblTmp.Name = "lblTmp";
            this.lblTmp.Size = new System.Drawing.Size(60, 26);
            this.lblTmp.TabIndex = 2;
            this.lblTmp.Text = "00.0 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(91, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Temperature ";
            // 
            // rtgTemp
            // 
            this.rtgTemp.BackColor = System.Drawing.Color.Black;
            this.rtgTemp.ForeColor = System.Drawing.Color.White;
            this.rtgTemp.Location = new System.Drawing.Point(19, 30);
            this.rtgTemp.Name = "rtgTemp";
            this.rtgTemp.numXLables = 4;
            this.rtgTemp.numYLables = 5;
            this.rtgTemp.Size = new System.Drawing.Size(317, 121);
            this.rtgTemp.TabIndex = 0;
            this.rtgTemp.YMaximum = 100D;
            this.rtgTemp.YMinimum = 0D;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblAlt);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.rtgAlt);
            this.panel3.Location = new System.Drawing.Point(15, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(411, 464);
            this.panel3.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.GreenYellow;
            this.label9.Location = new System.Drawing.Point(283, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 26);
            this.label9.TabIndex = 4;
            this.label9.Text = "m";
            // 
            // lblAlt
            // 
            this.lblAlt.AutoSize = true;
            this.lblAlt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlt.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblAlt.Location = new System.Drawing.Point(214, 5);
            this.lblAlt.Name = "lblAlt";
            this.lblAlt.Size = new System.Drawing.Size(66, 26);
            this.lblAlt.TabIndex = 3;
            this.lblAlt.Text = "000.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(110, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Altitude";
            // 
            // rtgAlt
            // 
            this.rtgAlt.BackColor = System.Drawing.Color.Black;
            this.rtgAlt.ForeColor = System.Drawing.Color.White;
            this.rtgAlt.Location = new System.Drawing.Point(0, 30);
            this.rtgAlt.Name = "rtgAlt";
            this.rtgAlt.numXLables = 4;
            this.rtgAlt.numYLables = 11;
            this.rtgAlt.Size = new System.Drawing.Size(411, 434);
            this.rtgAlt.TabIndex = 1;
            this.rtgAlt.YMaximum = 1000D;
            this.rtgAlt.YMinimum = 0D;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.lblVolt);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.rtgBat);
            this.panel4.Location = new System.Drawing.Point(443, 171);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(338, 145);
            this.panel4.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.GreenYellow;
            this.label12.Location = new System.Drawing.Point(256, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 26);
            this.label12.TabIndex = 6;
            this.label12.Text = "mv";
            // 
            // lblVolt
            // 
            this.lblVolt.AutoSize = true;
            this.lblVolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolt.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblVolt.Location = new System.Drawing.Point(198, 9);
            this.lblVolt.Name = "lblVolt";
            this.lblVolt.Size = new System.Drawing.Size(60, 26);
            this.lblVolt.TabIndex = 5;
            this.lblVolt.Text = "0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(73, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Source Voltage";
            // 
            // rtgBat
            // 
            this.rtgBat.BackColor = System.Drawing.Color.Black;
            this.rtgBat.ForeColor = System.Drawing.Color.White;
            this.rtgBat.Location = new System.Drawing.Point(12, 29);
            this.rtgBat.Name = "rtgBat";
            this.rtgBat.numXLables = 4;
            this.rtgBat.numYLables = 5;
            this.rtgBat.Size = new System.Drawing.Size(324, 115);
            this.rtgBat.TabIndex = 1;
            this.rtgBat.YMaximum = 10000D;
            this.rtgBat.YMinimum = 0D;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.lblLux);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.rtgLux);
            this.panel5.Location = new System.Drawing.Point(443, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(338, 142);
            this.panel5.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.GreenYellow;
            this.label10.Location = new System.Drawing.Point(244, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 26);
            this.label10.TabIndex = 5;
            this.label10.Text = "mw/m^2";
            // 
            // lblLux
            // 
            this.lblLux.AutoSize = true;
            this.lblLux.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLux.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblLux.Location = new System.Drawing.Point(190, 7);
            this.lblLux.Name = "lblLux";
            this.lblLux.Size = new System.Drawing.Size(60, 26);
            this.lblLux.TabIndex = 4;
            this.lblLux.Text = "0000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(72, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Light Intensity ";
            // 
            // rtgLux
            // 
            this.rtgLux.BackColor = System.Drawing.Color.Black;
            this.rtgLux.ForeColor = System.Drawing.Color.White;
            this.rtgLux.Location = new System.Drawing.Point(19, 29);
            this.rtgLux.Name = "rtgLux";
            this.rtgLux.numXLables = 4;
            this.rtgLux.numYLables = 5;
            this.rtgLux.Size = new System.Drawing.Size(315, 110);
            this.rtgLux.TabIndex = 2;
            this.rtgLux.YMaximum = 5000D;
            this.rtgLux.YMinimum = 0D;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel6.Location = new System.Drawing.Point(-1, 565);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(750, 13);
            this.panel6.TabIndex = 5;
            // 
            // PayloadGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(793, 496);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PayloadGraphForm";
            this.Text = "Payload Plot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataGraphForm_FormClosing);
            this.Load += new System.EventHandler(this.PayloadGraphForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private RealTimeGraph rtgTemp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private RealTimeGraph rtgAlt;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private RealTimeGraph rtgBat;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private RealTimeGraph rtgLux;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTmp;
        private System.Windows.Forms.Label lblAlt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblVolt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblLux;

    }
}