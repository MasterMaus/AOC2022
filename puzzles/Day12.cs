namespace AOC2022.puzzles;

using AOC2022.util;
public class Day12
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 12");
        var input = Util.ReadInput("day12t.txt");
        
        //part 1
        Grid grid = new Grid(input[0].Length,input.Count);
         var startEnd = FillGrid(grid, input);

         var start = startEnd[0];
         var end = startEnd[1];

         Dictionary<int[], int> timeToReach = new Dictionary<int[], int>();

         timeToReach.Add(start, 0);

         Traverse(grid, timeToReach, start);

         Console.WriteLine(timeToReach[end]);



         //part 2

    }

    private static void Traverse(Grid grid, Dictionary<int[], int> timeToReach, int[] pos)
    {
        var currentHeight = grid.getPoint(pos);
        var currentTime = timeToReach[pos];

        if (pos[1] != 0)
        {
            int [] up = grid.getUp(pos);
            TraverseOrNot(grid, timeToReach, up, currentHeight, currentTime);
        }

        if (pos[1] != grid.sizeY())
        {
            int [] down = grid.getDown(pos);
            TraverseOrNot(grid, timeToReach, down, currentHeight, currentTime);
        }
        
        if (pos[0] != 0)
        {
            int [] left = grid.getLeft(pos);
            TraverseOrNot(grid, timeToReach, left, currentHeight, currentTime);

        }

        if (pos[0] != grid.sizeX())
        {
            int [] right = grid.getRight(pos);
            TraverseOrNot(grid, timeToReach, right, currentHeight, currentTime);

        }

    }

    private static void TraverseOrNot(Grid grid, Dictionary<int[], int> timeToReach, int[] pos, int currentHeight, int currentTime)
    {
        if (grid.getPoint(pos) <= currentHeight + 1)
        {
            int upTime;
            if (!timeToReach.TryGetValue(pos, out upTime))
            {
                // Add to array, then traverse
                timeToReach.Add(pos, currentTime + 1);
                Traverse(grid, timeToReach, pos);
            }
            else
            {
                if (upTime < currentTime + 1)
                {
                    timeToReach[pos] = upTime;
                    Traverse(grid, timeToReach, pos);
                    //update array, then traverse
                }
            }
        }
    }

    private static int[][] FillGrid(Grid grid, List<string> input)
    {
        int[] start = new []{0};
        int[] end = new []{0};
        
        for (var y = grid.sizeY()-1; y >= 0; y--)
        {
            for (var x = 0; x < grid.sizeX(); x++)
            {
                var c = input[y][x];
                switch (c)
                {
                    case 'E':
                        grid.setPoint(27, x, y);
                        end = new [] {x,y};
                        break;
                    case 'S':
                        grid.setPoint(0, x, y);
                        start = new [] {x,y};
                        break;
                    default:
                        grid.setPoint((int) c % 32, x, y);
                        break;
                }
            }
        }

        return new int[][] {start, end};
    }
}
