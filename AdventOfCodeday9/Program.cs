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
            SolveStar1();

            SolveStar2();
        }

        private static void SolveStar1()
        {
            var moves = ParseInput("input-test1.txt");

            Position head = new(0, 0);

            Position tail = new(0, 0);

            HashSet<Position> positions = new();

            foreach (var move in moves)
            {
                head = head.Move(move);

                tail = tail.Follow(head, tail);

                positions.Add(tail);
            }

            Console.WriteLine($"solution start 1: {positions.Count}");
        }

        private static void SolveStar2()
        {
            var moves = ParseInput("input-test1.txt");

            int lengthRope = 2; //10

            HashSet<Position> positions = new();

            List<Position> rope = new();

            for (int i = 0; i < lengthRope; i++)
            {
                rope.Add(new Position(0, 0));
            }

            int last = lengthRope - 1;

            foreach (var move in moves)
            {
                int i = 0;

                while (i < lengthRope)
                {
                    if (i == last)
                    {
                        break;
                    }
                    else
                    {
                        rope[i] = rope[i].Move(move);

                        rope[i + 1] = rope[i + 1].Follow(rope[i], rope[i + 1]);

                        positions.Add(new Position(rope[i + 1].x, rope[i + 1].y));
                    }

                    i++;
                }
            }

            Console.WriteLine($"solution start 2: {positions.Count}");
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