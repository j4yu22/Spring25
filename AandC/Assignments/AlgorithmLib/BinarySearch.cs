/* CSE 381 - Binary Search
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S5.
*
*  Instructions: Implement the _Search function per the instructions
*  in the comments.  Run all tests in BinarySearchTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class BinarySearch
{
    /* Use Binary Search to search for an item in a list.
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
        // Start the recursion
        return _Search(data, target, 0, data.Count - 1);
    }

    /* Use Binary Search to recursively search for an item in a sublist.
    *
    *  Inputs:
    *     data - list to search
    *     target - value to search for
    *     first - starting index of sublist of data
    *     last - ending index of sublist of data
    *  Outputs:
    *     Index where target was found
    *
    *  Note: Return -1 if target not found
    */
    public static int _Search<T>(List<T> data, T target, int first, int last) where T : IComparable<T>
    {
        // Base case: the search range is invalid
        if (first > last)
            return -1;

        // Calculate the midpoint of the current search range
        int mid = (first + last) / 2;

        // Compare the target with the middle element
        int comparison = target.CompareTo(data[mid]);

        if (comparison == 0)
        {
            // Match found at mid
            return mid;
        }
        else if (comparison < 0)
        {
            // Target is smaller, search left half
            return _Search(data, target, first, mid - 1);
        }
        else
        {
            // Target is larger, search right half
            return _Search(data, target, mid + 1, last);
        }
    }

}