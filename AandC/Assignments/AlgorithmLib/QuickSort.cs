/*  CSE 381 - Quick Sort
 *  (c) BYU-Idaho - It is an honor code violation to post this
 *  file completed in a public file sharing site. S5.
 *
 *  Instructions: Implement the Partition and _Sort functions per the instructions
 *  in the comments.  Run all tests in QuickSortTest.cs to verify your code.
 */
namespace AlgorithmLib;

public static class QuickSort
{


    /* Use Quick Sort to sort a list of values in place
     *
     *  Inputs:
     *     data - list of values
     *  Outputs:
     *     none
     */
    public static void Sort<T>(List<T> data) where T : IComparable<T>
    {
        // Start the recursion with the entire list
        _Sort(data, 0, data.Count-1);
    }
    
    /* Recursively use quick sort to sort a sublist
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
        if (first < last)
        {
            // Partition the list and get the pivot index
            int pivotIndex = Partition(data, first, last);

            // Recursively sort elements before and after partition
            _Sort(data, first, pivotIndex - 1);
            _Sort(data, pivotIndex + 1, last);
        }
    }


    /* Partition a sublist by finding where a pivot belongs when sorted.  
    * All values less or equal to the pivot must be on the left hand side 
    * and all values greater must be on the right hand side of the pivot.
    * The pivot is chosen as the last element in the sublist.
    *
    *  Inputs:
    *     data - list of values
    *     first - the starting index of the sublist
    *     last - the ending index of the sublist
    *  Outputs:
    *     The index of where the pivot was moved
    */
    public static int Partition<T>(List<T> data, int first, int last) where T : IComparable<T>
    {
        T pivot = data[last];
        int i = first - 1;

        for (int j = first; j < last; j++)
        {
            if (data[j].CompareTo(pivot) <= 0)
            {
                i++;
                (data[i], data[j]) = (data[j], data[i]); // Swap
            }
        }

        // Place pivot in the correct sorted position
        (data[i + 1], data[last]) = (data[last], data[i + 1]);
        return i + 1;
    }
}