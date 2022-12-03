namespace AOC2022.puzzles;

using AOC2022.util;

public class Day3
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 3");
        var input = Util.ReadInput("day3.txt");

        Console.WriteLine(Part1(input));
        Console.WriteLine(Part2(input));


    }

    private static int Part2(List<string> input)
    {
        var items = new Dictionary<char, int>();
        var prio = new Dictionary<char, int>();

        int i = 1;

        for (var c = 'a'; c <= 'z'; c++)
        {
            items[c] = 0;
            prio[c] = i++;
        }
        for (var c = 'A'; c <= 'Z'; c++)
        {
            items[c] = 0;
            prio[c] = i++;
        }

        for (i = 0; i<input.Count; i+=3)
        {
            foreach (var c in input[i].Where(c => input[i + 1].Contains(c) && input[i + 2].Contains(c)))
            {
                items[c]++;
                break;
            }
        }
        
        int result2 = 0;

        foreach (var (key, value) in items)
        {
            result2 += prio[key] * value;
        }

        return result2;
    }
    private static int Part1(List<string> input)
    {
        var items = new Dictionary<char, int>();
        var prio = new Dictionary<char, int>();

        int i = 1;

        for (var c = 'a'; c <= 'z'; c++)
        {
            items[c] = 0;
            prio[c] = i++;
        }
        for (var c = 'A'; c <= 'Z'; c++)
        {
            items[c] = 0;
            prio[c] = i++;
        }
        
        foreach (var line in input)
        {
            if (line == string.Empty) continue;
            var l = line[..(line.Length / 2)];
            var r = line[(line.Length / 2)..];

            foreach (var c in l.Where(c => r.Contains(c)))
            {
                items[c]++;
                break;
            }
        }

        var result1 = 0;

        foreach (var (key, value) in items)
        {
            result1 += prio[key] * value;
        }

        return result1;
    }
}
