/* CSE 381 - String Matcher
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S5.
*
*  Instructions: Implement the Match and BuildTable functions per the instructions
*  in the comments.  Run all tests in StringMatcherTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class StringMatcher
{
    /* Find all matches of the pattern in the string of text given a list
     * of all valid input characters.  This function needs to build Finite
     * State Machine table by calling BuildFSM.
     *
     *  Inputs:
     *     text - string to search for pattern
     *     pattern - substring to search in the text
     *     inputs - valid characters using in the text and pattern
     *  Outputs:
     *     list of indices where the pattern matched (last char of pattern match)
     */
    public static List<int> MatchPattern(string text, string pattern, List<char> inputs)
    {
        // list to store match positions
        var result = new List<int>();
        // build the finite state machine
        var fsm = BuildFSM(pattern, inputs);
        // start from the initial state
        int state = 0;
        // iterate over each character in the text
        for (int i = 0; i < text.Length; i++)
        {
            // get current character
            char c = text[i];
            // transition to next state or reset to 0 if no transition
            state = fsm[state].ContainsKey(c) ? fsm[state][c] : 0;
            // if final state reached, pattern matched
            if (state == pattern.Length)
            {
                // add index of last matching character
                result.Add(i);
            }
        }
        // return list of match indices
        return result;
    }

    /* Build the Finite State Machine table for the pattern and list of valid
     * inputs provided.
     *
     *  Inputs:
     *     pattern - string to match
     *     inputs - valid list of characters that could be seen
     *  Outputs:
     *     Finite State Machine defined by a list of dictionaries.  Each index
     *     in the list represents a state in the FSM (index 0 is first).  The
     *     dictionary shows the next state to goto for each of the valid
     *     inputs that can occur.
     */
    public static List<Dictionary<char, int>> BuildFSM(string pattern, List<char> inputs)
    {
        // length of the pattern
        int m = pattern.Length;
        // list to hold fsm states
        var fsm = new List<Dictionary<char, int>>();
        // loop over each state (including final state)
        for (int k = 0; k <= m; k++)
        {
            // dictionary for transitions from this state
            var transitions = new Dictionary<char, int>();
            // for each valid input character
            foreach (char a in inputs)
            {
                // append character to current prefix
                string prefix = pattern.Substring(0, k) + a;
                // max possible next state
                int nextState = Math.Min(m, k + 1);
                // reduce nextState until prefix suffix matches pattern prefix
                while (!pattern.StartsWith(prefix.Substring(prefix.Length - nextState)) && nextState > 0)
                    nextState--;
                // assign transition to calculated next state
                transitions[a] = nextState;
            }
            // add transitions for this state to the fsm
            fsm.Add(transitions);
        }
        // return the full fsm
        return fsm;
    }
}