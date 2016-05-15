namespace CanSatGroundStation
{
    partial class StatusForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPaloadAlt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPayloadTime = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPayloadVolt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPayloadTmp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ALT";
            // 
            // lblPaloadAlt
            // 
            this.lblPaloadAlt.AutoSize = true;
            this.lblPaloadAlt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaloadAlt.Location = new System.Drawing.Point(173, 49);
            this.lblPaloadAlt.Name = "lblPaloadAlt";
            this.lblPaloadAlt.Size = new System.Drawing.Size(49, 20);
            this.lblPaloadAlt.TabIndex = 1;
            this.lblPaloadAlt.Text = "000.0";
            this.lblPaloadAlt.Click += new System.EventHandler(this.lblPaloadAlt_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.lblPayloadTime);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblPayloadVolt);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblPayloadTmp);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblPaloadAlt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.Color.GreenYellow;
            this.panel2.Location = new System.Drawing.Point(5, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 232);
            this.panel2.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(340, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 20);
            this.label18.TabIndex = 23;
            this.label18.Text = "°c";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(468, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 20);
            this.label17.TabIndex = 22;
            this.label17.Text = "sec";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(228, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 20);
            this.label16.TabIndex = 21;
            this.label16.Text = "m";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(71, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 20);
            this.label15.TabIndex = 20;
            this.label15.Text = "mV";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // lblPayloadTime
            // 
            this.lblPayloadTime.AutoSize = true;
            this.lblPayloadTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayloadTime.Location = new System.Drawing.Point(417, 49);
            this.lblPayloadTime.Name = "lblPayloadTime";
            this.lblPayloadTime.Size = new System.Drawing.Size(45, 20);
            this.lblPayloadTime.TabIndex = 19;
            this.lblPayloadTime.Text = "0000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(426, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "TIME";
            // 
            // lblPayloadVolt
            // 
            this.lblPayloadVolt.AutoSize = true;
            this.lblPayloadVolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayloadVolt.Location = new System.Drawing.Point(20, 49);
            this.lblPayloadVolt.Name = "lblPayloadVolt";
            this.lblPayloadVolt.Size = new System.Drawing.Size(45, 20);
            this.lblPayloadVolt.TabIndex = 17;
            this.lblPayloadVolt.Text = "0000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "SOURCE VOLT";
            // 
            // lblPayloadTmp
            // 
            this.lblPayloadTmp.AutoSize = true;
            this.lblPayloadTmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayloadTmp.Location = new System.Drawing.Point(294, 49);
            this.lblPayloadTmp.Name = "lblPayloadTmp";
            this.lblPayloadTmp.Size = new System.Drawing.Size(40, 20);
            this.lblPayloadTmp.TabIndex = 13;
            this.lblPayloadTmp.Text = "00.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "TEMP";
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 251);
            this.Controls.Add(this.panel2);
            this.Name = "StatusForm";
            this.Text = "CanSat Status ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatusForm_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPaloadAlt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPayloadTmp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPayloadTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblPayloadVolt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
    }
}