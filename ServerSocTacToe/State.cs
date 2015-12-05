﻿using System;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ServerSocTacToe
{
    public class State
    {
        private ArrayList _vectorStates = new ArrayList();
        private string _stateString;

        public void UpdateSetState(string state) //set state to player strings info
        {
            _vectorStates.Clear();
            Regex regex = new Regex(@"\n");
            Match match = regex.Match(state);
            while (match.Success)
            {
                _vectorStates.Add(match.Value);
            }
            _vectorStates.RemoveAt(_vectorStates.Count - 1);
        }

        public bool GetTurn()
        {
            return Turn;
        }

        public string GetStateString()
        {
            return _stateString;
        }

        public void UpdateGetState(string state) //set strings to state
        {
            for (int i = 0; i < _vectorStates.Count; i++)
            {
              _stateString += (_vectorStates.IndexOf(i) + Environment.NewLine);
            }
        }

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

        private string AlphaTurn { get; set; }
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

            _vectorStates.Clear();
            _stateString = null;
            UpdateGetState(a1.Text);
            UpdateGetState(a2.Text);
            UpdateGetState(a3.Text);
            UpdateGetState(b1.Text);
            UpdateGetState(b2.Text);
            UpdateGetState(b3.Text);
            UpdateGetState(c1.Text);
            UpdateGetState(c2.Text);
            UpdateGetState(c3.Text);
            UpdateGetState(msg.Text);
            UpdateGetState(AlphaTurn = turn ? "t" : "n");
            _stateString += "<EOF>";
        }

        public void GetState(Button a1, Button a2, Button a3, Button b1, Button b2, Button b3, Button c1, Button c2, Button c3, Label msg, ref bool turn) //set buttons to state
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