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
    public partial class frmSinglePlay : Form
    {
        #region [   -   Properties   -   ]

        public Player _Player = new Player();
        public Player _Computer = new Player();
        public List<Card> PreMoveCards = new List<Card>(); // Store opponent has just played cards
        public List<Card> PlayedCard = new List<Card>(); // Store cards which display in mid location of table, to remove when new one being played 
         
        int remaintime=100;
        int compdelay;
        public bool PlayerOnTurn=false;
        public bool Played = false; //to determine if player played on that round

        public Form frmOpen;
        public frmPlayerInfo frmPlyInfo,frmCompInfo;
        public bool right, down = false;
        public bool isFirstRound = true;

        public int Wintimes, LoseTimes = 0;

        #endregion

        #region [   -   Event   -   ]

        public frmSinglePlay(Form frm)
        {
            InitializeComponent();

            this.frmOpen = frm;
        }

        private void frmSinglePlay_Load(object sender, EventArgs e)
        {
            this.Location = new Point(436, 10);
        }

        public void Choseobj_Click(object sender, EventArgs e)
        {
            Card Temp = sender as Card;

            //Down
            if (Temp.Choose)
                _Player.ChoseCard.Remove(Temp);

            //Up
            else
                _Player.ChoseCard.Add(Temp);

            if (PlayerOnTurn == true)
            {
                if (_Player.DoCheck(PreMoveCards))
                    cmdPlay.Enabled = true;
                else
                    cmdPlay.Enabled = false;
            }

            if (_Player.ChoseCard.Count != 0)
                cmdUnChose.Enabled = true;
            else
                cmdUnChose.Enabled = false;

            Temp.Toggle();
        }

        private void cmdPlay_Click(object sender, EventArgs e)
        {
            Played = true;

            //Add chose cards to Premovecard
            PreMoveCards.Clear();
            PreMoveCards.AddRange(_Player.ChoseCard);


            //Remove crads from Player cards
            for (int i = 0; i < _Player.ChoseCard.Count; i++)
                _Player.PlayerCard.Remove(_Player.ChoseCard[i]);
            _Player.ChoseCard.Clear();

            //Draw chose card
            DrawPlayedCard();

            //Re-draw player cards
            DrawPlayerCard(ref _Player.PlayerCard);

            cmdPlay.Enabled = false;
            cmdUnChose.Enabled = false;
            cmdSkip.Enabled = false;

            if (_Player.PlayerCard.Count == 0)
            {
                pbxOpponent.Visible = false;
                cmdPlay.Visible = false;
                cmdSkip.Visible = false;
                cmdUnChose.Visible = false;
                cmdDeal.Visible = true;

                DrawComputerCard(ref _Computer.PlayerCard);

                UnClickableCards(_Computer.PlayerCard);

                tmrPlayer.Stop();
                pbrRemainTime.Visible = false;
                pbxClock.Visible = false;

                lblStatus.Text = "You Win!";
                
                frmPlyInfo.Win();
                frmCompInfo.Lose();

                Wintimes++;
                frmPlyInfo.lblWinNum.Text = Wintimes.ToString();
                frmCompInfo.lblLoseNum.Text = Wintimes.ToString();
            }
            else
                remaintime = 1;
        }

        private void cmdUnChose_Click(object sender, EventArgs e)
        {
            UnChoseAll();
        }

        private void cmdSkip_Click(object sender, EventArgs e)
        {
            UnChoseAll();
            PreMoveCards.Clear();
            RemovePlayedCard();

            cmdPlay.Enabled = false;
            cmdUnChose.Enabled = false;
            cmdSkip.Enabled = false;

            remaintime = 1;
        }

        private void cmdDeal_Click(object sender, EventArgs e)
        {
            if (isFirstRound)
            {
                frmPlyInfo = new frmPlayerInfo(true);
                frmPlyInfo.Location = new Point(this.Right - frmPlyInfo.Width, this.Bottom - frmPlyInfo.Height + 5);
                frmPlyInfo.Show();

                frmCompInfo = new frmPlayerInfo(false);
                frmCompInfo.Location = new Point(this.Left, this.Top + 25);
                frmCompInfo.lblPlayerName.Text = "Computer";
                frmCompInfo.Show();

                isFirstRound = false;
            }

            frmPlyInfo.ReturnAvatar();
            frmCompInfo.ReturnAvatar();
            this.BringToFront();

            RemovePlayedCard();
            RemovePlayerCards();

            _Player.PlayerCard.Clear();
            _Computer.PlayerCard.Clear();
            PreMoveCards.Clear();

            Deal();

            if (CheckSmallestCard())
                PlayerBeginTurn();
            else
                ComputerBeginTurn();

            cmdDeal.Visible = false;
            pbxOpponent.Visible = true;
            cmdPlay.Visible = true;
            cmdSkip.Visible = true;
            cmdUnChose.Visible = true;
        }
        
        #endregion

        #region [   -   Proceed Interface   -   ]

        private void DrawPlayerCard(ref List<Card> CardList)
        {
            Card Temp;
            int j = CardList.Count();
            int endLocation = this.Width - ((this.Width - ((22 * (CardList.Count())) + 112)) / 2) - 112;
            for (int i = j - 1; i >= 0; i--)
            {
                Temp = CardList[i];
                Temp.Location = new System.Drawing.Point(endLocation, 414);
                this.Controls.Add(Temp);
                endLocation -= 22;
                j = CardList.Count();
            }
        }

        private void RemovePlayedCard()
        {
            //Remove exiting played cards from Form
            if (PlayedCard.Count != 0)
                for (int i = 0; i < PlayedCard.Count(); i++)
                    this.Controls.Remove(PlayedCard[i]);
            PlayedCard.Clear();
        }

        private void RemovePlayerCards()
        {
            if (_Computer.PlayerCard.Count != 0)
                for (int i = 0; i < _Computer.PlayerCard.Count; i++)
                    this.Controls.Remove(_Computer.PlayerCard[i]);

            if (_Player.PlayerCard.Count != 0)
                for (int i = 0; i < _Player.PlayerCard.Count; i++)
                    this.Controls.Remove(_Player.PlayerCard[i]);
        }

        private void DrawPlayedCard()
        {
            RemovePlayedCard();

            Card Temp;
            int j = PreMoveCards.Count();
            int endLocation = this.Width - ((this.Width - ((22 * (PreMoveCards.Count())) + 112)) / 2) - 112;
            for (int i = j - 1; i >= 0; i--)
            {
                Temp = PreMoveCards[i];
                PlayedCard.Add(Temp);
                Temp.Location = new System.Drawing.Point(endLocation, 232);
                //Make computer card visible
                Temp.Visible = true;
                endLocation -= 22;
                j = PreMoveCards.Count();
            }

            UnClickableCards(PlayedCard);
        }

        private void UnClickableCards(List<Card> List)
        {
            for (int i = 0; i < List.Count; i++)
                List[i].Click -= Choseobj_Click;
        }

        private void DrawComputerCard(ref List<Card> CardList)
        {
            Card Temp;
            int j = CardList.Count();
            int endLocation = this.Width - ((this.Width - ((22 * (CardList.Count())) + 112)) / 2) - 112;
            for (int i = j - 1; i >= 0; i--)
            {
                Temp = CardList[i];
                Temp.Location = new System.Drawing.Point(endLocation, 20);
                Temp.Visible = true;
                this.Controls.Add(Temp);
                endLocation -= 22;
                j = CardList.Count();
            }
        }

        private void UnChoseAll()
        {
            int n = _Player.PlayerCard.Count();
            for (int i = 0; i < n; i++)
                if (_Player.PlayerCard[i].Choose == true)
                {
                    _Player.PlayerCard[i].Location = new System.Drawing.Point(_Player.PlayerCard[i].Location.X, _Player.PlayerCard[i].Location.Y + 25);
                    _Player.PlayerCard[i].Choose = false;
                    _Player.ChoseCard.Remove(_Player.PlayerCard[i]);
                }

            cmdPlay.Enabled = false;
            cmdUnChose.Enabled = false;
        }

        private void frmSinglePlay_LocationChanged(object sender, EventArgs e)
        {
            frmOpen.Invoke(new Relocate(Rec), frmOpen, this.Location.X + this.Size.Width + 5, this.Location.Y);

            if (frmPlyInfo != null && frmPlyInfo.Created != false)
                frmPlyInfo.Invoke(new Relocate(Rec), frmPlyInfo, this.Right + 5, this.Bottom - frmPlyInfo.Height + 5);
            if (frmCompInfo != null && frmCompInfo.Created != false)
                frmCompInfo.Invoke(new Relocate(Rec), frmCompInfo, this.Left - frmCompInfo.Width - 5, this.Top + 25);
        }

        private void frmSinglePlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();

            if (frmPlyInfo != null && frmPlyInfo.Created != false)
                frmPlyInfo.tmrDesOpacity.Start();

            if (frmCompInfo != null && frmCompInfo.Created != false)
                frmCompInfo.tmrDesOpacity.Start();

            tmrDownRight.Start();
        }

        private void tmrDownRight_Tick(object sender, EventArgs e)
        {
            frmOpen.ShowInTaskbar = true;

            int x = frmOpen.Location.X;
            int y = frmOpen.Location.Y;

            if (down == false)
            {
                if (frmOpen.Location.Y + 10 < 208)
                {
                    y += 10;
                    frmOpen.Invoke(new RelocateY(RecY), frmOpen, y);
                }

                else
                {
                    frmOpen.Invoke(new Relocate(Rec), frmOpen, x, 208);
                    down = true;
                }
            }

            else
            {
                if (right == false)
                {
                    if (frmOpen.Location.X - 10 > 602)
                    {
                        x -= 10;
                        frmOpen.Invoke(new RelocateX(RecX), frmOpen, x);
                    }
                    else
                    {
                        tmrDownRight.Stop();


                        frmOpen.Invoke(new Relocate(Rec), frmOpen,602, y);

                        right = true;

                        this.Close();
                    }
                }
            }
        }
        
        #endregion

        #region [   -   Play   -   ]

        public void Deal()
        {
            
            #region Create deck

            //Set value to Name[]
            List<NameofCard> Name = new List<NameofCard>();
            for (int namecard = 3; namecard < 16; namecard++)
                for (int amt = 1; amt < 5; amt++)
                {
                    Name.Add((NameofCard)namecard);
                }

            //Set value to Type[]
            List<TypeofCard> Type = new List<TypeofCard>();
            for (int amt = 1; amt < 14; amt++)
                for (int typecard = 1; typecard < 5; typecard++)
                {
                    Type.Add((TypeofCard)typecard);
                }

            //Set value to Deck
            List<Card> Deck = new List<Card>();
            for (int crd = 0; crd < 52; crd++)
            {
                Card temp = new Card(Name[crd], Type[crd]);
                Deck.Add(temp);
                //temp.Click += new EventHandler(Deck);

            }
            #endregion

            #region Add to PlayerS Card List

            Card Temp;
            int recrd = 52;
            Random deal = new Random();
            for (int i = 13; i > 0; i--)
            {
                Temp = Deck[deal.Next(0, recrd)];
                Temp.Click += new EventHandler(Choseobj_Click);
                _Player.PlayerCard.Add(Temp);
                Deck.Remove(Temp);
                _Player.SortCList(ref _Player.PlayerCard);
                recrd--;
            }

            for (int i = 13; i > 0; i--)
            {
                Temp = Deck[deal.Next(0, recrd)];
                Temp.Click += new EventHandler(Choseobj_Click);
                _Computer.PlayerCard.Add(Temp);
                Deck.Remove(Temp);
                _Computer.SortCList(ref _Computer.PlayerCard);
                recrd--;
            }

            #endregion

            #region Add Cards to Form

            //Draw from Player card
            DrawPlayerCard(ref _Player.PlayerCard);

            
            //Do the same thing as draw Player card but for Computer, these code make DrawPlayerCard go right when _Computer call it
            int j = _Computer.PlayerCard.Count();
            for (int i = j - 1; i >= 0; i--)
            {
                Temp = _Computer.PlayerCard[i];
                Temp.Visible = false;
                Temp.Location = new System.Drawing.Point(0, 0);
                this.Controls.Add(Temp);
                j = _Computer.PlayerCard.Count();
            }

            #endregion
        }
        
        private bool CheckSmallestCard()
        {
            switch (_Player.CheckSingle(_Player.PlayerCard[0], _Computer.PlayerCard[0]))
            { 
                case true:
                    return false;
                case false:
                    return true;
            }
            return true;//just 4fun
        }

        private void PlayerBeginTurn()
        {
            pbrRemainTime.Visible = true;
            pbxClock.Visible = true;
            
            tmrPlayer.Start();

            PlayerOnTurn = true;
            lblStatus.Text = "Your turn!";

            //if player chose card while Computer is thinking!
            if (_Player.DoCheck(PreMoveCards))
                cmdPlay.Enabled = true;
            //if computer skip
            if(PreMoveCards.Count!=0)
                cmdSkip.Enabled = true;    
        }

        private void ComputerBeginTurn()
        {
            tmrPlayer.Stop();
            pbrRemainTime.Visible = false;
            pbxClock.Visible = false;

            PlayerOnTurn = false;
            Played = false;
            lblStatus.Text = "Computer is thinking!";

            Random temp = new Random();
            compdelay = temp.Next(2, 5);

            tmrCompDelay.Start();
            
        }

        private void ComputerPlay()
        {
            //If Computer is start the round, computer play its first card
            if (PreMoveCards.Count == 0)
                _Computer.ChoseCard.Add(_Computer.PlayerCard[0]);
            else
                _Computer.FindValidCardtoPlay(PreMoveCards);

            
            

            //Computer cant find ValidCard
            if (_Computer.ChoseCard.Count == 0)
            {
                RemovePlayedCard();
                PreMoveCards.Clear();

                remaintime = 100;
                PlayerBeginTurn();
            }

            //Computer found valid card
            else
            {
                //Add chose cards to Premovecard
                PreMoveCards.Clear();
                PreMoveCards.AddRange(_Computer.ChoseCard);

                //Remove cards from Player cards
                for (int i = 0; i < _Computer.ChoseCard.Count; i++)
                    _Computer.PlayerCard.Remove(_Computer.ChoseCard[i]);
                _Computer.ChoseCard.Clear();

                //Draw chose card
                DrawPlayedCard();

                //Computer threw its card into table

                //If computer play the last card
                if (_Computer.PlayerCard.Count == 0)
                {
                    UnChoseAll();

                    LoseTimes++;
                    frmPlyInfo.lblLoseNum.Text = LoseTimes.ToString();
                    frmCompInfo.lblWinNum.Text = LoseTimes.ToString();

                    lblStatus.Text = "You lose!";

                    frmCompInfo.Win();
                    frmPlyInfo.Lose();

                    UnClickableCards(_Player.PlayerCard);

                    pbxOpponent.Visible = false;
                    cmdPlay.Visible = false;
                    cmdSkip.Visible = false;
                    cmdUnChose.Visible = false;
                    cmdDeal.Visible = true;
                }

                else
                {   
                    remaintime = 100;
                    PlayerBeginTurn();
                }
            }
        }

        private void tmrPlayer_Tick(object sender, EventArgs e)
        {
            pbrRemainTime.Value = remaintime;
            
            if(remaintime <= 20)
            {
                if (pbxClock.Visible == true)
                    pbxClock.Visible = false;
                else
                    pbxClock.Visible = true;
            }

            if (remaintime == 0 ) 
            {
                if (Played == false)// mean player running out of time
                {
                    remaintime = 100;
                    RemovePlayedCard();
                    PreMoveCards.Clear();

                    ComputerBeginTurn();
                }
                else
                {
                    remaintime = 100;
                    ComputerBeginTurn();
                }
            }
            else
                remaintime--;
        }

        private void tmrCompDelay_Tick(object sender, EventArgs e)
        {
            if (compdelay == 0)
            {
                tmrCompDelay.Stop();
                ComputerPlay();
            }
            compdelay--;
        }

        #endregion

        #region [   -   Delegate  -   ]

        public delegate void RelocateX(Form frm, int x);
        private void RecX(Form frm, int x)
        {
            frm.Location = new Point(x, frm.Location.Y);
        }

        public delegate void RelocateY(Form frm, int y);
        private void RecY(Form frm, int y)
        {
            frm.Location = new Point(frm.Location.X, y);
        }

        public delegate void Relocate(Form frm, int x, int y);
        private void Rec(Form frm, int x, int y)
        {
            frm.Location = new Point(x, y);
        }

        #endregion

    }
}
