/*
 * 
 * https://adventofcode.com/2022/day/10
 * 
 */

namespace AdventOfCodeDay9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SolveStar1();

            SolveStar2();
        }

        private static void SolveStar1()
        {
            var cycles = ParseInput("input.txt");

            var start = 20;

            var next = 0;

            var step = 40;

            var counter = 0;

            var signalStrength = 0;

            var total = 0;

            foreach (var c in cycles)
            {
                counter++;

                signalStrength += c;

                if (counter == start || counter == (start + next))
                {
                    total += counter * signalStrength;

                    next += step;
                }
            }

            Console.WriteLine($"total signal strength: {total}");
        }

        private static void SolveStar2()
        {
        }

        private static List<int> ParseInput(string input)
        {
            var cycles = new List<int>
            {
                1
            };

            using StreamReader reader = new(input);

            while (reader != null && !reader.EndOfStream)
            {
                var r = reader.ReadLine();

                if (r != null)
                {
                    var cycle = r.Split(" ");

                    if (cycle[0].Equals("noop"))
                    {
                        cycles.Add(0);
                    }

                    if (cycle[0].Equals("addx"))
                    {
                        cycles.Add(0);

                        int register = int.Parse($"{cycle[1]}");

                        cycles.Add(register);
                    }
                }
            }

            return cycles;
        }
    }
}