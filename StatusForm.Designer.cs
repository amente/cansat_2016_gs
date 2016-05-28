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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMissionTime = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMissionState = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblMissionState);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblMissionTime);
            this.panel2.Controls.Add(this.label13);
            this.panel2.ForeColor = System.Drawing.Color.GreenYellow;
            this.panel2.Location = new System.Drawing.Point(5, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 162);
            this.panel2.TabIndex = 12;
            // 
            // lblMissionTime
            // 
            this.lblMissionTime.AutoSize = true;
            this.lblMissionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissionTime.Location = new System.Drawing.Point(165, 12);
            this.lblMissionTime.Name = "lblMissionTime";
            this.lblMissionTime.Size = new System.Drawing.Size(71, 20);
            this.lblMissionTime.TabIndex = 19;
            this.lblMissionTime.Text = "00:00:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(20, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "MISSION TIME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "MISSION STATE:";
            // 
            // lblMissionState
            // 
            this.lblMissionState.AutoSize = true;
            this.lblMissionState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissionState.Location = new System.Drawing.Point(165, 46);
            this.lblMissionState.Name = "lblMissionState";
            this.lblMissionState.Size = new System.Drawing.Size(146, 20);
            this.lblMissionState.TabIndex = 22;
            this.lblMissionState.Text = "UNKNOWN STATE";
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 172);
            this.Controls.Add(this.panel2);
            this.Name = "StatusForm";
            this.Text = "CanSat Status ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatusForm_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMissionTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMissionState;
        private System.Windows.Forms.Label label1;
    }
}