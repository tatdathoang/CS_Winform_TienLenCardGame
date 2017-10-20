using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TienlenVer_1
{
    public partial class frmMultiPlay : Form
    {

        #region [   -   Properties   -   ]

        //Properties for connection
        private TcpClient client = null;
        private IPAddress ip = null;
        private bool serverdown = false;

        private StreamWriter send = null;
        private StreamReader receiver = null;
        private Thread th_receive = null;

        string ipNumber;
        int port;

        public string sendMesg = null;
        public string receivedMesg = null;

        //Properties for Play
        private Player _Player = new Player();
        private Player _Player2 = new Player();
        private List<Card> PreMoveCards = new List<Card>(); // Store opponent has just played cards
        private List<Card> PlayedCard = new List<Card>(); // Store cards which display in mid location of table, to remove when new one being played 

        private int remaintime = 100;
        private bool PlayerOnTurn = false;
        private bool iswinner = false;
        private bool isfirstround = true;

        //Properties for Interface
        Form frmOpen;
        bool right, down = false;

        frmPlayerInfo frmPlyInfo, frmOppInfo;
        public int Wintimes, LoseTimes = 0;
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
                _Player2.PlayerCard.Add(Temp);
                Deck.Remove(Temp);
                _Player2.SortCList(ref _Player2.PlayerCard);
                recrd--;
            }

            #endregion

            //Draw Player card
            DrawPlayerCard(ref _Player.PlayerCard);

            //Create Mesg include 13 cards of another player
            CreateDealedCardMesg();

        }

        private void UnClickableCards(List<Card> List)
        {
            for (int i = 0; i < List.Count; i++)
                List[i].Click -= Choseobj_Click;
        }
        
        private bool CheckSmallestCard()
        {
            switch (_Player.CheckSingle(_Player.PlayerCard[0], _Player2.PlayerCard[0]))
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
            PlayerOnTurn = true;
            remaintime = 100;

            this.BeginInvoke(new ShowProgressbar(ShwProgressbar), pbrRemainTime);
            this.BeginInvoke(new ShowPicturebox(ShwPbx), pbxClock);

            this.BeginInvoke(new ChangeLableText(ChgLblText), lblStatus, "Your turn!");

            this.BeginInvoke(new StartTimer(StrTimer), tmrPlayer);

            //if player chose card while other player onturn
            if (_Player.DoCheck(PreMoveCards))
                this.BeginInvoke(new EnableButton(EnbBtt), cmdPlay);
            //if computer skip
            if (PreMoveCards.Count != 0)
                this.BeginInvoke(new EnableButton (EnbBtt), cmdSkip);
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

        private void Winner()
        {
            Wintimes++;
            frmPlyInfo.lblWinNum.Text = Wintimes.ToString();
            frmOppInfo.lblLoseNum.Text = Wintimes.ToString();
            frmPlyInfo.Win();
            frmOppInfo.Lose();

            pbxOpponent.Visible = false;
            cmdPlay.Visible = false;
            cmdSkip.Visible = false;
            cmdUnChose.Visible = false;
            cmdDeal.Visible = true;
            cmdDeal.Enabled = true;

            this.BeginInvoke(new ChangeLableText(ChgLblText), lblStatus, "You Win!");

            iswinner = true;

            tmrPlayer.Stop();
        }

        private void Loser()
        {
            LoseTimes ++;
            this.BeginInvoke(new ChangeLableText(ChgLblText), frmPlyInfo.lblLoseNum, LoseTimes.ToString());
            this.BeginInvoke(new ChangeLableText(ChgLblText), frmOppInfo.lblWinNum, LoseTimes.ToString());
            frmPlyInfo.Lose();
            frmOppInfo.Win();

            this.BeginInvoke(new StopTimer (StpTimer), tmrPlayer);

            this.BeginInvoke(new HideProgressbar(HdProgressbar ), pbrRemainTime);
            this.BeginInvoke(new HidePicturebox(HdPbx), pbxClock);
            this.BeginInvoke(new HidePicturebox(HdPbx), pbxOpponent);
            this.BeginInvoke(new HideButton(HdBtt), cmdPlay);
            this.BeginInvoke(new HideButton(HdBtt), cmdSkip);
            this.BeginInvoke(new EnableButton(EnbBtt), cmdSkip);
            this.BeginInvoke(new HideButton(HdBtt), cmdUnChose);

            this.BeginInvoke(new ChangeLableText(ChgLblText), lblStatus,"You Lose!");

            UnClickableCards(_Player.PlayerCard);

            iswinner = false;
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
                Temp.Location = new System.Drawing.Point(endLocation, 478);
                this.BeginInvoke(new AddCardtoForm(AddCrdtoForm), Temp);
                endLocation -= 22;
                j = CardList.Count();
            }
        }

        private void RemovePlayedCard()
        {
            //Remove exiting played cards from Form
            if (PlayedCard.Count != 0)
                for (int i = 0; i < PlayedCard.Count(); i++)
                    this.BeginInvoke(new RemoveCardfromForm(RevCrdfromForm), PlayedCard[i]);
            PlayedCard.Clear();
        }

        private void RemovePlayerCards()
        {
            for (int i = 0; i < this.Controls.Count; )
            {
                if (this.Controls[i] is Card)
                    this.BeginInvoke(new RemoveCardfromForm(RevCrdfromForm), this.Controls[i]);

                i++;
            }
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
                Temp.Location = new System.Drawing.Point(endLocation, 288);
                this.BeginInvoke(new AddCardtoForm(AddCrdtoForm), Temp);
                endLocation -= 22;
                j = PreMoveCards.Count();
            }

            UnClickableCards(PlayedCard);
        }

        private void DrawOpponentCard(ref List<Card> CardList)
        {
            Card Temp;
            int j = CardList.Count();
            int endLocation = this.Width - ((this.Width - ((22 * (CardList.Count())) + 112)) / 2) - 112;
            for (int i = j - 1; i >= 0; i--)
            {
                Temp = CardList[i];
                Temp.Location = new System.Drawing.Point(endLocation, 96);
                this.BeginInvoke(new AddCardtoForm(AddCrdtoForm), Temp);
                endLocation -= 22;
                j = CardList.Count();
            }
        }

        private void frmMultiPlay_LocationChanged(object sender, EventArgs e)
        {
            frmOpen.Invoke(new Relocate(Rec), frmOpen, this.Location.X + 5 + this.Size.Width, this.Location.Y);

            if (frmPlyInfo != null && frmPlyInfo.Created != false)
                frmPlyInfo.Invoke(new Relocate(Rec), frmPlyInfo, this.Right + 5, this.Bottom - frmPlyInfo.Height + 5);

            if (frmOppInfo != null && frmOppInfo.Created != false)
                frmOppInfo.Invoke(new Relocate(Rec), frmOppInfo, this.Left - frmOppInfo.Width - 5, this.Top + 25);

        }

        private void frmMultiPlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmdDisconnect.Enabled)
                cmdDisconnect.PerformClick();

            this.Hide();

            if (frmPlyInfo != null && frmPlyInfo.Created != false)
                frmPlyInfo.tmrDesOpacity.Start();

            if (frmOppInfo != null && frmOppInfo.Created != false)
                frmOppInfo.tmrDesOpacity.Start();

            tmrDownRight.Start();
        }

        private void tmrDownRight_Tick(object sender, EventArgs e)
        {
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


                        frmOpen.Invoke(new Relocate(Rec), frmOpen, 602, y);

                        right = true;
                        this.Close();
                    }
                }
            }
        }

        #endregion

        #region [   -   Event   -   ]

        public frmMultiPlay(Form frm)
        {
            InitializeComponent();
            this.frmOpen = frm;
            this.Location = new Point(436, 10);
        }

        private void frmMultiPlay_Load(object sender, EventArgs e)
        {
            if (isfirstround)
            {
                frmPlyInfo = new frmPlayerInfo(true);
                frmPlyInfo.Location = new Point(this.Right - frmPlyInfo.Width, this.Bottom - frmPlyInfo.Height + 5);
                frmPlyInfo.Show();

                frmOppInfo = new frmPlayerInfo(false);
                frmOppInfo.Location = new Point(this.Left, this.Top + 100);
                frmOppInfo.Show();
                frmOppInfo.Visible = false;

                this.BringToFront();
            }
        }

        private void txtIP1_TextChanged(object sender, EventArgs e)
        {
            if (txtIP1.Text.Length == 3)
                txtIP2.Focus();
        }

        private void txtIP2_TextChanged(object sender, EventArgs e)
        {
            if (txtIP2.Text.Length == 3)
                txtIP3.Focus();
        }

        private void txtIP3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (txtIP3.Text.Length == 3)
                txtIP4.Focus();
        }

        private void cmdDeal_Click(object sender, EventArgs e)
        {
            if (isfirstround && frmOppInfo != null && frmOppInfo.Created != false)
            {
                frmOppInfo.Visible = true;
                PlayerOnTurn = true;
            }

            frmOppInfo.ReturnAvatar();
            frmPlyInfo.ReturnAvatar();

            RemovePlayedCard();
            RemovePlayerCards();

            _Player.PlayerCard.Clear();
            _Player2.PlayerCard.Clear();
            PreMoveCards.Clear();

            Deal();

            cmdDeal.Visible = false;
            pbxOpponent.Visible = true;
            cmdPlay.Visible = true;
            cmdSkip.Visible = true;
            cmdUnChose.Visible = true;


        }

        private void Choseobj_Click(object sender, EventArgs e)
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

        private void cmdUnChose_Click(object sender, EventArgs e)
        {
            UnChoseAll();
        }

        private void cmdSkip_Click(object sender, EventArgs e)
        {
            tmrPlayer.Stop();

            lblStatus.Text = "Wait for your turn...";

            pbrRemainTime.Visible = false;
            pbxClock.Visible = false;

            UnChoseAll();
            PreMoveCards.Clear();
            RemovePlayedCard();

            PlayerOnTurn = false;

            cmdPlay.Enabled = false;
            cmdUnChose.Enabled = false;
            cmdSkip.Enabled = false;

            CreateSkipMesg();

        }

        private void tmrPlayer_Tick(object sender, EventArgs e)
        {
            this.BeginInvoke(new ChangePbrValue(ChgPbrValue), pbrRemainTime, remaintime);

            if (remaintime <= 20)
            {
                if (pbxClock.Visible == true)
                    this.BeginInvoke(new HidePicturebox(HdPbx), pbxClock);
                else
                    this.BeginInvoke(new ShowPicturebox(ShwPbx), pbxClock);
            }

            if (remaintime == 0)
            {
                cmdSkip.Enabled = true;//to make below code valid
                cmdSkip.PerformClick();
            }
            else
                remaintime--;
        }

        private void cmdPlay_Click(object sender, EventArgs e)
        {

            lblStatus.Text = "Wait for your turn...";
            pbrRemainTime.Visible = false;
            pbxClock.Visible = false;

            CreatePlayedCardMesg();

            PlayerOnTurn = false;

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
                Winner();

                CreateRequestCardListMesg();
            }
            else
            {
                tmrPlayer.Stop();
            }
        }

        #endregion

        #region [   -   Connect   -   ]

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            //Get IP and port info
            ipNumber = txtIP1.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
            port = int.Parse(txtPort.Text);

            try
            {
                try
                {
                    ip = IPAddress.Parse(ipNumber);
                }
                catch
                {
                    MessageBox.Show("Incorect IP","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIP1.Focus();
                    txtIP1.SelectAll();
                    return;
                }

                client = new TcpClient();
                client.Connect(ip, port);


                // Start the thread for receiving messages and further communication
                th_receive = new Thread(new ThreadStart(ReceiveMessages));
                th_receive.Start();

                serverdown = false;

                lblStatus.Visible=true;
                lblStatus.Text = "Wait for another player....";

                cmdConnect.Enabled = false;
                txtIP1.Enabled = false;
                txtIP2.Enabled = false;
                txtIP3.Enabled = false;
                txtIP4.Enabled = false;
                txtPort.Enabled = false;
                cmdDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n\nMake sure that you started the server and entered corect server info (IP and Port)", "Can not connect to server",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            this.BeginInvoke(new EnableButton(EnbBtt), cmdConnect);
            this.BeginInvoke(new DisableButton(DsbBtt), cmdDisconnect);

            this.BeginInvoke(new EnableTexbox(EnbTxt), txtIP1);
            this.BeginInvoke(new EnableTexbox(EnbTxt), txtIP2);
            this.BeginInvoke(new EnableTexbox(EnbTxt), txtIP3);
            this.BeginInvoke(new EnableTexbox(EnbTxt), txtIP4);
            
            if(!serverdown)
                CreateDisconnectMesg();

            this.BeginInvoke(new StopTimer(StpTimer), tmrPlayer);

            RemovePlayedCard();
            RemovePlayerCards();

            _Player.PlayerCard.Clear();
            _Player2.PlayerCard.Clear();
            PreMoveCards.Clear(); 

            this.BeginInvoke(new HidePicturebox(HdPbx), pbxOpponent);
            this.BeginInvoke(new HideProgressbar(HdProgressbar), pbrRemainTime);
            this.BeginInvoke(new HidePicturebox(HdPbx), pbxClock);

            this.BeginInvoke(new ChangeLableText(ChgLblText), lblStatus, "Disconnected!");
            this.BeginInvoke(new HideButton(HdBtt), cmdDeal);
            this.BeginInvoke(new HideButton(HdBtt), cmdPlay);
            this.BeginInvoke(new HideButton(HdBtt), cmdSkip);
            this.BeginInvoke(new HideButton(HdBtt), cmdUnChose);

            this.BeginInvoke(new StartTimer(StrTimer), frmOppInfo.tmrDesOpacity);

            receiver.Close();
            th_receive.Abort();
        }
        
        #endregion

        #region [   -   Sender   -   ]

        private void CreatePlayerInfoMesg()
        {
            sendMesg = "0-" + frmPlyInfo.playerName;
            SendMesage();
        }

        private void CreateDealedCardMesg()
        {
            //mesg type: 2 or 3-nameofcard_typeofcard-nameofcard_typeofcard-.....-0
            if (isfirstround == true)
            {
                if (CheckSmallestCard())
                {
                    PlayerBeginTurn();
                    sendMesg = "2";
                }
                else
                {
                    sendMesg = "3";
                    lblStatus.Text = "Wait for your turn...";
                }
            }
            else
            {
                if (iswinner == true)
                {
                    PlayerBeginTurn();
                    sendMesg = "2";
                }
                else
                {
                    sendMesg = "3";
                    lblStatus.Text = "Wait for your turn...";
                }
            }

            if (isfirstround)
            {
                sendMesg += "-" + frmPlyInfo.playerName;
                isfirstround = false;
            }
            else
                 sendMesg += "-0";
                
            for (int i = 0; i < _Player2.PlayerCard.Count; i++)
            {
                sendMesg += "-";
                sendMesg += Convert.ToString(_Player2.PlayerCard[i].NameOfCard.GetHashCode());
                sendMesg += "_";
                sendMesg += Convert.ToString(_Player2.PlayerCard[i].TypeOfCard.GetHashCode());
            }
            SendMesage();
        }

        private void CreatePlayedCardMesg()
        {
            sendMesg = "4";

            for (int i = 0; i < _Player.ChoseCard.Count; i++)
            {
                sendMesg += "-";
                sendMesg += Convert.ToString(_Player.ChoseCard[i].NameOfCard.GetHashCode());
                sendMesg += "_";
                sendMesg += Convert.ToString(_Player.ChoseCard[i].TypeOfCard.GetHashCode());
            }
            SendMesage();
        }

        private void CreateSkipMesg()
        {
            sendMesg = "5";
            SendMesage();
        }

        private void CreateRequestCardListMesg()
        {
            sendMesg = "6";
            SendMesage();
        }

        private void CreatePlayerCardListMesg()
        {
            sendMesg = "7";
            for (int i = 0; i < _Player.PlayerCard.Count; i++)
            {
                sendMesg += "-";
                sendMesg += Convert.ToString(_Player.PlayerCard[i].NameOfCard.GetHashCode());
                sendMesg += "_";
                sendMesg += Convert.ToString(_Player.PlayerCard[i].TypeOfCard.GetHashCode());
            }
            SendMesage();
        }

        private void CreateDisconnectMesg()
        {
            sendMesg = "8";
            SendMesage();
        }

        private void SendMesage()
        {
            send = new StreamWriter(client.GetStream());
           
            send.Write(sendMesg.ToCharArray());
            send.Flush();
        }

        #endregion

        #region [   -   Receiver   -   ]

        private void ReceiveMessages()
        {
            while (client.Connected)
            {
                // Receive the response from the server
                receiver = new StreamReader(client.GetStream());

                // While we are successfully connected, read incoming lines from the server
                
                receivedMesg = null;
                while (receiver.Peek() >= 0)
                {
                    char temp = (char)receiver.Read();
                    receivedMesg += temp.ToString();
                }
                ProceedReceivedMesg();
            }
        
        }

        private void ProceedReceivedMesg()
        {
            string[] temp = receivedMesg.Split(new char[] { '-', '_' });

            //receivedMesg is Opponent Info
            #region receive Opponent Info 
            {
                if (temp[0] == "0")
                    this.BeginInvoke(new ChangeLableText(ChgLblText), frmOppInfo.lblPlayerName, temp[1]);
            }
            #endregion

            //receivedMesg Begin play
            #region Begin play

            if (temp[0] == "1")
                this.BeginInvoke(new ShowButton(ShwBtt), cmdDeal);

            #endregion

            //receivedMesg is 13 cards
            #region receive 13 cards
            // 2 mean other player have smallest card, 3 mean i have
            if (temp[0] == "2" || temp[0] == "3")
            {
                if (isfirstround)
                {
                    this.BeginInvoke(new VisibleTrue(VsbTrue), frmOppInfo);
                    CreatePlayerInfoMesg();
                }
                frmOppInfo.ReturnAvatar();
                frmPlyInfo.ReturnAvatar();

                

                RemovePlayedCard();
                RemovePlayerCards();

                _Player.PlayerCard.Clear();
                _Player2.PlayerCard.Clear();
                PreMoveCards.Clear();


                if (temp[0] == "3")
                    PlayerBeginTurn();
                else
                {
                    PlayerOnTurn = false;
                    this.BeginInvoke(new ChangeLableText(ChgLblText), lblStatus, "Wait for your turn...");
                }

                if (isfirstround)
                {
                    this.BeginInvoke(new ChangeLableText(ChgLblText), frmOppInfo.lblPlayerName, temp[1]);
                    isfirstround = false;
                }

                for (int i = 2; i < temp.Length - 1; i = i + 2)
                {
                    NameofCard NameTemp = (NameofCard)Enum.Parse(typeof(NameofCard), temp[i], true);
                    TypeofCard TypeTemp = (TypeofCard)Enum.Parse(typeof(TypeofCard), temp[i + 1], true);
                    Card Temp = new Card(NameTemp, TypeTemp);
                    Temp.Click += new EventHandler(Choseobj_Click);
                    _Player.PlayerCard.Add(Temp);
                }

                DrawPlayerCard(ref _Player.PlayerCard);

                this.BeginInvoke(new HideButton(HdBtt), cmdDeal);
                this.BeginInvoke(new ShowPicturebox(ShwPbx), pbxOpponent);
                this.BeginInvoke(new ShowButton(ShwBtt), cmdPlay);
                this.BeginInvoke(new ShowButton(ShwBtt), cmdSkip);
                this.BeginInvoke(new ShowButton(ShwBtt), cmdUnChose);

            }
            #endregion

            //receivedMesg is other player played card
            #region receive other player played card

            if (temp[0] == "4")
            {
                PreMoveCards.Clear();

                for (int i = 1; i < temp.Length - 1; i = i + 2)
                {
                    NameofCard NameTemp = (NameofCard)Enum.Parse(typeof(NameofCard), temp[i], true);
                    TypeofCard TypeTemp = (TypeofCard)Enum.Parse(typeof(TypeofCard), temp[i + 1], true);
                    Card Temp = new Card(NameTemp, TypeTemp);
                    Temp.Click += new EventHandler(Choseobj_Click);
                    PreMoveCards.Add(Temp);
                }

                RemovePlayedCard();
                DrawPlayedCard();

                PlayerBeginTurn();
            }

            #endregion

            //receivedMesg is other player skip
            #region receive mesg other player skip

            if (temp[0] == "5")
            {
                RemovePlayedCard();
                PreMoveCards.Clear();

                PlayerBeginTurn();
            }

            #endregion

            //received request Card list
            #region received request Card list

            if (temp[0] == "6")
            {
                CreatePlayerCardListMesg();
                Loser();
            }
            #endregion

            //received Card list
            #region received Card list

            if (temp[0] == "7")
            {
                _Player2.PlayerCard.Clear();

                for (int i = 1; i < temp.Length - 1; i = i + 2)
                {
                    NameofCard NameTemp = (NameofCard)Enum.Parse(typeof(NameofCard), temp[i], true);
                    TypeofCard TypeTemp = (TypeofCard)Enum.Parse(typeof(TypeofCard), temp[i + 1], true);
                    Card Temp = new Card(NameTemp, TypeTemp);
                    _Player2.PlayerCard.Add(Temp);
                }

                DrawOpponentCard(ref _Player2.PlayerCard);
            }

            #endregion

            //receivedMesg Otherplayer disconnect
            #region received Disconnect mesg

            if (temp[0] == "8")
            {
                MessageBox.Show("Other player disconnected!", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BeginInvoke(new PerformClick(PfmClick), cmdDisconnect);
            }

            #endregion

            //receivedMesg Server down
            #region received Disconnect mesg

            if (temp[0] == "9")
            {
                MessageBox.Show("Server is down", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                serverdown = true;
                this.BeginInvoke(new PerformClick(PfmClick), cmdDisconnect);
            }

            #endregion
        }

        #endregion

        #region [   -   Delegate   -   ]

        //Add card to form
        public delegate void AddCardtoForm(Card Temp);
        private void AddCrdtoForm(Card Temp)
        {
            this.Controls.Add(Temp);
        }

        //Remove card to form
        public delegate void RemoveCardfromForm(Card Temp);
        private void RevCrdfromForm(Card Temp)
        {
            this.Controls.Remove(Temp);
        }

        //Click Button
        public delegate void PerformClick(Button Butt);
        private void PfmClick(Button Butt)
        {
            Butt.PerformClick();
        }

        //Enable Button
        public delegate void EnableButton(Button Butt);
        private void EnbBtt(Button Butt)
        {
            Butt.Enabled = true;
        }

        //Disable Button
        public delegate void DisableButton(Button Butt);
        private void DsbBtt(Button Butt)
        {
            Butt.Enabled = false;
        }

        //Show Button
        public delegate void ShowButton(Button Butt);
        private void ShwBtt(Button Butt)
        {
            Butt.Visible = true;
        }

        //Hide Button
        public delegate void HideButton(Button Butt);
        private void HdBtt(Button Butt)
        {
            Butt.Visible = false;
        }

        //Show picturebox
        public delegate void ShowPicturebox(PictureBox Pbx);
        private void ShwPbx(PictureBox Pbx)
        {
            Pbx.Visible = true;
        }

        //Hide picturebox
        public delegate void HidePicturebox(PictureBox Pbx);
        private void HdPbx(PictureBox Pbx)
        {
            Pbx.Visible = false;
        }

        //Change lable text
        public delegate void ChangeLableText(Label Lbl, string s);
        private void ChgLblText(Label Lbl, string s)
        {
            Lbl.Text = s;
        }

        //Start timer
        public delegate void StartTimer(System.Windows.Forms.Timer tmr);
        private void StrTimer(System.Windows.Forms.Timer tmr)
        {
            tmr.Start();
        }

        //Stop timer
        public delegate void StopTimer(System.Windows.Forms.Timer tmr);
        private void StpTimer(System.Windows.Forms.Timer tmr)
        {
            tmr.Stop();
        }

        //RelocateX
        public delegate void RelocateX(Form frm, int x);
        private void RecX(Form frm, int x)
        {
            frm.Location = new Point(x, frm.Location.Y);
        }

        //RelocateY
        public delegate void RelocateY(Form frm, int y);
        private void RecY(Form frm, int y)
        {
            frm.Location = new Point(frm.Location.X, y);
        }
        
        //Relocate Form
        public delegate void Relocate(Form frm, int x, int y);
        private void Rec(Form frm, int x, int y)
        {
            frm.Location = new Point(x, y);
        }
        
        //Close Form
        public delegate void CloseForm(Form frm);
        private void ClsForm(Form frm)
        {
            frm.Close();
        }

        //Bring to front
        public delegate void BringtoFront(Form frm);
        private void BrgtoFront(Form frm)
        {
            frm.BringToFront();
        }

        //Bring to front
        public delegate void VisibleTrue(Form frm);
        private void VsbTrue(Form frm)
        {
            frm.Visible=true;
        }

        //Change ProgressBar value
        public delegate void ChangePbrValue(ProgressBar  pbr, int i);
        private void ChgPbrValue(ProgressBar pbr, int i)
        {
            pbr.Value = i;
        }

        //Show ProgressBar
        public delegate void ShowProgressbar(ProgressBar pbr);
        private void ShwProgressbar(ProgressBar pbr)
        {
            pbr.Visible = true;
        }

        //Hide ProgressBar
        public delegate void HideProgressbar(ProgressBar pbr);
        private void HdProgressbar(ProgressBar pbr)
        {
            pbr.Visible = false;
        }

        //Enable TextBox
        public delegate void EnableTexbox(MaskedTextBox Txt);
        private void EnbTxt(MaskedTextBox Txt)
        {
            Txt.Enabled = true;
        }

        #endregion

    }
}
