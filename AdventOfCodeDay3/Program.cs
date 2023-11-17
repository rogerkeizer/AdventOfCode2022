/*
 * https://adventofcode.com/2022/day/3
 * 
 * https://www.ascii-code.com/
 * 
 * a starts at 97
 * A starts at 65
 * 
 * Lowercase item types a through z have priorities 1 through 26.
 * Uppercase item types A through Z have priorities 27 through 52.
 *
 */

using System.Collections.Generic;
using System.Text;

internal class Program
{
    const int upperDifference = 64;
    const int lowerDifference = 96;

    private static void Main(string[] args)
    {
        Console.WriteLine($"Total priorities, star 1: {StarOne()}");
        Console.WriteLine($"Total priorities, star 2: {StarTwo()}");
    }

    private static int StarOne()
    {
        bool foundCommonItemType;

        StringBuilder commonItemTypes = new();

        using StreamReader reader = new("input.txt");

        while (reader != null && !reader.EndOfStream)
        {
            var r = reader.ReadLine();

            if (r != null)
            {
                var eersteHelft = r[..Convert.ToInt32(r.Length * 0.5)];

                var tweedeHelft = r[eersteHelft.Length..];

                foundCommonItemType = false;

                for (int i = 0; i < eersteHelft.Length; i++)
                {
                    for (int y = 0; y < tweedeHelft.Length; y++)
                    {
                        if (eersteHelft[i] == tweedeHelft[y])
                        {
                            foundCommonItemType = true;
                            commonItemTypes.Append(eersteHelft[i]);
                        }

                        if (foundCommonItemType)
                        {
                            break;
                        }
                    }

                    if (foundCommonItemType)
                    {
                        break;
                    }
                }
            }

        }

        return CalculateTotalPriorities(commonItemTypes);
    }

    private static int StarTwo()
    {
        List<List<string>> rucksacks = new();

        List<List<string>> rucksacksSorted = new();

        using StreamReader reader = new("input.txt");

        int rucksackCounter = 0;

        StringBuilder badges = new();

        List<string> threeRucksacks = new();

        while (reader != null && !reader.EndOfStream)
        {
            var r = reader.ReadLine();

            if (r != null)
            {
                rucksackCounter++;

                threeRucksacks.Add(r);
            }

            if (rucksackCounter == 3)
            {
                rucksackCounter = 0;

                rucksacks.Add(threeRucksacks);

                threeRucksacks = new();
            }
        }

        foreach (var r in rucksacks)
        {
            r.Sort((x, y) => x.Length.CompareTo(y.Length));

            rucksacksSorted.Add(r);
        }

        //https://stackoverflow.com/q/74703083/211362
        foreach (var rucksacksThree in rucksacksSorted)
        {
            string commonString = string.Concat(rucksacksThree[0]
                .Intersect(rucksacksThree[1])
                .Intersect(rucksacksThree[2]));

            badges.Append(commonString);
        }

        return CalculateTotalPriorities(badges);
    }

    private static int CalculateTotalPriorities(StringBuilder commonItemTypes)
    {
        var allPrio = 0;

        for (int i = 0; i < commonItemTypes.ToString().Length; i++)
        {
            var c = commonItemTypes[i];

            var prio = 0;

            if (char.IsUpper(c))
            {
                prio = Convert.ToInt32(c);

                allPrio += prio - upperDifference + 26;
            }
            else
            {
                prio = Convert.ToInt32(c);

                allPrio += prio - lowerDifference;
            }
        }

        return allPrio;
    }
}

