namespace AOC2022.puzzles;

using AOC2022.util;
public class Day1
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 1");
        var input = Util.ReadInput("day1.txt");
        
        //part 1
        var totalCalories = new List<int>();
        int temp = 0;
        foreach (var line in input)
        {
            if (line == String.Empty)
            {
                totalCalories.Add(temp);
                temp = 0;
            }
            else
            {
                temp += int.Parse(line);
            }
        }
        
        Console.WriteLine(totalCalories.Max());
        
        //part 2
        totalCalories.Sort();
        totalCalories.Reverse();
        Console.WriteLine(totalCalories[0]+totalCalories[1]+totalCalories[2]);
    }
}
