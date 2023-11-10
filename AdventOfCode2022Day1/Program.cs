/*
 * https://adventofcode.com/2022/day/1
 */

internal class Program
{
    private static void Main(string[] args)
    {
        string input = "input.txt";

        List<int> output = AddCaloriesToList(input);

        if (output.Count == 0)
        {
            Console.WriteLine("no data found!\nPress any key...");

            Console.ReadKey();

            Environment.Exit(0);
        }

        var outputSorted = output.OrderByDescending(s => s);

        Console.WriteLine($"Elf with most calories: {outputSorted.First()}");

        Console.WriteLine($"Calories of top three Elves: {outputSorted.Take(3).Sum()}");

        Console.WriteLine("\nPress any key...");

        Console.ReadKey();

        Environment.Exit(0);
    }

    private static List<int> AddCaloriesToList(string input)
    {
        List<int> output = new();

        if (!string.IsNullOrWhiteSpace(input))
        {
            int cals = 0;

            using StreamReader reader = new(input);

            while (reader != null && !reader.EndOfStream)
            {
                var r = reader.ReadLine();

                if (r != null)
                {
                    if (string.IsNullOrWhiteSpace(r))
                    {
                        output.Add(cals);

                        cals = 0;
                    }
                    else
                    {
                        try
                        {
                            cals += Convert.ToInt32(r);
                        }
                        catch
                        {
                            Console.WriteLine($"Unable to parse '{r}'");
                        }
                    }
                }
            }
        }

        return output;
    }
}