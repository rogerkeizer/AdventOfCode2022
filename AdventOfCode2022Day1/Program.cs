/*
 * https://adventofcode.com/2022/day/1
 */

internal class Program
{
    private static void Main(string[] args)
    {
        ProcessList(
            AddCaloriesToList("input.txt")
            );
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

    private static void ProcessList(List<int> output)
    {
        if (output.Count == 0)
        {
            DisplayNoDataMessage();
        }

        DisplayOutput(output);

        Console.ReadKey();

        Environment.Exit(0);
    }

    private static void DisplayNoDataMessage()
    {
        Console.WriteLine("no data found!\nPress any key...");

        Console.ReadKey();

        Environment.Exit(0);
    }

    private static void DisplayOutput(List<int> output)
    {
        Console.WriteLine($"Elf with most calories: {output.OrderByDescending(s => s).First()}");

        Console.WriteLine($"Calories of top three Elves: {output.OrderByDescending(s => s).Take(3).Sum()}");

        Console.WriteLine("\nPress any key...");
    }
}