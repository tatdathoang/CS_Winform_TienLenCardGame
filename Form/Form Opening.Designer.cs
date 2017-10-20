namespace TienlenVer_1
{
    partial class frmOpen
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
            this.cmdMultiplay = new System.Windows.Forms.Button();
            this.cmdOption = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.tmrRightUp = new System.Windows.Forms.Timer(this.components);
            this.cmdPractice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdMultiplay
            // 
            this.cmdMultiplay.BackgroundImage = global::TienlenVer_1.Properties.Resources.cmd;
            this.cmdMultiplay.Location = new System.Drawing.Point(72, 98);
            this.cmdMultiplay.Name = "cmdMultiplay";
            this.cmdMultiplay.Size = new System.Drawing.Size(77, 34);
            this.cmdMultiplay.TabIndex = 1;
            this.cmdMultiplay.Text = "Multiplay";
            this.cmdMultiplay.UseVisualStyleBackColor = true;
            this.cmdMultiplay.Click += new System.EventHandler(this.cmdMultiplay_Click);
            // 
            // cmdOption
            // 
            this.cmdOption.BackgroundImage = global::TienlenVer_1.Properties.Resources.cmd;
            this.cmdOption.Location = new System.Drawing.Point(72, 178);
            this.cmdOption.Name = "cmdOption";
            this.cmdOption.Size = new System.Drawing.Size(77, 34);
            this.cmdOption.TabIndex = 2;
            this.cmdOption.Text = "Option";
            this.cmdOption.UseVisualStyleBackColor = true;
            this.cmdOption.Click += new System.EventHandler(this.cmdOption_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.BackgroundImage = global::TienlenVer_1.Properties.Resources.cmd;
            this.cmdExit.Location = new System.Drawing.Point(72, 258);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(77, 34);
            this.cmdExit.TabIndex = 3;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // tmrRightUp
            // 
            this.tmrRightUp.Interval = 1;
            this.tmrRightUp.Tick += new System.EventHandler(this.tmrRightUp_Tick);
            // 
            // cmdPractice
            // 
            this.cmdPractice.BackgroundImage = global::TienlenVer_1.Properties.Resources.cmd;
            this.cmdPractice.Location = new System.Drawing.Point(72, 18);
            this.cmdPractice.Name = "cmdPractice";
            this.cmdPractice.Size = new System.Drawing.Size(77, 34);
            this.cmdPractice.TabIndex = 0;
            this.cmdPractice.Text = "Practice";
            this.cmdPractice.UseVisualStyleBackColor = true;
            this.cmdPractice.Click += new System.EventHandler(this.cmdPractice_Click);
            // 
            // frmOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TienlenVer_1.Properties.Resources.Open;
            this.ClientSize = new System.Drawing.Size(161, 312);
            this.Controls.Add(this.cmdPractice);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdOption);
            this.Controls.Add(this.cmdMultiplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Open";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdMultiplay;
        private System.Windows.Forms.Button cmdOption;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Timer tmrRightUp;
        private System.Windows.Forms.Button cmdPractice;

    }
}