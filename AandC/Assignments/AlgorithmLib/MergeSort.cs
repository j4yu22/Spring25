/* CSE 381 - Merge Sort
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S5.
*
*  Instructions: Implement the Merge and _Sort functions per the instructions
*  in the comments.  Run all tests in MergeSortTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class MergeSort
{
    /* Use Merge Sort to sort a list of values in place
     *
     *  Inputs:
     *     data - list of values
     *  Outputs:
     *     none
     */
    public static void Sort<T>(List<T> data) where T : IComparable<T> 
    {
        // Start the recursive process with the whole list
        _Sort(data, 0, data.Count-1);
    }

    /* Recursively use merge sort to sort a sublist
     * defined by first and last.
     * 
     *  Inputs:
     *     data - list of values
     *     first - the starting index of the sublist
     *     last - the ending index of the sublist
     *  Outputs:
     *     None
     */
    public static void _Sort<T>(List<T> data, int first, int last) where T : IComparable<T>
    {
        if (first < last) // base case
        {
            int mid = (first + last) / 2;
            _Sort(data, first, mid); // sort the left half
            _Sort(data, mid + 1, last); // sort the right half
            Merge(data, first, mid, last); // merge the two halves
        }
    }

    /* Merge two sorted list which are adjacent to each other back into
     * the same list.
     *
     *  Inputs:
     *     data - list of values
     *     first - the starting index of the first sorted sublist
     *     mid - the ending index of the first sorted sublist (second sublist starts after)
     *     last - the ending index of the second sorted sublist
     *  Outputs:
     *     None
     */
    public static void Merge<T>(List<T> data, int first, int mid, int last) where T : IComparable<T>
    {
        var left = new List<T>();
        var right = new List<T>();

        for (int i = first; i <= mid; i++) left.Add(data[i]);
        for (int i = mid + 1; i <= last; i++) right.Add(data[i]);

        int iLeft = 0, iRight = 0, iMerged = first;

        while (iLeft < left.Count && iRight < right.Count) // merge the two lists
        {
            if (left[iLeft].CompareTo(right[iRight]) <= 0) 
                data[iMerged++] = left[iLeft++]; // take remaining from left
            else
                data[iMerged++] = right[iRight++]; // take remaining from right
        }

        while (iLeft < left.Count) data[iMerged++] = left[iLeft++]; // copy remaining from left
        while (iRight < right.Count) data[iMerged++] = right[iRight++]; // copy remaining from right
    }
}
