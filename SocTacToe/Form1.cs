using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using SocTacToe.Properties;
using Timer = System.Windows.Forms.Timer;

namespace SocTacToe
{
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

                Thread clientThread = new Thread(() => SynchronousSocketClient.StartClient(_ip, _port));
                clientThread.Start();

                //System.Threading.Timer timer = new System.Threading.Timer(UpdateBoard, "Some state", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
                //Thread.Sleep(1000); // Wait a bit over 1second

                var timer1 = new Timer();
                timer1.Tick += UpdateBoard;
                timer1.Interval = 500; // in miliseconds
                timer1.Start();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"CS 313 networking project" + Environment.NewLine
                + @"By: Zeus and Brodi" + Environment.NewLine
                + @"Rules:" + Environment.NewLine
                + @"Seriously? I think you'll figure it out...", @"Soc Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SynchronousSocketClient.Sender.Shutdown(SocketShutdown.Both);
            SynchronousSocketClient.Sender.Close();
            Application.Exit();
        }

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
            new Thread(() => SynchronousSocketClient.StartClient(_ip, _port)).Start();
        }

        private void CheckForWin()
        {
            /*hor win*/
            if ((button_A1.Text == button_A2.Text) && (button_A2.Text == button_A3.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.xa : Resources.oa);
                _winner = true;
            }
            else if ((button_B1.Text == button_B2.Text) && (button_B2.Text == button_B3.Text) && (button_B1.Text != @" "))
            {
                Lbl_Msg.Text = button_B1.Text + @" Wins!";
                ShowPicture(button_B1.Text == P1 ? Resources.xb : Resources.ob);
                _winner = true;
            }
            else if ((button_C1.Text == button_C2.Text) && (button_C2.Text == button_C3.Text) && (button_C1.Text != @" "))
            {
                Lbl_Msg.Text = button_C1.Text + @" Wins!";
                ShowPicture(button_C3.Text == P1 ? Resources.xc : Resources.oc);
                _winner = true;
            }
            /*end hor win*/

            /*vert win*/
            else if ((button_A1.Text == button_B1.Text) && (button_B1.Text == button_C1.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.x1 : Resources.o1);
                _winner = true;
            }
            else if ((button_A2.Text == button_B2.Text) && (button_B2.Text == button_C2.Text) && (button_A2.Text != @" "))
            {
                Lbl_Msg.Text = button_A2.Text + @" Wins!";
                ShowPicture(button_A2.Text == P1 ? Resources.x2 : Resources.o2);
                _winner = true;
            }
            else if ((button_A3.Text == button_B3.Text) && (button_B3.Text == button_C3.Text) && (button_A3.Text != @" "))
            {
                Lbl_Msg.Text = button_A3.Text + @" Wins!";
                ShowPicture(button_A3.Text == P1 ? Resources.x3 : Resources.o3);
                _winner = true;
            }
            /*end vert win*/

            /*diag win*/
            else if ((button_A1.Text == button_B2.Text) && (button_B2.Text == button_C3.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.xda1c3 : Resources.oda1c3);
                _winner = true;
            }
            else if ((button_A3.Text == button_B2.Text) && (button_B2.Text == button_C1.Text) && (button_A3.Text != @" "))
            {
                Lbl_Msg.Text = button_A3.Text + @" Wins!";
                ShowPicture(button_A3.Text == P1 ? Resources.xda3c1 : Resources.oda3c1);
                _winner = true;
            }
            /*end diag win*/

            else if (_turnNumber == 9)
            {
                Lbl_Msg.Text = @"Cat's Game!";
                ShowPicture(Resources.cats);
                _winner = true;
            }
        }

        private void ShowPicture(Image pic)
        {
            _pictureBox1.Size = new Size(400, 400);
            Controls.Add(_pictureBox1);
            _pictureBox1.BackColor = Color.Transparent;
            _pictureBox1.Image = pic;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            State.ResetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turnNumber, ref _winner, _pictureBox1, ref _turn);
            State.SetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
        }

        private void UpdateBoard(object o, EventArgs e)
        {
            State.GetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
            CheckForWin();
        }
    }
}
