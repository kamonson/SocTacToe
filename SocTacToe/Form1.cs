/*
What we need to do next:
    Add Socket!
        Server Starts with blank _state
        Client1 recieves Server _state and loads it
        Client2 recieves Server _state and loads it
        Client1 Changes _state
        Client2 is locked out of _state changing
        Server and Client 2 wait
        Client1 pushes up _state to server
        Client1 and Client 2 refresh their _state
        Client2 Changes _state
        Client1 is locked out of changing their _state
        Server and Client1 wait
        Server2 pushes _state to server

    Make a Queue
        Players can watch game while they wait their turn to play
            Winner stays on
            Looser goes to back of queue
            Cat's game both are loosers

    Known bug: ShowPicture .bringtofront() loses button graphics
*/

using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using SocTacToe.Properties;

namespace SocTacToe
{
    public partial class SocTacToe : Form
    {
        IPAddress _ip;
        int _port;
        private bool _winner; //_turn tue if win
        private bool _turn = false; //X True O False
        private const string P1 = "X"; //player 1 is x
        private const string P2 = "O"; //player 2 is o
        private int _turnNumber; //track number of games after 9 moves cat's
        //private readonly State _state = new State(); //_state to be passed around
        readonly PictureBox _pictureBox1 = new PictureBox(); //innitialize picture box to be used
        public SocTacToe() //start up make whats used
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

                //System.Threading.Timer timer = new System.Threading.Timer(UpdateBoard, "Some state",
                //    TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
                //Thread.Sleep(1000); // Wait a bit over 1second

                var timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(UpdateBoard);
                timer1.Interval = 1000; // in miliseconds
                timer1.Start();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //about, needs updating
        {
            MessageBox.Show(@"CS 313 networking project" + Environment.NewLine
                + @"By: Zeus and Brodi" + Environment.NewLine
                + @"Rules:" + Environment.NewLine
                + @"Seriously? I think you'll figure it out...", @"Soc Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //quit
        {
            SynchronousSocketClient.sender.Shutdown(SocketShutdown.Both);
            SynchronousSocketClient.sender.Close();
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e) //on any button click run this action, check if player should play, set buttons to _state, make move, set _state to buttons, end _turn
        {
            //State.GetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn);
            if (!_turn) return; //no clicking if not your _turn
            if (_winner) return; // no clicking after winning
            var btn = (Button)sender; //make a var
            if (btn.Text == P1 || btn.Text == P2) return; // safe guard from turning changing button
            btn.BackColor = Color.Black;//background color of buttons                                       
            CheckForWin();  //call 2x instant win results and check for win results begin and end _turn
            btn.Text = _turn ? P2 : P1;//check _turn, if 0 is X if 1 is O
            btn.ForeColor = _turn ? Color.Crimson : Color.Aqua; //check _turn set color, if 0 make crimson, if 1 make aqua
            _turn = !_turn; //change _turn
            _turnNumber++; //inc trun number
            State.SetState(button_A1, button_A2, button_A3, button_B1, button_B2, button_B3, button_C1, button_C2, button_C3, Lbl_Msg, ref _turn); //set _state to current buttons
            CheckForWin(); //call 2x instant win results and check for win results begin and end _turn
            SynchronousSocketClient.StartClient(_ip, _port);
        }

        private void CheckForWin() /*check - | \ for a _winner*/
        {
            /*hor win*/
            if ((button_A1.Text == button_A2.Text) && (button_A2.Text == button_A3.Text) && (button_A1.Text != " "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.xa : Resources.oa);
                _winner = true;
            }
            else if ((button_B1.Text == button_B2.Text) && (button_B2.Text == button_B3.Text) && (button_B1.Text != " "))
            {
                Lbl_Msg.Text = button_B1.Text + @" Wins!";
                ShowPicture(button_B1.Text == P1 ? Resources.xb : Resources.ob);
                _winner = true;
            }
            else if ((button_C1.Text == button_C2.Text) && (button_C2.Text == button_C3.Text) && (button_C1.Text != " "))
            {
                Lbl_Msg.Text = button_C1.Text + @" Wins!";
                ShowPicture(button_C3.Text == P1 ? Resources.xc : Resources.oc);
                _winner = true;
            }
            /*end hor win*/

            /*vert win*/
            else if ((button_A1.Text == button_B1.Text) && (button_B1.Text == button_C1.Text) && (button_A1.Text != " "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.x1 : Resources.o1);
                _winner = true;
            }
            else if ((button_A2.Text == button_B2.Text) && (button_B2.Text == button_C2.Text) && (button_A2.Text != " "))
            {
                Lbl_Msg.Text = button_A2.Text + @" Wins!";
                ShowPicture(button_A2.Text == P1 ? Resources.x2 : Resources.o2);
                _winner = true;
            }
            else if ((button_A3.Text == button_B3.Text) && (button_B3.Text == button_C3.Text) && (button_A3.Text != " "))
            {
                Lbl_Msg.Text = button_A3.Text + @" Wins!";
                ShowPicture(button_A3.Text == P1 ? Resources.x3 : Resources.o3);
                _winner = true;
            }
            /*end vert win*/

            /*diag win*/
            else if ((button_A1.Text == button_B2.Text) && (button_B2.Text == button_C3.Text) && (button_A1.Text != " "))
            {
                Lbl_Msg.Text = button_A1.Text + @" Wins!";
                ShowPicture(button_A1.Text == P1 ? Resources.xda1c3 : Resources.oda1c3);
                _winner = true;
            }
            else if ((button_A3.Text == button_B2.Text) && (button_B2.Text == button_C1.Text) && (button_A3.Text != " "))
            {
                Lbl_Msg.Text = button_A3.Text + @" Wins!";
                ShowPicture(button_A3.Text == P1 ? Resources.xda3c1 : Resources.oda3c1);
                _winner = true;
            }
            /*end diag win*/

            else if (_turnNumber == 9) //no winner
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
