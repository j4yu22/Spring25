// CSE 381 REPL 1A Solution
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

    public float Area() 
    {
        return Height * Width;
    }
}

public static class Stats
{
    public static float Average(List<int> numbers) 
    {
        return (float) numbers.Sum() / numbers.Count;
    }

    public static T Max<T>(List<T> values) where T : IComparable
    {
        if (values.Count == 0) {
            throw new Exception("List is empty");
        }
        var maxValue = values[0];
        for (var i=1; i<values.Count; i++)
        {
            if (values[i].CompareTo(maxValue) > 0)
            {
                maxValue = values[i];
            }
        }
        return maxValue;
    }

    public static int Add(List<int>? values, int indexStart=0)
    {
        if (values == null)
        {
            return 0;
        }
        return values[indexStart..].Sum();
    }
}

public static class Program 
{
    public static void Main (string[] args) 
    {
        Console.WriteLine ("Hello World");
        int x = 5;
        var y = 6.5;

        Console.WriteLine($"x = {x} y = {y} x+y = {x+y}");

        for (var i=0; i<10; i++) {
            Console.WriteLine(i);
        }

        foreach (var i in Enumerable.Range(0,10)) {
            Console.WriteLine(i);
        }

        var list = new List<int>();
        list.Add(10);
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
        r.Height = 10;
        Console.WriteLine($"Area = {r.Area()}");

        var list4 = new List<int> {3, 1, 6, 5, 4, 0};
        var avg4 = Stats.Average(list4);
        Console.WriteLine($"Avg: {avg4}");
        
        var max4 = Stats.Max(list4);
        Console.WriteLine($"Max: {max4}");
        
        var list5 = new List<String> {"dog", "cat", "pig", "cow", "hamster", "bird"};
        var max5 = Stats.Max(list5);
        Console.WriteLine($"Max: {max5}");

        var firstHalf = list5[..3];
        var secondHalf = list5[3..];
        Console.WriteLine(string.Join(", ", firstHalf));
        Console.WriteLine(string.Join(", ", secondHalf));

        var result = Stats.Add(list4,3);
        Console.WriteLine(result);

        result = Stats.Add(list4);
        Console.WriteLine(result);

        List<int>? list6 = null;
        result = Stats.Add(list6);
        Console.WriteLine(result);
        

        var accounts = new Dictionary<string, int>() {
            {"bob",332},
            {"tim",153},
            {"sue",400}
        };

        Console.WriteLine(accounts["bob"]);
        
        accounts["bob"] += 100;
        Console.WriteLine(accounts["bob"]);

        Console.Write("Enter name: ");
        var name = Console.ReadLine()!;
        if (accounts.ContainsKey(name))
        {
            Console.WriteLine($"Account = ${accounts[name]}");
        }
        else
        {
            Console.WriteLine("Name not found.");
        }
    }
}