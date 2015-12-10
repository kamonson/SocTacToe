using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace ServerSocTacToe
{
    public class State
    {
        private ArrayList _vectorStates = new ArrayList();

        public void SetState(string state) //set state to player strings info
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

        public string GetState() //set strings to state
        {
            string state = null;
            for (int i = 0; i < _vectorStates.Count; i++)
            {
              state += (_vectorStates.IndexOf(i) + Environment.NewLine);
            }
            state += "<EOF>";
            return state;
        }
    }
}