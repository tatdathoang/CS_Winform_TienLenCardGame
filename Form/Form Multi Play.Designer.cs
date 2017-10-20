namespace TienlenVer_1
{
    partial class frmMultiPlay
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.gbxServInfo = new System.Windows.Forms.GroupBox();
            this.txtIP4 = new System.Windows.Forms.MaskedTextBox();
            this.txtIP3 = new System.Windows.Forms.MaskedTextBox();
            this.txtIP2 = new System.Windows.Forms.MaskedTextBox();
            this.txtIP1 = new System.Windows.Forms.MaskedTextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cmdDisconnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdDeal = new System.Windows.Forms.Button();
            this.cmdSkip = new System.Windows.Forms.Button();
            this.cmdUnChose = new System.Windows.Forms.Button();
            this.cmdPlay = new System.Windows.Forms.Button();
            this.pbxOpponent = new System.Windows.Forms.PictureBox();
            this.tmrPlayer = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrDownRight = new System.Windows.Forms.Timer(this.components);
            this.pbrRemainTime = new System.Windows.Forms.ProgressBar();
            this.pbxClock = new System.Windows.Forms.PictureBox();
            this.gbxServInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOpponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(221, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(290, 11);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(90, 23);
            this.cmdConnect.TabIndex = 5;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // gbxServInfo
            // 
            this.gbxServInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbxServInfo.Controls.Add(this.txtIP4);
            this.gbxServInfo.Controls.Add(this.txtIP3);
            this.gbxServInfo.Controls.Add(this.txtIP2);
            this.gbxServInfo.Controls.Add(this.txtIP1);
            this.gbxServInfo.Controls.Add(this.txtPort);
            this.gbxServInfo.Controls.Add(this.cmdDisconnect);
            this.gbxServInfo.Controls.Add(this.label1);
            this.gbxServInfo.Controls.Add(this.cmdConnect);
            this.gbxServInfo.Controls.Add(this.label2);
            this.gbxServInfo.Controls.Add(this.label7);
            this.gbxServInfo.Controls.Add(this.label6);
            this.gbxServInfo.Controls.Add(this.label5);
            this.gbxServInfo.Location = new System.Drawing.Point(12, 12);
            this.gbxServInfo.Name = "gbxServInfo";
            this.gbxServInfo.Size = new System.Drawing.Size(464, 45);
            this.gbxServInfo.TabIndex = 0;
            this.gbxServInfo.TabStop = false;
            this.gbxServInfo.Text = "Server Info";
            // 
            // txtIP4
            // 
            this.txtIP4.Location = new System.Drawing.Point(185, 13);
            this.txtIP4.Mask = "000";
            this.txtIP4.Name = "txtIP4";
            this.txtIP4.PromptChar = ' ';
            this.txtIP4.Size = new System.Drawing.Size(25, 20);
            this.txtIP4.TabIndex = 3;
            this.txtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP3
            // 
            this.txtIP3.Location = new System.Drawing.Point(151, 13);
            this.txtIP3.Mask = "000";
            this.txtIP3.Name = "txtIP3";
            this.txtIP3.PromptChar = ' ';
            this.txtIP3.Size = new System.Drawing.Size(25, 20);
            this.txtIP3.TabIndex = 2;
            this.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIP3.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtIP3_MaskInputRejected);
            // 
            // txtIP2
            // 
            this.txtIP2.Location = new System.Drawing.Point(119, 13);
            this.txtIP2.Mask = "000";
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.PromptChar = ' ';
            this.txtIP2.Size = new System.Drawing.Size(25, 20);
            this.txtIP2.TabIndex = 1;
            this.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIP2.TextChanged += new System.EventHandler(this.txtIP2_TextChanged);
            // 
            // txtIP1
            // 
            this.txtIP1.Location = new System.Drawing.Point(87, 13);
            this.txtIP1.Mask = "000";
            this.txtIP1.Name = "txtIP1";
            this.txtIP1.PromptChar = ' ';
            this.txtIP1.Size = new System.Drawing.Size(25, 20);
            this.txtIP1.TabIndex = 0;
            this.txtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIP1.TextChanged += new System.EventHandler(this.txtIP1_TextChanged);
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(256, 13);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(28, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "501";
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.Enabled = false;
            this.cmdDisconnect.Location = new System.Drawing.Point(386, 11);
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(70, 23);
            this.cmdDisconnect.TabIndex = 6;
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.UseVisualStyleBackColor = true;
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(175, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(142, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(110, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = ".";
            // 
            // cmdDeal
            // 
            this.cmdDeal.Location = new System.Drawing.Point(355, 657);
            this.cmdDeal.Name = "cmdDeal";
            this.cmdDeal.Size = new System.Drawing.Size(75, 23);
            this.cmdDeal.TabIndex = 4;
            this.cmdDeal.Text = "Deal";
            this.cmdDeal.UseVisualStyleBackColor = true;
            this.cmdDeal.Visible = false;
            this.cmdDeal.Click += new System.EventHandler(this.cmdDeal_Click);
            // 
            // cmdSkip
            // 
            this.cmdSkip.Enabled = false;
            this.cmdSkip.Location = new System.Drawing.Point(274, 657);
            this.cmdSkip.Name = "cmdSkip";
            this.cmdSkip.Size = new System.Drawing.Size(75, 23);
            this.cmdSkip.TabIndex = 3;
            this.cmdSkip.Text = "Skip";
            this.cmdSkip.UseVisualStyleBackColor = true;
            this.cmdSkip.Visible = false;
            this.cmdSkip.Click += new System.EventHandler(this.cmdSkip_Click);
            // 
            // cmdUnChose
            // 
            this.cmdUnChose.Enabled = false;
            this.cmdUnChose.Location = new System.Drawing.Point(193, 657);
            this.cmdUnChose.Name = "cmdUnChose";
            this.cmdUnChose.Size = new System.Drawing.Size(75, 23);
            this.cmdUnChose.TabIndex = 2;
            this.cmdUnChose.Text = "Unchose All";
            this.cmdUnChose.UseVisualStyleBackColor = true;
            this.cmdUnChose.Visible = false;
            this.cmdUnChose.Click += new System.EventHandler(this.cmdUnChose_Click);
            // 
            // cmdPlay
            // 
            this.cmdPlay.Enabled = false;
            this.cmdPlay.Location = new System.Drawing.Point(112, 657);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(75, 23);
            this.cmdPlay.TabIndex = 1;
            this.cmdPlay.Text = "Play!";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Visible = false;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // pbxOpponent
            // 
            this.pbxOpponent.Image = global::TienlenVer_1.Properties.Resources.Opponent_Cards;
            this.pbxOpponent.Location = new System.Drawing.Point(140, 63);
            this.pbxOpponent.Name = "pbxOpponent";
            this.pbxOpponent.Size = new System.Drawing.Size(209, 185);
            this.pbxOpponent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxOpponent.TabIndex = 12;
            this.pbxOpponent.TabStop = false;
            this.pbxOpponent.Visible = false;
            // 
            // tmrPlayer
            // 
            this.tmrPlayer.Interval = 155;
            this.tmrPlayer.Tick += new System.EventHandler(this.tmrPlayer_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblStatus.Location = new System.Drawing.Point(8, 631);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 20);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status lable";
            this.lblStatus.Visible = false;
            // 
            // tmrDownRight
            // 
            this.tmrDownRight.Interval = 1;
            this.tmrDownRight.Tick += new System.EventHandler(this.tmrDownRight_Tick);
            // 
            // pbrRemainTime
            // 
            this.pbrRemainTime.Location = new System.Drawing.Point(215, 636);
            this.pbrRemainTime.Name = "pbrRemainTime";
            this.pbrRemainTime.Size = new System.Drawing.Size(112, 15);
            this.pbrRemainTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbrRemainTime.TabIndex = 16;
            this.pbrRemainTime.Value = 100;
            this.pbrRemainTime.Visible = false;
            // 
            // pbxClock
            // 
            this.pbxClock.BackColor = System.Drawing.Color.Transparent;
            this.pbxClock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxClock.Image = global::TienlenVer_1.Properties.Resources.Clock;
            this.pbxClock.Location = new System.Drawing.Point(333, 631);
            this.pbxClock.Name = "pbxClock";
            this.pbxClock.Size = new System.Drawing.Size(24, 24);
            this.pbxClock.TabIndex = 17;
            this.pbxClock.TabStop = false;
            this.pbxClock.Visible = false;
            // 
            // frmMultiPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TienlenVer_1.Properties.Resources.MultiplayTable;
            this.ClientSize = new System.Drawing.Size(488, 692);
            this.Controls.Add(this.pbxClock);
            this.Controls.Add(this.pbrRemainTime);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbxOpponent);
            this.Controls.Add(this.cmdDeal);
            this.Controls.Add(this.cmdSkip);
            this.Controls.Add(this.cmdUnChose);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.gbxServInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMultiPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tien Len - MultiPlay";
            this.Load += new System.EventHandler(this.frmMultiPlay_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMultiPlay_FormClosing);
            this.LocationChanged += new System.EventHandler(this.frmMultiPlay_LocationChanged);
            this.gbxServInfo.ResumeLayout(false);
            this.gbxServInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOpponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.GroupBox gbxServInfo;
        private System.Windows.Forms.Button cmdDisconnect;
        private System.Windows.Forms.Button cmdDeal;
        private System.Windows.Forms.Button cmdSkip;
        private System.Windows.Forms.Button cmdUnChose;
        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.PictureBox pbxOpponent;
        private System.Windows.Forms.Timer tmrPlayer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmrDownRight;
        private System.Windows.Forms.ProgressBar pbrRemainTime;
        private System.Windows.Forms.PictureBox pbxClock;
        private System.Windows.Forms.MaskedTextBox txtIP1;
        private System.Windows.Forms.MaskedTextBox txtIP3;
        private System.Windows.Forms.MaskedTextBox txtIP2;
        private System.Windows.Forms.MaskedTextBox txtIP4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}