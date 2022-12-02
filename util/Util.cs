namespace AOC2022.util;

public class Util
{
    public static List<string> ReadInput(string file)
    {
        var input = new List<string>();
        foreach (var line in File.ReadLines(@"input/" + file))
        {
            input.Add(line);
        }

        return input;
    }
}