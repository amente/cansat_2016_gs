namespace CanSatGroundStation
{
    partial class GroundStationControl
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
            this.components = new System.ComponentModel.Container();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.lblMissionTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.btnTelemetry = new System.Windows.Forms.Button();
            this.btnGraphs = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stsStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMissionTime,
            this.lblState});
            this.stsStatus.Location = new System.Drawing.Point(0, 572);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(858, 24);
            this.stsStatus.TabIndex = 2;
            this.stsStatus.Text = "statusStrip1";
            // 
            // lblMissionTime
            // 
            this.lblMissionTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblMissionTime.Name = "lblMissionTime";
            this.lblMissionTime.Size = new System.Drawing.Size(136, 19);
            this.lblMissionTime.Text = "MISSION TIME: 00:00:00";
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(36, 19);
            this.lblState.Text = "State:";
            // 
            // mnuMenu
            // 
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(858, 24);
            this.mnuMenu.TabIndex = 4;
            // 
            // btnTelemetry
            // 
            this.btnTelemetry.Location = new System.Drawing.Point(12, -1);
            this.btnTelemetry.Name = "btnTelemetry";
            this.btnTelemetry.Size = new System.Drawing.Size(129, 24);
            this.btnTelemetry.TabIndex = 6;
            this.btnTelemetry.Text = "Command Interface";
            this.btnTelemetry.UseVisualStyleBackColor = true;
            this.btnTelemetry.Click += new System.EventHandler(this.btnTelemetry_Click);
            // 
            // btnGraphs
            // 
            this.btnGraphs.Location = new System.Drawing.Point(192, -1);
            this.btnGraphs.Name = "btnGraphs";
            this.btnGraphs.Size = new System.Drawing.Size(129, 24);
            this.btnGraphs.TabIndex = 7;
            this.btnGraphs.Text = "Telemetry Charts";
            this.btnGraphs.UseVisualStyleBackColor = true;
            this.btnGraphs.Click += new System.EventHandler(this.btnGraphs_Click);
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(379, 1);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(112, 24);
            this.btnTable.TabIndex = 8;
            this.btnTable.Text = "Telemetry Table";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(705, -1);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(122, 25);
            this.btnConfig.TabIndex = 10;
            this.btnConfig.Text = "Configure";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(537, 0);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(115, 25);
            this.btnStatus.TabIndex = 12;
            this.btnStatus.Text = "Mission Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(668, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Remaining Picture Bytes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(799, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "0";
            // 
            // GroundStationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(858, 596);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.btnGraphs);
            this.Controls.Add(this.btnTelemetry);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.mnuMenu);
            this.ForeColor = System.Drawing.Color.Black;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMenu;
            this.Name = "GroundStationControl";
            this.Text = "Cansat Ground Station 2016 | Team RavenKings";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblMissionTime;
        private System.Windows.Forms.ToolStripStatusLabel lblState;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.Button btnTelemetry;
        private System.Windows.Forms.Button btnGraphs;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

