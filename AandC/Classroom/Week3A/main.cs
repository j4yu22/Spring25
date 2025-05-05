// CSE 381 REPL 3A 
// Selection Sort

public static class SelectionSort
{
    public static void Sort<T>(List<T> data) where T : IComparable
    {
        for (var i = 0, i < data.count - 1; i++) {
            var smallest = i;
            for (var j  = i + 1; j < data.count; j++) {
                if (data[j].CompareTo(data[smallest]) < 0) {
                    smallest = j;
                }
            }
            (data[i], data[smallest]) = (data[smallest], data[i]);
        }
    }
}

public static class InsertionSort
{
    public static void Sort<T>(List<T> data) where T : IComparable
    {
        for (var i = 1; i < data.count; i++) {
            var item = data[i];
            var insert = i - 1;
            while (insert > -1 && item.CompareTo(data(insert)) < 0) {
                data[insert + 1] = data[insert];
                insert--;
            }
            data[insert + 1] = item;
        }
    }
}

public static class Program 
{
    public static void Main (string[] args) 
    {    
        var data1 = new List<int>() {
            3, 5, 2, 6, 1, 4};
        SelectionSort.Sort(data1);
        Console.WriteLine(String.Join(", ", data1));

        var data2 = new List<int>() {
            1, 2, 3, 4, 5, 6};
        SelectionSort.Sort(data2);
        Console.WriteLine(String.Join(", ", data2));
            
        var data3 = new List<String>() {
            "cow", "dog", "pig", "cat", "deer"};
        SelectionSort.Sort(data3);
        Console.WriteLine(String.Join(", ", data3));
        
        Console.WriteLine("----");
        
        var data4 = new List<int>() {
            3, 5, 2, 6, 1, 4};
        InsertionSort.Sort(data4);
        Console.WriteLine(String.Join(", ", data4));

        var data5 = new List<int>() {
            1, 2, 3, 4, 5, 6};
        InsertionSort.Sort(data5);
        Console.WriteLine(String.Join(", ", data5));

        var data6 = new List<String>() {
            "cow", "dog", "pig", "cat", "deer"};
        InsertionSort.Sort(data6);
        Console.WriteLine(String.Join(", ", data6));
    }
}




