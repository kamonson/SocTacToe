using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SocTacToe
{
    public static class State
    {
        private static string _a1 = " ";
        private static string _a2 = " ";
        private static string _a3 = " ";
        private static string _b1 = " ";
        private static string _b2 = " ";
        private static string _b3 = " ";
        private static string _c1 = " ";
        private static string _c2 = " ";
        private static string _c3 = " ";
        private static string _msg = " ";
        private static bool _turn;
        private static string _alphaTurn = "Y";
        // private static readonly ArrayList _vectorStates = new ArrayList();
        private static string _stateString;

        public static void UpdateSetState(string state) //set state to player strings info
        {
            _stateString = state;

            string[] states = state.Split('!');

            _a1 = states[0];
            _a2 = states[1];
            _a3 = states[2];
            _b1 = states[3];
            _b2 = states[4];
            _b3 = states[5];
            _c1 = states[6];
            _c2 = states[7];
            _c3 = states[8];
            _msg = states[9];
            _alphaTurn = states[10];
        }

        public static bool GetTurn()
        {
            return _turn;
        }

        public static string GetStateString()
        {
            return _stateString;
        }

        private static void UpdateSetStateString(string state) //set strings to state
        {
            _stateString += (state + "!");
        }

        public static void SetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref bool turn) //set state to player buttons info
        {
            _a1 = a1.Text;
            _a2 = a2.Text;
            _a3 = a3.Text;
            _b1 = b1.Text;
            _b2 = b2.Text;
            _b3 = b3.Text;
            _c1 = c1.Text;
            _c2 = c2.Text;
            _c3 = c3.Text;
            _msg = msg.Text;
            _turn = turn;

            _stateString = null;
            UpdateSetStateString(a1.Text);
            UpdateSetStateString(a2.Text);
            UpdateSetStateString(a3.Text);
            UpdateSetStateString(b1.Text);
            UpdateSetStateString(b2.Text);
            UpdateSetStateString(b3.Text);
            UpdateSetStateString(c1.Text);
            UpdateSetStateString(c2.Text);
            UpdateSetStateString(c3.Text);
            UpdateSetStateString(msg.Text);
            UpdateSetStateString(_alphaTurn = turn ? "Y" : "N");
            _stateString += "<EOF>";
        }

        public static void GetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref bool turn) //set buttons to state
        {
            UpdateSetState(_stateString);
            a1.Text = _a1;
            a2.Text = _a2;
            a3.Text = _a3;
            b1.Text = _b1;
            b2.Text = _b2;
            b3.Text = _b3;
            c1.Text = _c1;
            c2.Text = _c2;
            c3.Text = _c3;
            msg.Text = _msg;
            if (_alphaTurn == "Y")
            {
                turn = true;
            }
            else
            {
                turn = false;
            }
        }

        public static void ResetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref int turnNumber, ref bool winner, PictureBox pbox, ref bool turn) //restart state
        {
            if (turnNumber < 0) throw new ArgumentOutOfRangeException(nameof(turnNumber));
            a1.Text = " ";
            a2.Text = " ";
            a3.Text = " ";
            b1.Text = " ";
            b2.Text = " ";
            b3.Text = " ";
            c1.Text = " ";
            c2.Text = " ";
            c3.Text = " ";
            msg.Text = " ";
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
            _a1 = a1.Text;
            _a2 = a2.Text;
            _a3 = a3.Text;
            _b1 = b1.Text;
            _b2 = b2.Text;
            _b3 = b3.Text;
            _c1 = c1.Text;
            _c2 = c2.Text;
            _c3 = c3.Text;
            _msg = msg.Text;
            pbox.Image = null;
            turn = true;
        }
    }
}