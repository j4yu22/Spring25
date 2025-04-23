// CSE 381 REPL 1A
// C# Primer

public class Rectangle
{
    public float Height {get; set;}
    public float Width {get; set;}
    public Rectangle(float height, float width) 
    {
        Height = height;
        Width = width;
    }

    public float Area() {
        return Height * Width;
    }
}


public static class Stats {
    public static float Average (List<int> numbers) {
        return (float) numbers.Sum() / numbers.count();
    }

    public static T Max<T>(List<T> numbers) where T : IComparable{
        if (numbers.Count == 0) {
            throw new Exception("List is emtpy");
        }
        var maxValue = numbers[0];
        for (int i = 1; i < numbers.Count; i++) {
            if (numbers[i].CompareTo(maxValue) > 0) {
                maxValue = numbers[i];
    }
    public static int Add(List<int> values int indexStart=0) {
        if (values == null) throw new ArgumentNullException(nameof(values), "Input list cannot be null.");
        return values[indexStart..].Sum();
    }
}}}

public static class Program 
{
    public static void Main (string[] args) 
    {
        Console.WriteLine ("Hello World");

        int x =5;
        var y = 3,14;

        Console.WriteLine($"x = {x} y = {y} x+y = {x+y}");

        for (var i=0; i<10; i++) {
            Console.Writeline(i);
        }

        foreach (var i in Enumerable.Range(0,10)) {
            Console.WriteLine(i);
        }

        var list = new List<int>();
        list.add(10);
        list.Add(20);
        list.Add(30);

        foreach (var i in list) {
            Console.WriteLine(i);
        }

        
        Console.WriteLine($"First: {list[0]}");
        Console.WriteLine($"Last: {list[^1]}");

        var list2 = Enumerable.Range(0,10);
        list2 = list2.Select(x => 2*x);
        list2 = list2.Select(_ => 42);
        
        foreach (var i in list2) {
            Console.WriteLine(i);
        }

        var list3 = list2.ToList();
        Console.WriteLine($"First: {list3[0]}");

        var r = new Rectangle(3,5);
        Console.WriteLine($"Area = {r.Area()}");
        r.Height = 10

        var list4 = new List<int> {3, 1, 6, 5, 4, 0}
        var avg4 = Stats.Average(list4);
        Console.WriteLine($"Avg: {avg4}");

        var max4 = Stats.Max(list4);
        Console.WriteLine($"Max: {max4}");

        var list5 = new List<string> {'dog', 'cat', 'pig', 'cow', 'hamster', 'bird'}
        var max5 = Stats.Max(list5);
        Console.WriteLine($"Max: {max5}");


        Console.WriteLine(string.Join(", ", list4[..3]));
        Console.WriteLine(string.Join(", ", list4[3..]));

        
        // Console.WriteLine(result);
        

        // Console.WriteLine(result);

        
        // Console.WriteLine(result);

    }
}