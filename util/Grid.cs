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

    public int getPoint(int[] pos)
    {
        return getPoint(pos[0], pos[1]);
    }

    public void setPoint(int value, int x, int y)
    {
        grid[x, y] = value;
    }

    // NO ERROR HANDLING!
    
    public int[] getUp(int x, int y)
    {
        return new int[] {x, y--};
    }
    public int[] getUp(int[] pos)
    {
        return getUp(pos[0],pos[1]);
    }

    public int[] getDown(int x, int y)
    {
        return new int[] {x, y++};
    }
    public int[] getDown(int[] pos)
    {
        return getDown(pos[0],pos[1]);
    }

    public int[] getLeft(int x, int y)
    {
        return new int[] {x--, y};
    }
    public int[] getLeft(int[] pos)
    {
        return getLeft(pos[0],pos[1]);
    }

    public int[] getRight(int x, int y)
    {
        return new int[] {x++, y};
    }
    public int[] getRight(int[] pos)
    {
        return getRight(pos[0],pos[1]);
    }
    
    // ^^^^^^^^ NO ERROR HANDLING! ^^^^^^^^
    
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

    public string toImage(int val)
    {
        string res = "";
        for (var y = sizeY() - 1; y >= 0; y--)
        {
            for (int x = 0; x < sizeX(); x++)
            {
                if (grid[x, y] == val)
                {
                    res = res + "██";
                }
                else if (grid[x,y] == 0)
                {
                    res = res + "░░";
                }
                else
                {
                    res = res + "??";
                }
            }
            res = res + "\n";
        }

        return res;
    }
    

}