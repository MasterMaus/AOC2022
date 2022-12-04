namespace AOC2022.puzzles;

using AOC2022.util;

public class Day4
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 4");
        var input = Util.ReadInput("day4.txt");

        var part1 = 0;
        var part2 = 0;

        foreach (var line in input)
        {
            var range = line.Split(',');
            var first = Array.ConvertAll(range[0].Split('-'), s => int.Parse(s));
            var second = Array.ConvertAll(range[1].Split('-'), s => int.Parse(s));

            if (first[0] >= second[0] && first[1] <= second[1] || second[0] >= first[0] && second[1] <= first[1])
            {
                part1++;
            } 
            if (first[0] >= second[0] && first[0] <= second[1] || second[0] >= first[0] && second[0] <= first[1])
            {
                part2++;
            }
        }
        Console.WriteLine(part1);
        Console.WriteLine(part2);
    }
}
