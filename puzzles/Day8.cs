namespace AOC2022.puzzles;

using util;

public class Day8
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 8");
        var input = Util.ReadInput("day8.txt");
        
        // Create a new forest 
        Grid forest = new Grid(input[0].Length, input.Count);

        for (var y=0; y < input.Count; y++)
        {
            var row = Array.ConvertAll(input[y].Select(x => x.ToString()).ToArray(), s => int.Parse(s));
            forest.setRow(row, y);
        }

        var getVisibilityMap = VisibilityMap(forest);
        
        Console.WriteLine(getVisibilityMap.countValue(1));

        var scenicMap = getScenicMap(forest);
        
        Console.WriteLine(scenicMap.findMax());


    }

    private static Grid VisibilityMap(Grid forest)
    {
        // If a tree is visible, its variable is set to 1
        var res = new Grid(forest.sizeX(), forest.sizeY());
        // Set outer ring to 1
        for (var x = 0; x < forest.sizeX(); x++)
        {
            res.setPoint(1, x, 0);
            res.setPoint(1, x, forest.sizeY() - 1);
        }

        for (var y = 0; y < forest.sizeY(); y++)
        {
            res.setPoint(1, 0, y);
            res.setPoint(1, forest.sizeX() - 1, y);
        }

        for (var x = 1; x < forest.sizeX() - 1; x++)
        {
            for (var y = 1; y < forest.sizeY() - 1; y++)
            {
                if (isVisible(forest, x, y))
                {
                    res.setPoint(1, x, y);
                }
            }
        }

        return res; 
    }

    private static bool isVisible(Grid forest, int x, int y)
    {
        return forest.isMaxLeft(x, y) || forest.isMaxRight(x, y) || forest.isMaxUp(x,y) || forest.isMaxDown(x,y);
    }

    private static Grid getScenicMap(Grid forest)
    {
        var res = new Grid(forest.sizeX(), forest.sizeY());
        for (var x = 0; x < forest.sizeX(); x++)
        {
            for (var y = 0; y < forest.sizeY(); y++)
            {
                res.setPoint(getScenicValue(forest, x, y), x, y);
            }
        }
        return res;
    }
    
    private static int getScenicValue(Grid forest, int x, int y)
    {
        int left = x, right = forest.sizeX()-1-x, up = y, down = forest.sizeY()-1-y;

        var val = forest.getPoint(x, y);
        for (var i = 1; x - i >= 0; i++)
        {
            if (val > forest.getPoint(x - i, y)) continue;
            left = i;
            break;
        }
        for (var i = 1; x + i < forest.sizeX(); i++)
        {
            if (val > forest.getPoint(x + i, y)) continue;
            right = i;
            break;
        }
        for (var i = 1; y - i >= 0; i++)
        {
            if (val > forest.getPoint(x, y - i)) continue;
            up = i;
            break;
        }
        for (var i = 1; y + i < forest.sizeY(); i++)
        {
            if (val > forest.getPoint(x , y + i)) continue;
            down = i;
            break;
        }
        
        return left * right * up * down;
    }
    
}


