using System;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SocTacToe
{
    public static class State
    {
        private static string _a1 = "";
        private static string _a2 = "";
        private static string _a3 = "";
        private static string _b1 = "";
        private static string _b2 = "";
        private static string _b3 = "";
        private static string _c1 = "";
        private static string _c2 = "";
        private static string _c3 = "";
        private static string _msg = "";
        private static bool _turn;
        private static string _alphaTurn = "";
        private static readonly ArrayList _vectorStates = new ArrayList();
        private static string _stateString;

        public static void UpdateSetState(string state) //set state to player strings info
        {
            _vectorStates.Clear();
            Regex regex = new Regex(@"!");
            Match match = regex.Match(state);
            while (match.NextMatch().Success)
            {
                _vectorStates.Add(match.Value);
            }
            _vectorStates.RemoveAt(_vectorStates.Count - 1);

            _a1 = (string)_vectorStates[0];
            _a2 = (string)_vectorStates[0];
            _a3 = (string)_vectorStates[0];
            _b1 = (string)_vectorStates[0];
            _b2 = (string)_vectorStates[0];
            _b3 = (string)_vectorStates[0];
            _c1 = (string)_vectorStates[0];
            _c2 = (string)_vectorStates[0];
            _c3 = (string)_vectorStates[0];
            _msg = (string)_vectorStates[0];
            _alphaTurn = (string)_vectorStates[0];
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

            _vectorStates.Clear();
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
            UpdateSetStateString(_alphaTurn = turn ? "t" : "n");
            _stateString += "<EOF>";
        }

        public static void GetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref bool turn) //set buttons to state
        {
            if (_vectorStates.Count != 0)
            {
                a1.Text = (string)_vectorStates[0];
                a2.Text = (string)_vectorStates[1];
                a3.Text = (string)_vectorStates[2];
                b1.Text = (string)_vectorStates[3];
                b2.Text = (string)_vectorStates[4];
                b3.Text = (string)_vectorStates[5];
                c1.Text = (string)_vectorStates[6];
                c2.Text = (string)_vectorStates[7];
                c3.Text = (string)_vectorStates[8];
                msg.Text = (string)_vectorStates[9];
                turn = (string)_vectorStates[10] == "y";
            }
        }

        public static void ResetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref int turnNumber, ref bool winner, PictureBox pbox, ref bool turn) //restart state
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