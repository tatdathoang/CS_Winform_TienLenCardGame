namespace TienlenVer_1
{
    partial class frmSinglePlay
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
            this.cmdPlay = new System.Windows.Forms.Button();
            this.cmdUnChose = new System.Windows.Forms.Button();
            this.cmdSkip = new System.Windows.Forms.Button();
            this.tmrPlayer = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmdDeal = new System.Windows.Forms.Button();
            this.tmrDownRight = new System.Windows.Forms.Timer(this.components);
            this.pbxOpponent = new System.Windows.Forms.PictureBox();
            this.pbrRemainTime = new System.Windows.Forms.ProgressBar();
            this.tmrCompDelay = new System.Windows.Forms.Timer(this.components);
            this.pbxClock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOpponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClock)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdPlay
            // 
            this.cmdPlay.Enabled = false;
            this.cmdPlay.Location = new System.Drawing.Point(126, 600);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(75, 23);
            this.cmdPlay.TabIndex = 1;
            this.cmdPlay.Text = "Play!";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Visible = false;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // cmdUnChose
            // 
            this.cmdUnChose.Enabled = false;
            this.cmdUnChose.Location = new System.Drawing.Point(207, 600);
            this.cmdUnChose.Name = "cmdUnChose";
            this.cmdUnChose.Size = new System.Drawing.Size(75, 23);
            this.cmdUnChose.TabIndex = 2;
            this.cmdUnChose.Text = "Unchose All";
            this.cmdUnChose.UseVisualStyleBackColor = true;
            this.cmdUnChose.Visible = false;
            this.cmdUnChose.Click += new System.EventHandler(this.cmdUnChose_Click);
            // 
            // cmdSkip
            // 
            this.cmdSkip.Enabled = false;
            this.cmdSkip.Location = new System.Drawing.Point(288, 600);
            this.cmdSkip.Name = "cmdSkip";
            this.cmdSkip.Size = new System.Drawing.Size(75, 23);
            this.cmdSkip.TabIndex = 3;
            this.cmdSkip.Text = "Skip";
            this.cmdSkip.UseVisualStyleBackColor = true;
            this.cmdSkip.Visible = false;
            this.cmdSkip.Click += new System.EventHandler(this.cmdSkip_Click);
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
            this.lblStatus.Location = new System.Drawing.Point(12, 577);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(150, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Please click Deal!";
            // 
            // cmdDeal
            // 
            this.cmdDeal.Location = new System.Drawing.Point(369, 600);
            this.cmdDeal.Name = "cmdDeal";
            this.cmdDeal.Size = new System.Drawing.Size(75, 23);
            this.cmdDeal.TabIndex = 0;
            this.cmdDeal.Text = "Deal";
            this.cmdDeal.UseVisualStyleBackColor = true;
            this.cmdDeal.Click += new System.EventHandler(this.cmdDeal_Click);
            // 
            // tmrDownRight
            // 
            this.tmrDownRight.Interval = 1;
            this.tmrDownRight.Tick += new System.EventHandler(this.tmrDownRight_Tick);
            // 
            // pbxOpponent
            // 
            this.pbxOpponent.Image = global::TienlenVer_1.Properties.Resources.Opponent_Cards;
            this.pbxOpponent.Location = new System.Drawing.Point(145, 20);
            this.pbxOpponent.Name = "pbxOpponent";
            this.pbxOpponent.Size = new System.Drawing.Size(209, 185);
            this.pbxOpponent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxOpponent.TabIndex = 5;
            this.pbxOpponent.TabStop = false;
            this.pbxOpponent.Visible = false;
            // 
            // pbrRemainTime
            // 
            this.pbrRemainTime.Location = new System.Drawing.Point(188, 579);
            this.pbrRemainTime.Name = "pbrRemainTime";
            this.pbrRemainTime.Size = new System.Drawing.Size(112, 15);
            this.pbrRemainTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbrRemainTime.TabIndex = 8;
            this.pbrRemainTime.Value = 100;
            this.pbrRemainTime.Visible = false;
            // 
            // tmrCompDelay
            // 
            this.tmrCompDelay.Interval = 500;
            this.tmrCompDelay.Tick += new System.EventHandler(this.tmrCompDelay_Tick);
            // 
            // pbxClock
            // 
            this.pbxClock.BackColor = System.Drawing.Color.Transparent;
            this.pbxClock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxClock.Image = global::TienlenVer_1.Properties.Resources.Clock;
            this.pbxClock.Location = new System.Drawing.Point(306, 573);
            this.pbxClock.Name = "pbxClock";
            this.pbxClock.Size = new System.Drawing.Size(24, 24);
            this.pbxClock.TabIndex = 9;
            this.pbxClock.TabStop = false;
            this.pbxClock.Visible = false;
            // 
            // frmSinglePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TienlenVer_1.Properties.Resources.SingleplayTable;
            this.ClientSize = new System.Drawing.Size(488, 635);
            this.Controls.Add(this.pbxClock);
            this.Controls.Add(this.pbrRemainTime);
            this.Controls.Add(this.cmdDeal);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbxOpponent);
            this.Controls.Add(this.cmdSkip);
            this.Controls.Add(this.cmdUnChose);
            this.Controls.Add(this.cmdPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSinglePlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tien Len - Practice";
            this.Load += new System.EventHandler(this.frmSinglePlay_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSinglePlay_FormClosing);
            this.LocationChanged += new System.EventHandler(this.frmSinglePlay_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbxOpponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.Button cmdUnChose;
        private System.Windows.Forms.Button cmdSkip;
        private System.Windows.Forms.Timer tmrPlayer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button cmdDeal;
        private System.Windows.Forms.PictureBox pbxOpponent;
        private System.Windows.Forms.Timer tmrDownRight;
        private System.Windows.Forms.ProgressBar pbrRemainTime;
        private System.Windows.Forms.Timer tmrCompDelay;
        private System.Windows.Forms.PictureBox pbxClock;

    }
}