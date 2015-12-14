using System;
using System.Drawing;
using System.Windows.Forms;

namespace SocTacToe
{
    /// <summary>
    /// Use for storing states and updating gameboard
    /// </summary>
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
        private static string _alphaTurn = "S";
        private static string _stateString;

        /// <summary>
        /// Convert state string to state
        /// </summary>
        /// <param name="state">StateString</param>
        public static void UpdateSetState(string state)
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

        /// <summary>
        /// Get state string
        /// </summary>
        /// <returns>State String</returns>
        public static string GetStateString()
        {
            return _stateString;
        }

        /// <summary>
        /// Used in generating state string add ! between state elements
        /// </summary>
        /// <param name="state">State String</param>
        private static void UpdateSetStateString(string state)
        {
            _stateString += (state + "!");
        }

        /// <summary>
        /// Set state equal to board, create state string
        /// </summary>
        /// <param name="a1">Button</param>
        /// <param name="a2">Button</param>
        /// <param name="a3">Button</param>
        /// <param name="b1">Button</param>
        /// <param name="b2">Button</param>
        /// <param name="b3">Button</param>
        /// <param name="c1">Button</param>
        /// <param name="c2">Button</param>
        /// <param name="c3">Button</param>
        /// <param name="msg">MSG Label</param>
        /// <param name="turn">Bool Turn</param>
        public static void SetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref bool turn)
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
            UpdateSetStateString(_alphaTurn = turn ? "C" : "S");
            _stateString += "<EOF>";
            UpdateSetState(_stateString);
        }

        /// <summary>
        /// Set board equal to state
        /// </summary>
        /// <param name="a1">Button</param>
        /// <param name="a2">Button</param>
        /// <param name="a3">Button</param>
        /// <param name="b1">Button</param>
        /// <param name="b2">Button</param>
        /// <param name="b3">Button</param>
        /// <param name="c1">Button</param>
        /// <param name="c2">Button</param>
        /// <param name="c3">Button</param>
        /// <param name="msg">MSG Label</param>
        /// <param name="turn">Bool Turn</param>
        public static void GetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref bool turn)
        {
            a1.Text = _a1;
            if (a1.Text == @"X") a1.ForeColor = Color.Crimson;
            else if (a1.Text == @"O") a1.ForeColor = Color.Aqua;
            else a1.ForeColor = Color.Black;

            a2.Text = _a2;
            if (a2.Text == @"X") a2.ForeColor = Color.Crimson;
            else if (a2.Text == @"O") a2.ForeColor = Color.Aqua;
            else a2.ForeColor = Color.Black;

            a3.Text = _a3;
            if (a3.Text == @"X") a3.ForeColor = Color.Crimson;
            else if (a3.Text == @"O") a3.ForeColor = Color.Aqua;
            else a3.ForeColor = Color.Black;

            b1.Text = _b1;
            if (b1.Text == @"X") b1.ForeColor = Color.Crimson;
            else if (b1.Text == @"O") b1.ForeColor = Color.Aqua;
            else b1.ForeColor = Color.Black;

            b2.Text = _b2;
            if (b2.Text == @"X") b2.ForeColor = Color.Crimson;
            else if (b2.Text == @"O") b2.ForeColor = Color.Aqua;
            else b2.ForeColor = Color.Black;

            b3.Text = _b3;
            if (b3.Text == @"X") b3.ForeColor = Color.Crimson;
            else if (b3.Text == @"O") b3.ForeColor = Color.Aqua;
            else b3.ForeColor = Color.Black;

            c1.Text = _c1;
            if (c1.Text == @"X") c1.ForeColor = Color.Crimson;
            else if (c1.Text == @"O") c1.ForeColor = Color.Aqua;
            else c1.ForeColor = Color.Black;

            c2.Text = _c2;
            if (c2.Text == @"X") c2.ForeColor = Color.Crimson;
            else if (c2.Text == @"O") c2.ForeColor = Color.Aqua;
            else c2.ForeColor = Color.Black;

            c3.Text = _c3;
            if (c3.Text == @"X") c3.ForeColor = Color.Crimson;
            else if (c3.Text == @"O") c3.ForeColor = Color.Aqua;
            else c3.ForeColor = Color.Black;

            msg.Text = _msg;
            msg.ForeColor = Color.Yellow;

            if (_alphaTurn == "C")
            {
                turn = true;
            }
            else
            {
                turn = false;
            }
        }

        /// <summary>
        /// Set game state to a new game state
        /// </summary>
        /// <param name="a1">Button</param>
        /// <param name="a2">Button</param>
        /// <param name="a3">Button</param>
        /// <param name="b1">Button</param>
        /// <param name="b2">Button</param>
        /// <param name="b3">Button</param>
        /// <param name="c1">Button</param>
        /// <param name="c2">Button</param>
        /// <param name="c3">Button</param>
        /// <param name="msg">MSG Label</param>
        /// <param name="turnNumber">Int Turn Number</param>
        /// <param name="winner">Bool Winner</param>
        /// <param name="pbox">Picture Box</param>
        /// <param name="turn">Bool Turn</param>
        public static void ResetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref int turnNumber, ref bool winner, PictureBox pbox, ref bool turn)
        {
            if (turnNumber < 0) throw new ArgumentOutOfRangeException(nameof(turnNumber));
            a1.Text = @" ";
            a2.Text = @" ";
            a3.Text = @" ";
            b1.Text = @" ";
            b2.Text = @" ";
            b3.Text = @" ";
            c1.Text = @" ";
            c2.Text = @" ";
            c3.Text = @" ";
            msg.Text = @" ";
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
            turn = false;
        }
    }
}