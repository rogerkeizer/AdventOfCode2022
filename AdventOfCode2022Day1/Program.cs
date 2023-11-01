/*
 * https://adventofcode.com/2022/day/1
 */

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> output = new();

        int cals = 0;

        using StreamReader reader = new("input.txt");

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

        if (output.Count == 0)
        {
            Console.WriteLine("no data found");
        }
        else 
        {
            var outputSorted = output.OrderByDescending(s => s);

            Console.WriteLine($"Elf with most calories: {outputSorted.First()}");

            var topThree = 0;

            var i = 1;

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