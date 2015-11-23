using System;
using System.Drawing;
using System.Windows.Forms;

namespace SynchronousSocketListener
{
    public class State
    {
        /*Auto Properties*/
        private string A1 { get; set; }

        private string A2 { get; set; }

        private string A3 { get; set; }

        private string B1 { get; set; }

        private string B2 { get; set; }

        private string B3 { get; set; }

        private string C1 { get; set; }

        private string C2 { get; set; }

        private string C3 { get; set; }

        private string Msg { get; set; }

        private bool Turn { get; set; }
        /*End Auto Properties*/

        public void SetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref bool turn) //set state to player buttons info
        {
            A1 = a1.Text;
            A2 = a2.Text;
            A3 = a3.Text;
            B1 = b1.Text;
            B2 = b2.Text;
            B3 = b3.Text;
            C1 = c1.Text;
            C2 = c2.Text;
            C3 = c3.Text;
            Msg = msg.Text;
            Turn = turn;

        }

        public void GetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref bool turn) //set buttons to state
        {
            a1.Text = A1;
            a2.Text = A2;
            a3.Text = A3;
            b1.Text = B1;
            b2.Text = B2;
            b3.Text = B3;
            c1.Text = C1;
            c2.Text = C2;
            c3.Text = C3;
            msg.Text = Msg;
            turn = Turn;
        }

        public void ResetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref int turnNumber, ref bool winner, PictureBox pbox, ref bool turn) //restart state
        {
            if (turnNumber < 0) throw new ArgumentOutOfRangeException(nameof(turnNumber));
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
            msg.Text = "";
            a1.ForeColor = Color.Black;
            a2.ForeColor = Color.Black;
            a3.ForeColor = Color.Black;
            b1.ForeColor = Color.Black;
            b2.ForeColor = Color.Black;
            b3.ForeColor = Color.Black;
            c1.ForeColor = Color.Black;
            c2.ForeColor = Color.Black;
            c3.ForeColor = Color.Black;
            turnNumber = 0;
            winner = false;
            A1 = a1.Text;
            A2 = a2.Text;
            A3 = a3.Text;
            B1 = b1.Text;
            B2 = b2.Text;
            B3 = b3.Text;
            C1 = c1.Text;
            C2 = c2.Text;
            C3 = c3.Text;
            Msg = msg.Text;
            pbox.Image = null;
            turn = false;
        }
    }
}
