namespace CanSatGroundStation
{
    partial class DataSimulatorForm
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
            this.numericUpDownTemperature = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownAltitude = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSourceVoltage = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAirspeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSourceVoltage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAirspeed)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownTemperature
            // 
            this.numericUpDownTemperature.Location = new System.Drawing.Point(123, 98);
            this.numericUpDownTemperature.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTemperature.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
            this.numericUpDownTemperature.Name = "numericUpDownTemperature";
            this.numericUpDownTemperature.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownTemperature.TabIndex = 0;
            this.numericUpDownTemperature.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownTemperature.ValueChanged += new System.EventHandler(this.numericUpDownValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Telemetry Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Temperature (celsius)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start Simulation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Altitude (m)";
            // 
            // numericUpDownAltitude
            // 
            this.numericUpDownAltitude.Location = new System.Drawing.Point(123, 136);
            this.numericUpDownAltitude.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownAltitude.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownAltitude.Name = "numericUpDownAltitude";
            this.numericUpDownAltitude.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownAltitude.TabIndex = 5;
            this.numericUpDownAltitude.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownAltitude.ValueChanged += new System.EventHandler(this.numericUpDownValueChanged);
            // 
            // numericUpDownSourceVoltage
            // 
            this.numericUpDownSourceVoltage.DecimalPlaces = 1;
            this.numericUpDownSourceVoltage.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownSourceVoltage.Location = new System.Drawing.Point(123, 173);
            this.numericUpDownSourceVoltage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSourceVoltage.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownSourceVoltage.Name = "numericUpDownSourceVoltage";
            this.numericUpDownSourceVoltage.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownSourceVoltage.TabIndex = 6;
            this.numericUpDownSourceVoltage.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDownSourceVoltage.Value = new decimal(new int[] {
            33,
            0,
            0,
            65536});
            this.numericUpDownSourceVoltage.ValueChanged += new System.EventHandler(this.numericUpDownValueChanged);
            // 
            // numericUpDownAirspeed
            // 
            this.numericUpDownAirspeed.Location = new System.Drawing.Point(123, 211);
            this.numericUpDownAirspeed.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownAirspeed.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
            this.numericUpDownAirspeed.Name = "numericUpDownAirspeed";
            this.numericUpDownAirspeed.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownAirspeed.TabIndex = 7;
            this.numericUpDownAirspeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownAirspeed.ValueChanged += new System.EventHandler(this.numericUpDownValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Source Voltage (mv)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Airspeed (m/s)";
            // 
            // DataSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 669);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownAirspeed);
            this.Controls.Add(this.numericUpDownSourceVoltage);
            this.Controls.Add(this.numericUpDownAltitude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownTemperature);
            this.Name = "DataSimulatorForm";
            this.Text = "DataSimulatorForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSourceVoltage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAirspeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownTemperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownAltitude;
        private System.Windows.Forms.NumericUpDown numericUpDownSourceVoltage;
        private System.Windows.Forms.NumericUpDown numericUpDownAirspeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}