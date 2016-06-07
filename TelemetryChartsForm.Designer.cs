namespace CanSatGroundStation
{
    partial class TelemetryChartsForm
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
            this.lblTemperature = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtgTemperature = new CanSatGroundStation.RealTimeGraph();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtgAltitude = new CanSatGroundStation.RealTimeGraph();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSourceVoltage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtgSourceVoltage = new CanSatGroundStation.RealTimeGraph();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAirSpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtgAirSpeed = new CanSatGroundStation.RealTimeGraph();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPressure = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rtgPressure = new CanSatGroundStation.RealTimeGraph();
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
            this.panel2.Controls.Add(this.lblTemperature);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rtgTemperature);
            this.panel2.Location = new System.Drawing.Point(443, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 157);
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
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblTemperature.Location = new System.Drawing.Point(223, 7);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(60, 26);
            this.lblTemperature.TabIndex = 2;
            this.lblTemperature.Text = "00.0 ";
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
            // rtgTemperature
            // 
            this.rtgTemperature.BackColor = System.Drawing.Color.Black;
            this.rtgTemperature.ForeColor = System.Drawing.Color.White;
            this.rtgTemperature.Location = new System.Drawing.Point(19, 30);
            this.rtgTemperature.Name = "rtgTemperature";
            this.rtgTemperature.numXLables = 4;
            this.rtgTemperature.numYLables = 5;
            this.rtgTemperature.Size = new System.Drawing.Size(317, 121);
            this.rtgTemperature.TabIndex = 0;
            this.rtgTemperature.YMaximum = 100D;
            this.rtgTemperature.YMinimum = 0D;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblAltitude);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.rtgAltitude);
            this.panel3.Location = new System.Drawing.Point(15, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(411, 583);
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
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblAltitude.Location = new System.Drawing.Point(214, 5);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(66, 26);
            this.lblAltitude.TabIndex = 3;
            this.lblAltitude.Text = "000.0";
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
            // rtgAltitude
            // 
            this.rtgAltitude.BackColor = System.Drawing.Color.Black;
            this.rtgAltitude.ForeColor = System.Drawing.Color.White;
            this.rtgAltitude.Location = new System.Drawing.Point(-3, 29);
            this.rtgAltitude.Name = "rtgAltitude";
            this.rtgAltitude.numXLables = 4;
            this.rtgAltitude.numYLables = 11;
            this.rtgAltitude.Size = new System.Drawing.Size(410, 541);
            this.rtgAltitude.TabIndex = 1;
            this.rtgAltitude.YMaximum = 1000D;
            this.rtgAltitude.YMinimum = 0D;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.lblSourceVoltage);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.rtgSourceVoltage);
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
            this.label12.Size = new System.Drawing.Size(23, 26);
            this.label12.TabIndex = 6;
            this.label12.Text = "v";
            // 
            // lblSourceVoltage
            // 
            this.lblSourceVoltage.AutoSize = true;
            this.lblSourceVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceVoltage.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblSourceVoltage.Location = new System.Drawing.Point(214, 9);
            this.lblSourceVoltage.Name = "lblSourceVoltage";
            this.lblSourceVoltage.Size = new System.Drawing.Size(36, 26);
            this.lblSourceVoltage.TabIndex = 5;
            this.lblSourceVoltage.Text = "00";
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
            // rtgSourceVoltage
            // 
            this.rtgSourceVoltage.BackColor = System.Drawing.Color.Black;
            this.rtgSourceVoltage.ForeColor = System.Drawing.Color.White;
            this.rtgSourceVoltage.Location = new System.Drawing.Point(12, 29);
            this.rtgSourceVoltage.Name = "rtgSourceVoltage";
            this.rtgSourceVoltage.numXLables = 4;
            this.rtgSourceVoltage.numYLables = 5;
            this.rtgSourceVoltage.Size = new System.Drawing.Size(324, 115);
            this.rtgSourceVoltage.TabIndex = 1;
            this.rtgSourceVoltage.YMaximum = 10D;
            this.rtgSourceVoltage.YMinimum = -1D;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.lblAirSpeed);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.rtgAirSpeed);
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
            this.label10.Size = new System.Drawing.Size(71, 26);
            this.label10.TabIndex = 5;
            this.label10.Text = "m/sec";
            // 
            // lblAirSpeed
            // 
            this.lblAirSpeed.AutoSize = true;
            this.lblAirSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirSpeed.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblAirSpeed.Location = new System.Drawing.Point(202, 7);
            this.lblAirSpeed.Name = "lblAirSpeed";
            this.lblAirSpeed.Size = new System.Drawing.Size(36, 26);
            this.lblAirSpeed.TabIndex = 4;
            this.lblAirSpeed.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(91, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Air Speed";
            // 
            // rtgAirSpeed
            // 
            this.rtgAirSpeed.BackColor = System.Drawing.Color.Black;
            this.rtgAirSpeed.ForeColor = System.Drawing.Color.White;
            this.rtgAirSpeed.Location = new System.Drawing.Point(19, 29);
            this.rtgAirSpeed.Name = "rtgAirSpeed";
            this.rtgAirSpeed.numXLables = 4;
            this.rtgAirSpeed.numYLables = 5;
            this.rtgAirSpeed.Size = new System.Drawing.Size(315, 110);
            this.rtgAirSpeed.TabIndex = 2;
            this.rtgAirSpeed.YMaximum = 50D;
            this.rtgAirSpeed.YMinimum = 0D;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel6.Location = new System.Drawing.Point(-1, 612);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(794, 13);
            this.panel6.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(534, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Pressure";
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressure.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblPressure.Location = new System.Drawing.Point(633, 481);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(24, 26);
            this.lblPressure.TabIndex = 6;
            this.lblPressure.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.GreenYellow;
            this.label7.Location = new System.Drawing.Point(734, 481);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "pa";
            // 
            // rtgPressure
            // 
            this.rtgPressure.BackColor = System.Drawing.Color.Black;
            this.rtgPressure.ForeColor = System.Drawing.Color.White;
            this.rtgPressure.Location = new System.Drawing.Point(455, 504);
            this.rtgPressure.Name = "rtgPressure";
            this.rtgPressure.numXLables = 4;
            this.rtgPressure.numYLables = 5;
            this.rtgPressure.Size = new System.Drawing.Size(315, 110);
            this.rtgPressure.TabIndex = 6;
            this.rtgPressure.YMaximum = 200000D;
            this.rtgPressure.YMinimum = 0D;
            // 
            // TelemetryChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(793, 626);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPressure);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtgPressure);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TelemetryChartsForm";
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private RealTimeGraph rtgTemperature;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private RealTimeGraph rtgAltitude;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private RealTimeGraph rtgSourceVoltage;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private RealTimeGraph rtgAirSpeed;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSourceVoltage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAirSpeed;
        private RealTimeGraph rtgPressure;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPressure;
        private System.Windows.Forms.Label label7;
    }
}