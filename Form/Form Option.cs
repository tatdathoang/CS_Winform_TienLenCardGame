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
    public partial class frmOption : Form
    {
        #region [   -   Properties   -   ]

        string avatarpath, playername;

        #endregion

        #region [   -   Event   -   ]

        public frmOption(Form frm)
        {
            InitializeComponent();
        }

        private void frmOption_Load(object sender, EventArgs e)
        {
            StreamReader StreamR = new StreamReader(".\\Config.config");
            FileInfo fileInf = new FileInfo(".\\Config.config");
            playername = StreamR.ReadLine();
            txtPlyerName.Text = playername;

            avatarpath = StreamR.ReadLine();
            Image img;
            
            try
            {
                img = Image.FromFile(avatarpath);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Your avatar is not found. Default avatar will be replaced instead!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                img = Image.FromFile(".\\Emo\\Avatar\\9.jpg");
                avatarpath = ".\\Emo\\Avatar\\9.jpg";

                StreamR.Close();

                StreamWriter StreamW = new StreamWriter(".\\Config.config");
                StreamW.Write(txtPlyerName.Text + "\r\n");
                StreamW.Write(avatarpath);
                StreamW.Close();
            }

            pbxAvatar.BackgroundImage = img;

            StreamR.Close();

            BeginInvoke(new MethodInvoker(focusTxtBox));
        }

        private void focusTxtBox()
        {
            txtPlyerName.Focus();
        }

        private void txtPlyerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                txtPlyerName.Text = playername;
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            odlAvatar.ShowDialog();
        }

        private void odlAvatar_FileOk(object sender, CancelEventArgs e)
        {
            avatarpath = odlAvatar.FileName;
            Image img = Image.FromFile(avatarpath);
            pbxAvatar.BackgroundImage = img;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (txtPlyerName.Text != "")
                playername = txtPlyerName.Text;

            StreamWriter StreamW = new StreamWriter(".\\Config.config");
            StreamW.Write(playername + "\r\n");
            StreamW.Write(avatarpath);
            StreamW.Close();
            
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        
    }
}
