namespace TienlenVer_1
{
    partial class frmPlayerInfo
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
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblWintimes = new System.Windows.Forms.Label();
            this.lblLosetime = new System.Windows.Forms.Label();
            this.lblWinNum = new System.Windows.Forms.Label();
            this.lblLoseNum = new System.Windows.Forms.Label();
            this.tmrRight = new System.Windows.Forms.Timer(this.components);
            this.tmrLeft = new System.Windows.Forms.Timer(this.components);
            this.tmrDesOpacity = new System.Windows.Forms.Timer(this.components);
            this.pbxAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPlayerName.Location = new System.Drawing.Point(12, 88);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(130, 20);
            this.lblPlayerName.TabIndex = 1;
            this.lblPlayerName.Text = "Player Name";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWintimes
            // 
            this.lblWintimes.AutoSize = true;
            this.lblWintimes.BackColor = System.Drawing.Color.Transparent;
            this.lblWintimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWintimes.ForeColor = System.Drawing.Color.Crimson;
            this.lblWintimes.Location = new System.Drawing.Point(54, 112);
            this.lblWintimes.Name = "lblWintimes";
            this.lblWintimes.Size = new System.Drawing.Size(40, 17);
            this.lblWintimes.TabIndex = 2;
            this.lblWintimes.Text = "Win:";
            // 
            // lblLosetime
            // 
            this.lblLosetime.AutoSize = true;
            this.lblLosetime.BackColor = System.Drawing.Color.Transparent;
            this.lblLosetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLosetime.ForeColor = System.Drawing.Color.Navy;
            this.lblLosetime.Location = new System.Drawing.Point(46, 128);
            this.lblLosetime.Name = "lblLosetime";
            this.lblLosetime.Size = new System.Drawing.Size(48, 17);
            this.lblLosetime.TabIndex = 3;
            this.lblLosetime.Text = "Lose:";
            // 
            // lblWinNum
            // 
            this.lblWinNum.AutoSize = true;
            this.lblWinNum.BackColor = System.Drawing.Color.Transparent;
            this.lblWinNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinNum.ForeColor = System.Drawing.Color.Crimson;
            this.lblWinNum.Location = new System.Drawing.Point(91, 112);
            this.lblWinNum.Name = "lblWinNum";
            this.lblWinNum.Size = new System.Drawing.Size(17, 17);
            this.lblWinNum.TabIndex = 4;
            this.lblWinNum.Text = "0";
            // 
            // lblLoseNum
            // 
            this.lblLoseNum.AutoSize = true;
            this.lblLoseNum.BackColor = System.Drawing.Color.Transparent;
            this.lblLoseNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoseNum.ForeColor = System.Drawing.Color.Navy;
            this.lblLoseNum.Location = new System.Drawing.Point(91, 129);
            this.lblLoseNum.Name = "lblLoseNum";
            this.lblLoseNum.Size = new System.Drawing.Size(17, 17);
            this.lblLoseNum.TabIndex = 5;
            this.lblLoseNum.Text = "0";
            // 
            // tmrRight
            // 
            this.tmrRight.Interval = 1;
            this.tmrRight.Tick += new System.EventHandler(this.tmrRight_Tick);
            // 
            // tmrLeft
            // 
            this.tmrLeft.Interval = 1;
            this.tmrLeft.Tick += new System.EventHandler(this.tmrLeft_Tick);
            // 
            // tmrDesOpacity
            // 
            this.tmrDesOpacity.Interval = 5;
            this.tmrDesOpacity.Tick += new System.EventHandler(this.tmrOpacity_Tick);
            // 
            // pbxAvatar
            // 
            this.pbxAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxAvatar.Location = new System.Drawing.Point(44, 11);
            this.pbxAvatar.Name = "pbxAvatar";
            this.pbxAvatar.Size = new System.Drawing.Size(70, 70);
            this.pbxAvatar.TabIndex = 0;
            this.pbxAvatar.TabStop = false;
            // 
            // frmPlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TienlenVer_1.Properties.Resources.PlayerInfo;
            this.ClientSize = new System.Drawing.Size(154, 154);
            this.Controls.Add(this.lblLoseNum);
            this.Controls.Add(this.lblWinNum);
            this.Controls.Add(this.lblLosetime);
            this.Controls.Add(this.lblWintimes);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.pbxAvatar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPlayerInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_Player_Info";
            this.Load += new System.EventHandler(this.Form_Player_Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbxAvatar;
        public System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblWintimes;
        private System.Windows.Forms.Label lblLosetime;
        public System.Windows.Forms.Label lblWinNum;
        public System.Windows.Forms.Label lblLoseNum;
        private System.Windows.Forms.Timer tmrRight;
        private System.Windows.Forms.Timer tmrLeft;
        public System.Windows.Forms.Timer tmrDesOpacity;
    }
}