using System.Net.Mime;
using System.Text.RegularExpressions;

namespace AOC2022.puzzles;

using util;

public class Day10
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 10");
        var input = Util.ReadInput("day10.txt");

        var currentX = 1; //register x
        var cycle = 0;
        var listX = new List<int>();
        listX.Add(currentX);
        

        foreach (var command in input.Select(line => line.Split(" ")))
        {
            switch (command[0])
            {
                case "noop" :
                {
                    cycle++;
                    listX.Add(currentX);
                    break;
                }
                case "addx":
                {
                    cycle++;
                    listX.Add(currentX);
                    cycle++;
                    listX.Add(currentX);
                    currentX += int.Parse(command[1]);
                    break;
                }
                default:
                {
                    throw new Exception("dont know this operation");
                }
            }
        }

        Console.WriteLine(listX[20]*20 + listX[60]*60 + listX[100]*100 + listX[140]*140 + listX[180]*180 + listX[220]*220 );

        var image = new Grid(40, 6);

        var x = 0;
        var y = 5;
        
        
        for (var i = 1; i < listX.Count; i++)
        {
            var sprite = new int[] {listX[i]-1, listX[i], listX[i]+1};
            if (sprite.Contains(x))
            {
                image.setPoint(1,x,y);
            }

            x++;
            if (x != 40) continue;
            x = 0;
            y--;
        }

        Console.WriteLine(image.toImage(1));
    }
    
}


