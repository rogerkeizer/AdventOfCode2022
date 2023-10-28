/*
 * https://adventofcode.com/2022/day/1
 */

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> input = new();

        List<int> output = new();

        Dictionary<int, List<int>> cals = new();

        var i = 1;

        using StreamReader reader = new("input.txt");
        while (reader != null && !reader.EndOfStream)
        {
            var r = reader.ReadLine();

            if (r != null)
            {
                if (string.IsNullOrWhiteSpace(r))
                {
                    cals.Add(i, input);

                    i++;

                    input = new();
                }
                else
                {
                    try
                    {
                        input.Add(Convert.ToInt32(r));
                    }
                    catch 
                    {
                        Console.WriteLine($"Unable to parse '{r}'");
                    } 
                }
            }
        }

        foreach (var c in cals)
        {
            var total = 0;

            foreach (var cc in c.Value)
            {
                total += cc;
            }

            output.Add(total);
        }

        if (output.Count == 0)
        {
            Console.WriteLine("no data found");
        }
        else 
        {
            var outputSorted = output.OrderByDescending(s => s);

            Console.WriteLine($"Elf with most calories: {outputSorted.First()}");

            var topThree = 0;

            i = 1;

            foreach(var os in outputSorted)
            {
                topThree += os;

                i++;

                if (i == 4)
                {
                    break;
                }

            }

            Console.WriteLine($"Calories of top three Elves: {topThree}");
        }

    }
}