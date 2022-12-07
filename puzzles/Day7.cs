using System.Text.RegularExpressions;

namespace AOC2022.puzzles;

using util;

public class Day7
{
    public static void Execute()
    {
        Console.WriteLine("Executing day 7");
        var input = Util.ReadInput("day7.txt");

        var commands = new Queue<string[]>(); // Queue with commands
        var results = new LinkedList<List<string[]>>(); // Queue, filled with a list of the results for the corresponding command 
        // commands and results should always be the same size
        var dirs = new Dictionary<string, ulong>(); // K: current directory path, size

        var rgNumeric = new Regex("\\d+$");
        

        foreach (var line in input)
        {
            if (line.StartsWith("$ "))
            {
                // This line is a command
                commands.Enqueue(line[2..].Split(' ')); // Add command to queue
                results.AddLast(new List<string[]>()); // Add a new list to the results queue
            }
            else
            {
                //this line is a result
                results.Last.Value.Add(line.Split(' '));
            }
        }

        var currentDirectory = "";
        dirs.Add("/", 0); // add root directory
        
        foreach (var command in commands)
        {
            var result = results.First.Value;
            results.RemoveFirst();

            switch (command[0])
            {
                case "cd":
                    if (command[1].StartsWith('/'))
                    {
                        currentDirectory = command[1];
                    } else if (command[1].Equals(".."))
                    {
                        currentDirectory = getParent(currentDirectory);
                    }
                    else
                    {
                        currentDirectory += command[1] + '/';
                        // Add directory to map if and only if this directory was not yet in the dirs map
                        if (!dirs.ContainsKey(currentDirectory))
                        {
                            Console.WriteLine("I dont think this line should ever happen tho");
                            dirs.Add(currentDirectory, 0);
                        }
                    }
                    break;
                case "ls":
                    foreach (var line in result)
                    {
                        if (line[0].Equals("dir"))
                        {
                            dirs.Add(currentDirectory+line[1]+'/', 0);
                        } else if (rgNumeric.IsMatch(line[0]))
                        {
                            var size = ulong.Parse(line[0]);
                            UpdateParents(dirs, currentDirectory, size);
                        }
                        else
                        {
                            throw new Exception("Shit out of luck, not recognized as file or directory");
                        }
                    }
                    break;
                default:
                    throw new Exception("Shit out of luck, this command is not known by the system");
            }
        }

        ulong total = 0;
        foreach (var (_, value) in dirs)
        {
            if (value < 100000)
            {
                // Console.WriteLine(dir.Key);
                total += value;
            }
        }
        
        Console.WriteLine(total);

        var availableDiskSpace = 70000000 - dirs["/"];
        var toFree = 30000000 - availableDiskSpace;
        // find directory that is: bigger than availableDiskSpace
        var potentialDeletions = new List<ulong>();
        foreach (var (_, value) in dirs)
        {
            if (value >= toFree)
            {
                potentialDeletions.Add(value);
            }
        }
        
        Console.WriteLine(potentialDeletions.Min());

    }

    private static string getParent(string path)
    {
        var indexOf = path[..^1].LastIndexOf('/');
        return indexOf < 0 ? "/" : path[..(indexOf + 1)];
    }

    private static void UpdateParents(Dictionary<string, ulong> dict, string currentDirectory, ulong size)
    {
        dict[currentDirectory] += size;
        if (!currentDirectory.Equals("/"))
        {
            UpdateParents(dict, getParent(currentDirectory), size);
        }
    }
    
}


