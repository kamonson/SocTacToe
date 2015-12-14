using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ServerSocTacToe.Properties;


namespace ServerSocTacToe
{
    public partial class SocTacToe : Form
    {
        private bool _winner;
        private bool _turn = true;
        private const string P1 = "X";
        private const string P2 = "O";
        private int _turnNumber;
        readonly PictureBox _pictureBox1 = new PictureBox();
        public delegate void Del();
        delegate void SetTextCallback();

        public SocTacToe()
        {
            InitializeComponent();

            State.ResetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turnNumber, ref _winner, _pictureBox1, ref _turn);
            State.SetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
            Del delegateHandler = UpdateBoard;
            new Thread(() => SynchronousSocketListener.StartListening(delegateHandler)).Start();
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
            if (SynchronousSocketListener.Handler != null)
            {
                new Thread(SynchronousSocketListener.ShutdownConnection).Start();
            }
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            State.GetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
            if (!_turn) return;
            if (button_A1.Text != @"X" && button_A2.Text != @"X" && button_A3.Text != @"X" && button_B1.Text != @"X" &&
                button_B2.Text != @"X" && button_B3.Text != @"X" && button_C1.Text != @"X" && button_C2.Text != @"X" &&
                button_C3.Text != @"X")
            {
                _winner = false;
            }
            if (_winner) return;
            var btn = (Button)sender;
            if (btn.Text == P1 || btn.Text == P2) return;
            btn.BackColor = Color.Black;
            CheckForWin();
            btn.Text = _turn ? P1 : P2;
            btn.ForeColor = _turn ? Color.Crimson : Color.Aqua;
            _turn = !_turn;
            _turnNumber++;
            State.SetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
            SynchronousSocketListener.Handler.Send(Encoding.ASCII.GetBytes(State.GetStateString()));
            CheckForWin();
        }

        private void CheckForWin()
        {
            /*hor win*/
            if ((button_A1.Text == button_A2.Text) && (button_A2.Text == button_A3.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.xa : Resources.oa);
                EndGame();
            }
            else if ((button_B1.Text == button_B2.Text) && (button_B2.Text == button_B3.Text) && (button_B1.Text != @" "))
            {
                Lbl_Msg.Text = button_B1.Text + @" Wins!";
                ShowPicture(button_B1.Text == P1 ? Resources.xb : Resources.ob);
                EndGame();
            }
            else if ((button_C1.Text == button_C2.Text) && (button_C2.Text == button_C3.Text) && (button_C1.Text != @" "))
            {
                Lbl_Msg.Text = button_C1.Text + @" Wins!";
                ShowPicture(button_C3.Text == P1 ? Resources.xc : Resources.oc);
                EndGame();
            }
            /*end hor win*/

            /*vert win*/
            else if ((button_A1.Text == button_B1.Text) && (button_B1.Text == button_C1.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.x1 : Resources.o1);
                EndGame();
            }
            else if ((button_A2.Text == button_B2.Text) && (button_B2.Text == button_C2.Text) && (button_A2.Text != @" "))
            {
                Lbl_Msg.Text = button_A2.Text + @" Wins!";
                ShowPicture(button_A2.Text == P1 ? Resources.x2 : Resources.o2);
                EndGame();
            }
            else if ((button_A3.Text == button_B3.Text) && (button_B3.Text == button_C3.Text) && (button_A3.Text != @" "))
            {
                Lbl_Msg.Text = button_A3.Text + @" Wins!";
                ShowPicture(button_A3.Text == P1 ? Resources.x3 : Resources.o3);
                EndGame();
            }
            /*end vert win*/

            /*diag win*/
            else if ((button_A1.Text == button_B2.Text) && (button_B2.Text == button_C3.Text) && (button_A1.Text != @" "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.xda1c3 : Resources.oda1c3);
                EndGame();
            }
            else if ((button_A3.Text == button_B2.Text) && (button_B2.Text == button_C1.Text) && (button_A3.Text != @" "))
            {
                Lbl_Msg.Text = button_A3.Text + @" Wins!";
                ShowPicture(button_A3.Text == P1 ? Resources.xda3c1 : Resources.oda3c1);
                EndGame();
            }
            /*end diag win*/

            else if (button_A1.Text != @" " && button_A2.Text != @" " && button_A3.Text != @" " && button_B1.Text != @" " && button_B2.Text != @" " && button_B3.Text != @" " && button_C1.Text != @" " && button_C2.Text != @" " && button_C3.Text != @" ")
            {
                Lbl_Msg.Text = @"Cat's Game!";
                ShowPicture(Resources.cats);
                EndGame();
            }
            else
            {
                _pictureBox1.Hide();
            }
        }

        private void EndGame()
        {
            _winner = true;
            SynchronousSocketListener.Handler.Send(Encoding.ASCII.GetBytes(State.GetStateString()));
            _turn = false;
        }

        private void ShowPicture(Image pic)
        {
            _pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            _pictureBox1.Anchor = AnchorStyles.None;
            _pictureBox1.Location = new Point(button_A1.Location.X - 36, button_A1.Location.Y - 48);
            Controls.Add(_pictureBox1);
            _pictureBox1.BackColor = Color.Transparent;
            _pictureBox1.Image = pic;
            _pictureBox1.Show();
        }

        private void UpdateBoard()
        {
            if (label1.InvokeRequired)
            {
                SetTextCallback d = UpdateBoard;
                Invoke(d, new object[] { });
            }
            else
            {
                State.GetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
                CheckForWin();
                label1.Text = @"IP Adress: " + SynchronousSocketListener.GetIpString() + @"   Port: 11000";
            }
        }
    }
}
