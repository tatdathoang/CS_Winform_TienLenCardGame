using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TienlenVer_1
{
    public partial class frmPlayerInfo : Form
    {
        #region [   -   Properties   -   ]

        public int x;
        bool isPlayer = true;
        public string avatarpath, playerName;

        #endregion

        #region [   -   Event   -   ]

        public frmPlayerInfo(bool isPlayer)
        {
            InitializeComponent();
            this.Opacity = 0;
            this.isPlayer = isPlayer;
        }
        
        private void Form_Player_Info_Load(object sender, EventArgs e)
        {
            x = this.Location.X;

            if (isPlayer)
            {
                StreamReader StreamR = new StreamReader(".\\Config.config");
                FileInfo fileInf = new FileInfo(".\\Config.config");
                playerName = StreamR.ReadLine();
                lblPlayerName.Text = playerName;

                Image img;
                avatarpath = StreamR.ReadLine();
                StreamR.Close();

                try
                {
                    img = Image.FromFile(avatarpath);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Your avatar is not found. Default avatar will be replaced instead!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    avatarpath = ".\\Emo\\Avatar\\8.jpg";
                    img = Image.FromFile(avatarpath);

                    StreamWriter StreamW = new StreamWriter(".\\Config.config");
                    StreamW.Write(lblPlayerName.Text + "\r\n");
                    StreamW.Write(avatarpath);
                    StreamW.Close();
                }

                pbxAvatar.BackgroundImage = img;

                StreamR.Close();

                tmrRight.Start();
            }
            else
            {
                 Random a = new Random();
                int b = a.Next(1, 70);
                string c = b.ToString();

                avatarpath = ".\\Emo\\Avatar\\" + c + ".jpg";
                pbxAvatar.BackgroundImage = Image.FromFile(avatarpath);
                tmrLeft.Start();
            }
        }

        private void tmrRight_Tick(object sender, EventArgs e)
        {
            if (this.Location.X + 5 < x + this.Width)
            {
                this.Location = new Point(this.Location.X + 5, this.Location.Y);
                this.Opacity = this.Opacity + 0.02;
            }
            else
            {
                tmrRight.Stop();
                this.Location = new Point(x + this.Width + 5, this.Location.Y);
                this.Opacity = 1;
            }
        }

        private void tmrLeft_Tick(object sender, EventArgs e)
        {
            if (this.Location.X - 5 > x - this.Width)
            {
                this.Location = new Point(this.Location.X - 5, this.Location.Y);
                this.Opacity = this.Opacity + 0.02;
            }
            else
            {
                tmrLeft.Stop();
                this.Location = new Point(x - this.Width - 5, this.Location.Y);
                this.Opacity = 1;
            }
        }

        private void tmrOpacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
                this.Opacity = this.Opacity - 0.05;
            else
            {
                this.Close();
                tmrDesOpacity.Stop();
            }
        }

        #endregion

        #region [   -   Public Methods   -   ]

        public void Win()
        {
            Random a = new Random();
            int b = a.Next(1, 23);
            string c = b.ToString();

            pbxAvatar.BackgroundImage = Image.FromFile(".\\Emo\\Winner\\" + c + ".jpg");
        }

        public void Lose()
        {
            Random a = new Random();
            int b = a.Next(1, 33);
            string c = b.ToString();

            pbxAvatar.BackgroundImage = Image.FromFile(".\\Emo\\Loser\\" + c + ".jpg");
        }

        public void ReturnAvatar()
        {
            pbxAvatar.BackgroundImage = Image.FromFile(avatarpath);
        }

        public void BringFront()
        {
            this.BringToFront();
        }

        #endregion
    }
}
