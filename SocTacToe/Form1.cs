using System;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using SocTacToe.Properties;

namespace SocTacToe
{
    /// <summary>
    /// Class controlls the flow of the game, calls state and socket methods to implement state setting and passing
    /// </summary>
    public partial class SocTacToe : Form
    {
        IPAddress _ip;
        int _port;
        private bool _winner;
        private bool _turn;
        private const string P1 = "X";
        private const string P2 = "O";
        private int _turnNumber;
        readonly PictureBox _pictureBox1 = new PictureBox();
        public delegate void Del();
        Del delegateHandler;
        delegate void SetTextCallback();
        
        /// <summary>
        /// Sets a blank state, turn/win variables to defualt, starts socket and ip info form
        /// </summary>
        public SocTacToe()
        {
            InitializeComponent();

            State.ResetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turnNumber, ref _winner, _pictureBox1, ref _turn); //zero out _state
            State.SetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn); //set _state to current buttons

            using (IpPortForm ipPortForm = new IpPortForm())
            {
                if (ipPortForm.ShowDialog() == DialogResult.OK)
                {
                }
                _ip = ipPortForm.GetIp();
                _port = ipPortForm.GetPort();
                delegateHandler = UpdateBoard;
                Thread clientThread = new Thread(() => SynchronousSocketClient.StartClient(_ip, _port, delegateHandler));
                clientThread.Start();
            }
        }

        /// <summary>
        /// Displays help info
        /// </summary>
        /// <param name="sender">Help was clicked</param>
        /// <param name="e">Click event</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"CS 313 networking project" + Environment.NewLine
                + @"By: Zeus and Brodi" + Environment.NewLine
                + @"Rules:" + Environment.NewLine
                + @"Seriously? I think you'll figure it out...", @"Soc Tac Toe");
        }

        /// <summary>
        /// Quit command
        /// </summary>
        /// <param name="sender">Exit was clicked</param>
        /// <param name="e">Click Event</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (SynchronousSocketClient.Sender != null)
                {
                    new Thread(SynchronousSocketClient.ShutdownConnection).Start();
                }
                Application.Exit();
            }
        }

        /// <summary>
        /// Check for win, update state, listen for move, update turn, update state, pass state, check for win
        /// </summary>
        /// <param name="sender">Button was clicked</param>
        /// <param name="e">Click Event</param>
        private void button_click(object sender, EventArgs e)
        {
            State.GetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
            if (!_turn) return;
            if (_winner) return;
            var btn = (Button)sender;
            if (btn.Text == P1 || btn.Text == P2) return;
            btn.BackColor = Color.Black;
            CheckForWin();
            btn.Text = _turn ? P2 : P1;
            btn.ForeColor = _turn ? Color.Crimson : Color.Aqua;
            _turn = !_turn;
            _turnNumber++;
            State.SetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
            CheckForWin();
            new Thread(() => SynchronousSocketClient.StartClient(_ip, _port, delegateHandler)).Start();
        }

        /// <summary>
        /// Check to see if win occured or draw, if so show where
        /// </summary>
        private void CheckForWin()
        {
            /*hor win*/
            if ((button_A1.Text == button_A2.Text) && (button_A2.Text == button_A3.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.xa : Resources.oa);
                _winner = true;
                _turn = true;
            }
            else if ((button_B1.Text == button_B2.Text) && (button_B2.Text == button_B3.Text) && (button_B1.Text != @" "))
            {
                Lbl_Msg.Text = button_B1.Text + @" Wins!";
                ShowPicture(button_B1.Text == P1 ? Resources.xb : Resources.ob);
                _winner = true;
                _turn = true;
            }
            else if ((button_C1.Text == button_C2.Text) && (button_C2.Text == button_C3.Text) && (button_C1.Text != @" "))
            {
                Lbl_Msg.Text = button_C1.Text + @" Wins!";
                ShowPicture(button_C3.Text == P1 ? Resources.xc : Resources.oc);
                _winner = true;
                _turn = true;
            }
            /*end hor win*/

            /*vert win*/
            else if ((button_A1.Text == button_B1.Text) && (button_B1.Text == button_C1.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.x1 : Resources.o1);
                _winner = true;
                _turn = true;
            }
            else if ((button_A2.Text == button_B2.Text) && (button_B2.Text == button_C2.Text) && (button_A2.Text != @" "))
            {
                Lbl_Msg.Text = button_A2.Text + @" Wins!";
                ShowPicture(button_A2.Text == P1 ? Resources.x2 : Resources.o2);
                _winner = true;
                _turn = true;
            }
            else if ((button_A3.Text == button_B3.Text) && (button_B3.Text == button_C3.Text) && (button_A3.Text != @" "))
            {
                Lbl_Msg.Text = button_A3.Text + @" Wins!";
                ShowPicture(button_A3.Text == P1 ? Resources.x3 : Resources.o3);
                _winner = true;
                _turn = true;
            }
            /*end vert win*/

            /*diag win*/
            else if ((button_A1.Text == button_B2.Text) && (button_B2.Text == button_C3.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.xda1c3 : Resources.oda1c3);
                _winner = true;
                _turn = true;
            }
            else if ((button_A3.Text == button_B2.Text) && (button_B2.Text == button_C1.Text) && (button_A3.Text != @" "))
            {
                Lbl_Msg.Text = button_A3.Text + @" Wins!";
                ShowPicture(button_A3.Text == P1 ? Resources.xda3c1 : Resources.oda3c1);
                _winner = true;
                _turn = true;
            }
            /*end diag win*/

            else if (button_A1.Text != @" " && button_A2.Text != @" " && button_A3.Text != @" " && button_B1.Text != @" " &&
                     button_B2.Text != @" " && button_B3.Text != @" " && button_C1.Text != @" " && button_C2.Text != @" " &&
                     button_C3.Text != @" ")
            {
                Lbl_Msg.Text = @"Cat's Game!";
                ShowPicture(Resources.cats);
                _winner = true;
                _turn = true;
            }
            else
            {
                _pictureBox1.Hide();
            }
        }

        /// <summary>
        /// display win/draw picture
        /// </summary>
        /// <param name="pic">Line based on win, C for draw</param>
        private void ShowPicture(Image pic)
        {
            _pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            _pictureBox1.Anchor = AnchorStyles.None;
            _pictureBox1.Location = new Point(button_A1.Location.X - 36, button_A1.Location.Y - 48);
            Controls.Add(_pictureBox1);
            _pictureBox1.BackColor = Color.Transparent;
            _pictureBox1.Image = pic;
            Top = (this.ClientSize.Height - Height) / 2;
            _pictureBox1.Show();
        }

        /// <summary>
        /// Start New Game (client control only) on player turn
        /// </summary>
        /// <param name="sender">New Game Clicked</param>
        /// <param name="e">Click Event</param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_turn == false)
            {
                Lbl_Msg.Text = @"Wait Your Turn Before Starting New Game";
            }
            else
            {
                State.ResetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turnNumber, ref _winner, _pictureBox1, ref _turn);
                State.SetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
                new Thread(() => SynchronousSocketClient.StartClient(_ip, _port, delegateHandler)).Start();
            }
        }

        /// <summary>
        /// Delegate function for updating board--called in socket class
        /// </summary>
        private void UpdateBoard()
        {
            if (Lbl_Msg.InvokeRequired)
            {
                SetTextCallback d = UpdateBoard;
                Invoke(d, new object[] { });
            }
            else
            {
                State.GetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2,
                    button_C3, Lbl_Msg, ref _turn);
                CheckForWin();
            }
        }
    }
}
