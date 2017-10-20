using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TienlenVer_1
{
    public partial class frmOpen : Form
    {

        #region [   -   Properties   -   ]

        bool right, up = false;
        int whatbutton = 0;

        #endregion

        #region [   -   Event   -   ]

        public frmOpen()
        {
            InitializeComponent();
        }
         
        private void cmdPractice_Click(object sender, EventArgs e)
        {
            right = up = false;
            tmrRightUp.Start();
            whatbutton = 1;
        }

        private void cmdMultiplay_Click(object sender, EventArgs e)
        {
            right = up = false;
            whatbutton = 2;
            tmrRightUp.Start();
        }

        private void cmdOption_Click(object sender, EventArgs e)
        {
            frmOption _frmOption = new frmOption(this);
            _frmOption.StartPosition = FormStartPosition.CenterScreen;
            _frmOption.ShowDialog();   
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrRightUp_Tick(object sender, EventArgs e)
        {
            if (right == false)
            {   
                if (this.Location.X + 10 < 935)
                    this.Location = new Point(this.Location.X + 10, this.Location.Y);
                else
                {
                    this.Location = new Point(935, this.Location.Y);
                    right = true;
                }
            }
            else
            {
                if (up == false)
                {
                    if (this.Location.Y - 10 > 10)
                        this.Location = new Point(this.Location.X, this.Location.Y - 10);
                    else
                    {
                        tmrRightUp.Stop();

                        if(whatbutton!=2)
                            this.Location = new Point(this.Location.X, 10);
                        else
                            this.Location = new Point(this.Location.X, 4);

                        
                        up = true;

                        CheckButton();
                    }
                }
            }
        }

        #endregion

        #region [   -   Load Form   -   ]

        private void CheckButton()
        {
            if (whatbutton == 1)
                OpenSinglePlay();
            if (whatbutton == 2)
                OpenMultiPlay();
        }

        private void OpenSinglePlay()
        {
            frmSinglePlay _frmSingle = new frmSinglePlay(this);
            _frmSingle.ShowDialog(); 
        }

        private void OpenMultiPlay()
        {
            frmMultiPlay _frmMultiplay = new frmMultiPlay(this);
            _frmMultiplay.StartPosition = FormStartPosition.CenterScreen;
           _frmMultiplay.ShowDialog();
        }

        #endregion
    }
}
