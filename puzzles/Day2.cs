namespace AOC2022.puzzles;

using AOC2022.util;

public class Day2
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 2");
        var input = Util.ReadInput("day2.txt");

        var score1 = 0;
        
        //part 1
        foreach (var line in input)
        {
            score1 += rps(line[0], line[2]);
        }
        
        Console.WriteLine(score1);
        
        
        //part 2

        var score2 = 0;
        
        foreach (var line in input)
        {
            score2 += rps2(line[0], line[2]);
        }

        Console.WriteLine(score2);
    }

    private static int rps(char a, char b)
    {
        return a switch
        {
            'A' => b switch //ROCK
                {
                    'X' => 3 + 1, //ROCK
                    'Y' => 6 + 2, //PAPER
                    'Z' => 0 + 3, //SCISSOR
                    _ => throw new InvalidDataException()
                },
            'B' => b switch //PAPER
                {
                    'X' => //ROCK
                        0 + 1,
                    'Y' => //PAPER
                        3 + 2,
                    'Z' => //SCISSOR
                        6 + 3,
                    _ => throw new InvalidDataException()
                },
            'C' => b switch //SCISSOR
                {
                    'X' => //ROCK
                        6 + 1,
                    'Y' => //PAPER
                        0 + 2,
                    'Z' => //SCISSOR
                        3 + 3,
                    _ => throw new InvalidDataException()
                },
            _ => throw new InvalidDataException()
        };
    }
    
    private static int rps2(char a, char b)
    {
        return a switch
        {
            'A' => b switch //ROCK
                {
                    'X' => 0 + 3, //LOSE with SCISSOR
                    'Y' => 3 + 1, //DRAW with ROCK
                    'Z' => 6 + 2, //WIN with PAPER
                    _ => throw new InvalidDataException()
                },
            'B' => b switch //PAPER
                {
                    'X' => 0 + 1, //LOSE with ROCK
                    'Y' => 3 + 2, //DRAW with PAPER
                    'Z' => 6 + 3, //WIN SCISSOR
                    _ => throw new InvalidDataException()
                },
            'C' => b switch //SCISSOR
                {
                    'X' => 0 + 2, //LOSE with PAPER
                    'Y' => 3 + 3, //DRAW with SCISSOR
                    'Z' => 6 + 1, //WIN with ROCK
                    _ => throw new InvalidDataException()
                },
            _ => throw new InvalidDataException()
        };
    }
}
