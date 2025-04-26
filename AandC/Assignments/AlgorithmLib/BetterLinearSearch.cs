/* CSE 381 - BetterLinearSerach
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S5.
*
*  Instructions: Implement the Search function per the instructions
*  in the comments.  Run all tests in BetterLinearSearchTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class BetterLinearSearch
{

    /* Search for an item in a list.  Ignore duplicates by exiting
    *  as soon as the first match is found.
    *
    *  Inputs:
    *     data - list to search
    *     target - value to search for
    *  Outputs:
    *     Index where target was found
    *
    *  Note: Return -1 if target not found
    */
    public static int Search<T>(List<T> data, T target) where T : IComparable<T>
    {
        for (int i = 0; i < data.Count; i++) // iterate through the list
        {
            if (data[i].Equals(target)) // check if the current item is equal to the target
            {
                return i; // return the index of the found item
            }
        }
        return -1; // return -1 if the target is not found
    }
}