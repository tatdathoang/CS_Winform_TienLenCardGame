using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TienlenVer_1
{
    public partial class Card : UserControl
    {
        #region [   -   Properties   -   ]

        private NameofCard _nameOfCard;
        public NameofCard NameOfCard
        {
            get { return _nameOfCard; }
            set { _nameOfCard = value; }
        }

        private TypeofCard _typeOfCard;
        public TypeofCard TypeOfCard
        {
            get { return _typeOfCard; }
            set { _typeOfCard = value; }
        }

        private bool choose;
        public bool Choose
        {
            get { return choose; }
            set { choose = value; }
        }

        #endregion

        public Card()
        {
            InitializeComponent(); 
        }

        public Card(NameofCard nameOfCard, TypeofCard typeOfCard)
        {
            InitializeComponent();
            this._nameOfCard = nameOfCard;
            this._typeOfCard = typeOfCard;
            string image = String.Format("{0:D2}{1}.jpg", nameOfCard.GetHashCode(), typeOfCard.GetHashCode());
            Image i = Image.FromFile("Resources\\" + image);
            this.BackgroundImage = i;
        }

        public void Toggle()
        {
            //Down
            if (this.Choose)
            {
                this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + 25);
                this.Choose = false;
            }
            //Up
            else
            {
                this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y - 25);
                this.Choose = true;
            }
        }
    }
}
