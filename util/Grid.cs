namespace AOC2022.util;

public class Grid
{

    private int[,] grid;
    private int x, y;
    public Grid(int x, int y)
    {
        if (x < 1 || y < 1)
        {
            throw new ArgumentException("Dimensions of the grid should be bigger 1 or bigger");
        }
        
        this.x = x;
        this.y = y;

        grid = new int[x,y];
    }

    public int sizeX()
    {
        return x;
    }

    public int sizeY()
    {
        return y;
    }

    public int size()
    {
        return x * y;
    }

    public int getPoint(int x, int y)
    {
        return grid[x, y];
    }

    public void setPoint(int value, int x, int y)
    {
        grid[x, y] = value;
    }

    public void setRow(int[] row, int y)
    {
        // Length of values should be smaller or the same length of the grid
        if (row.Length > this.x)
        {
            throw new ArgumentException("The grid is not big enough to fill this row.");
        }

        for (var x = 0; x < row.Length; x++)
        {
            setPoint(row[x], x, y);
        }
    }

    public bool isMaxLeft(int x, int y)
    {
        var val = getPoint(x, y);
        for (var i = 0; i < x; i++)
        {
            if (val <= getPoint(i, y))
            {
                return false;
            }
        }
        return true;
    }
    
    public bool isMaxRight(int x, int y)
    {
        var val = getPoint(x, y);
        for (var i = x+1; i < sizeX(); i++)
        {
            if (val <= getPoint(i, y))
            {
                return false;
            }
        }
        return true;
    }
    
    public bool isMaxUp(int x, int y)
    {
        var val = getPoint(x, y);
        for (var i = 0; i < y; i++)
        {
            if (val <= getPoint(x, i))
            {
                return false;
            }
        }
        return true;
    }
    
    public bool isMaxDown(int x, int y)
    {
        var val = getPoint(x, y);
        for (var i = y+1; i < sizeY(); i++)
        {
            if (val <= getPoint(x, i))
            {
                return false;
            }
        }
        return true;
    }

    public int countValue(int val)
    {
        return grid.Cast<int>().Count(n => n == val);
    }

    public int findMax()
    {
        var res = getPoint(0,0);
        var c = 0;
        var d = 0;

        for (var a = 0; a < sizeX(); a++)
        {
            for (var b = 0; b < sizeY(); b++)
            {
                var val = getPoint(a,b);
                if (val > res)
                {
                    res = val;
                }
            }
        }

        return res;
    }
    

}