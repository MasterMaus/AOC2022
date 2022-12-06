using System.Text.RegularExpressions;

namespace AOC2022.puzzles;

using util;

public class Day6
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 6");
        var input = Util.ReadInput("day6.txt")[0];
        for (var i = 4; i < input.Length; i++)
        {
            if (!IsMarker(input[(i-4)..i])) continue;
            Console.WriteLine("Part 1: " + i);
            break;
        }
        
        for (var i = 14; i < input.Length; i++)
        {
            if (!IsMarker(input[(i-14)..i])) continue;
            Console.WriteLine("Part 1: " + i);
            break;
        }
       
    }

    private static bool IsMarker(string substr)
    {
        for (var i = 0; i < substr.Length; i++)
        {
            for (var j = i + 1; j < substr.Length; j++)
            {
                if (substr[i] == substr[j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
