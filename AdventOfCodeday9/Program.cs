/*
 * 
 * https://adventofcode.com/2022/day/9
 * 
 */

using AdventOfCodeday9;

namespace AdventOfCodeDay9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var moves = ParseInput("input.txt");

            Position head = new(0, 0);

            Position tail = new(0, 0);

            HashSet<Position> positions = new();

            foreach (var move in moves)
            {
                head = head.Move(move);

                tail = tail.Follow(head, tail);

                positions.Add(new Position(tail.x, tail.y));
            }

            Console.WriteLine($"{positions.Count}");
        }

        private static List<Direction> ParseInput(string input)
        {
            var moves = new List<Direction>();

            using StreamReader reader = new(input);

            while (reader != null && !reader.EndOfStream)
            {
                var r = reader.ReadLine();

                if (r != null)
                {
                    var move = r.Split(" ");

                    int numberMoves = int.Parse($"{move[1]}");

                    for (int i = 1; i <= numberMoves; i++)
                    {
                        switch (r[0])
                        {
                            case 'D':
                                moves.Add(Direction.Down);
                                break;
                            case 'U':
                                moves.Add(Direction.Up);
                                break;
                            case 'L':
                                moves.Add(Direction.Left);
                                break;
                            default:
                                moves.Add(Direction.Right);
                                break;
                        }

                    }
                }
            }

            return moves;
        }
    }
}