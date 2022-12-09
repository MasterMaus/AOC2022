using System.Collections;
using System.Runtime.Intrinsics.X86;

namespace AOC2022.puzzles;

using util;

public class Day9
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 9");
        var input = Util.ReadInput("day9.txt");


        var xs = new List<int>();
        var ys = new List<int>();
        var s1 = new SortedSet<Tuple<int, int>>();
        var s9 = new SortedSet<Tuple<int, int>>();

        for (var i = 0; i < 10; i++)
        {
            xs.Add(0);
            ys.Add(0);
        }

        s1.Add(new Tuple<int, int>(xs[1], ys[1]));
        s9.Add(new Tuple<int, int>(xs[9], ys[9]));
        
        foreach (var line in input)
        {
            var command = line.Split(" ");
            var movement = int.Parse(command[1]);

            for (; movement > 0; movement--)
            {
                switch (command[0])
                {
                    case "U":
                    {
                        ys[0]++;
                        break;
                    }
                    case "D":
                    {
                        ys[0]--;
                        break;
                    }
                    case "R":
                    {
                        xs[0]++;
                        break;
                    }
                    case "L":
                    {
                        xs[0]--;
                        break;
                    }
                    default:
                        throw new FormatException("This command is unknown!");
                }

                for (var i = 1; i < xs.Count; i++)
                {
                    var newPos = moveTail(xs[i - 1], ys[i-1], xs[i], ys[i]);
                    if (xs[i] == newPos[0] && ys[i] == newPos[1])
                    {
                        break;
                    }
                    xs[i] = newPos[0];
                    ys[i] = newPos[1];
                }
                

                s1.Add(new Tuple<int, int>(xs[1], ys[1]));
                s9.Add(new Tuple<int, int>(xs[9], ys[9]));



            }
            
        }
        Console.WriteLine(s1.Count);
        Console.WriteLine(s9.Count);


    }

    private static int[] moveTail(int hx, int hy, int tx, int ty)
    {
        var xdif = hx - tx;
        var ydif = hy - ty;

        if (xdif == -2)
        {
            //TAIL is LEFT from HEAD
            if (ydif == -2)
            {
                tx--;
                ty--;
            } else if (ydif == -1)
            {
                tx--;
                ty--;
            } else if (ydif == 0)
            {
                tx--;
            } else if (ydif == 1)
            {
                tx--;
                ty++;
            } else if (ydif == 2)
            {
                tx--;
                ty++;
            }
        } else if (xdif == -1)
        {
            //TAIL is LEFT from HEAD
            if (ydif == -2)
            {
                tx--;
                ty--;
            } else if (ydif == 2)
            {
                tx--;
                ty++;
            }
        } else if (xdif == 0)
        {
            //UP, ON, DOWN
            if (ydif == -2)
            {
                ty--;
            } else if (ydif == 2)
            {
                ty++;
            }
        } else if (xdif == 1)
        {
            //TAIL is RIGHT from HEAD
            if (ydif == -2)
            {
                tx++;
                ty--;
            } else if (ydif == 2)
            {
                tx++;
                ty++;
            }
        } else if (xdif == 2)
        {
            //TAIL is RIGHT from HEAD
            if (ydif == -2)
            {
                tx++;
                ty--;
            } else if (ydif == -1)
            {
                tx++;
                ty--;
            } else if (ydif == 0)
            {
                tx++;
            } else if (ydif == 1)
            {
                tx++;
                ty++;
            }
            else if (ydif == 2)
            {
                tx++;
                ty++;
            }
        }
        return new[] {tx, ty};
    }

    
}


