using System.Text.RegularExpressions;

namespace AOC2022.puzzles;

using util;

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
        
        // Done parsing input into stacks and instructions
        
        // Part1 and Part2 may not run at the same time, since the original dataset is manipulated in the method
        // TODO make sure the original dataset stays unchanged outside of the method
        //Part1(containers, instructions);
        Part2(containers, instructions);
    }

    private static void PrintStackList<T>(List<Stack<T>> list)
    {
        foreach (var stack in list)
        {
            Console.Write("stack: ");
            foreach (var crate in stack)
            {
                Console.Write(crate);
            }
            Console.WriteLine("");
        }
    }

    private static void Part1(List<Stack<char>> containers, List<int[]> instructions)
    {
        foreach (var instruction in instructions)
        {
            for (var i = 0; i < instruction[0]; i++)
            {
                containers[instruction[2]-1].Push(containers[instruction[1]-1].Pop());
            }
        }
        Console.Write("Part1: ");
        foreach (var container in containers)
        {
            Console.Write(container.Peek());
        }
        Console.WriteLine("");
    }
    
    private static void Part2(List<Stack<char>> containers, List<int[]> instructions)
    {
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

        Console.Write("Part2: ");
        foreach (var container in containers)
        {
            Console.Write(container.Peek());
        }
        Console.WriteLine("");
    }
}
