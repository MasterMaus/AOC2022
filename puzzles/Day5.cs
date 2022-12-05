using System.Text.RegularExpressions;

namespace AOC2022.puzzles;

using AOC2022.util;

public class Day5
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 5");
        var input = Util.ReadInput("day5.txt");
        var containers = new List<Stack<char>>();
        var instructions = new List<int[]>();

        var rgContainerNumbers = new Regex("( \\d )+$");
        
        var containerLine = input.TakeWhile(t => !rgContainerNumbers.Match(t).Success).Count();


        for (var i = 0; i < 9; i++)
        {
            containers.Add(new Stack<char>());
        }

        for (var i = containerLine - 1; i >= 0 ; i--)
        {
            var line = input[i];
            for (var j = 0; j < line.Length; j++)
            {
                if (char.IsLetter(line[j]))
                {
                    containers[j/4].Push(line[j]);
                }
            }
        }

        for (var i = containerLine + 2; i < input.Count; i++)
        {
            var line = input[i];
            line = line.Replace("move ", "");
            line = line.Replace(" from ", ",");
            line = line.Replace(" to ", ",");
            instructions.Add(Array.ConvertAll(line.Split(','), s => int.Parse(s)));
        }

        
        // Part 1
        // foreach (var instruction in instructions)
        // {
        //     for (var i = 0; i < instruction[0]; i++)
        //     {
        //         containers[instruction[2]-1].Push(containers[instruction[1]-1].Pop());
        //     }
        // }
        
        // Part 2
        foreach (var instruction in instructions)
        {
            var temp = new Stack<char>();
            for (var i = 0; i < instruction[0]; i++)
            {
                temp.Push(containers[instruction[1]-1].Pop());
            }

            foreach (var container in temp)
            {
                containers[instruction[2]-1].Push(container);
            }
        }
        PrintStackList(containers);
    }

    private static void PrintStackList<T>(List<Stack<T>> list)
    {
        foreach (var stack in list)
        {
            Console.Write("stack: ");
            foreach (var container in stack)
            {
                Console.Write(container);
            }
            Console.WriteLine("");
        }
    }
}
