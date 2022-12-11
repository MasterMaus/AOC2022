namespace AOC2022.puzzles;

using AOC2022.util;
public class Day11
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 11");
        var input = Util.ReadInput("day11.txt");

        var items = new List<Queue<long>>();
        var operations = new List<string>();
        var tests = new List<int>(); // stores the test each monkey does on each item
        var next = new List<Tuple<int, int>>();
        var inspected = new List<long>();

        for (var i = 0; i < input.Count; i += 7)
        {
            items.Add(new Queue<long>(Array.ConvertAll(input[i + 1].Replace("  Starting items: ", "").Split(", "), s => long.Parse(s))));
            operations.Add(input[i+2].Replace("  Operation: new = ", ""));
            tests.Add(int.Parse(input[i+3].Replace("  Test: divisible by ", "")));
            var ifTrue = int.Parse(input[i + 4].Replace("    If true: throw to monkey ", ""));
            var ifFalse = int.Parse(input[i + 5].Replace("    If false: throw to monkey ", ""));
            next.Add(new Tuple<int, int>(ifTrue, ifFalse));
            inspected.Add(0);
        }

        var cm = 1;
        foreach (var n in tests)
        {
            cm *= n;
        }



        for (var round = 0; round < 10000; round++)
        {
            for (var monkey = 0; monkey < items.Count; monkey++)
            {
                while (items[monkey].Count != 0)
                {
                    var item = items[monkey].Dequeue();
                    var op = operations[monkey].Replace("old", item.ToString());
                    item = compute(op);
                    // item /= 3; //enable for the first part
                    item %= cm;
                    if (item % tests[monkey] == 0)
                    {
                        items[next[monkey].Item1].Enqueue(item);
                    }
                    else
                    {
                        items[next[monkey].Item2].Enqueue(item);
                    }

                    inspected[monkey]++;
                }
            }
        }
        
        //part 1
        inspected.Sort();
        Console.WriteLine(inspected[^1] * inspected[^2]);

    }

    private static long compute(string op)
    {
        if (op.Contains('*'))
        {
            var n = Array.ConvertAll(op.Replace(" * ", ",").Split(','), s => long.Parse(s));
            return n[0] * n[1];
        } else if (op.Contains('+'))
        {
            var n = Array.ConvertAll(op.Replace(" + ", ",").Split(','), s => long.Parse(s));
            return n[0] + n[1];
        }

        throw new FormatException("");
    }

}
