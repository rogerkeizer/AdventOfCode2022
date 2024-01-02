/*
 * 
 * https://adventofcode.com/2022/day/8
 * 
 */

namespace AdventOfCodeDay8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var reader = File.ReadAllText("input.txt").Split("\r\n");

            var matrix = ParseFile(reader);

            SolveStar1(matrix);

        }

        private static void SolveStar1(int[,] matrix)
        {
            //PrintMatrix(matrix);

            var visible = FindVisibleTrees(matrix);

            Console.WriteLine($"Number of visible trees: {visible}");

            Console.ReadLine();
        }

        public static bool IsVisibleFromLeftSide(int[,] matrix, int posX, int posY)
        {
            var currentHeight = matrix[posX, posY];

            for (int y = posY - 1; y > -1; y--)
            {
                var newHeight = matrix[posX, y];

                if (newHeight >= currentHeight)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsVisibleFromRightSide(int[,] matrix, int posX, int posY)
        {
            var currentHeight = matrix[posX, posY];

            for (int y = posY + 1; y < matrix.GetLength(0); y++)
            {
                var newHeight = matrix[posX, y];

                if (newHeight >= currentHeight)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsVisibleFromTopSide(int[,] matrix, int posX, int posY)
        {
            var currentHeight = matrix[posX, posY];

            for (int x = posX - 1; x > -1; x--)
            {
                var newHeight = matrix[x, posY];

                if (newHeight >= currentHeight)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsVisibleFromBottomSide(int[,] matrix, int posX, int posY)
        {
            var currentHeight = matrix[posX, posY];

            for (int x = posX + 1; x < matrix.GetLength(0); x++)
            {
                var newHeight = matrix[x, posY];

                if (newHeight >= currentHeight)
                {
                    return false;
                }
            }

            return true;
        }

        public static int FindVisibleTrees(int[,] matrix)
        {
            var visible = 0;

            int rows = matrix.GetLength(0);

            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var found = false;
                    if (IsVisibleFromBottomSide(matrix, i, j))
                    {
                        found = true;
                    }

                    if (IsVisibleFromTopSide(matrix, i, j))
                    {
                        found = true;
                    }

                    if (IsVisibleFromLeftSide(matrix, i, j))
                    {
                        found = true;
                    }

                    if (IsVisibleFromRightSide(matrix, i, j))
                    {
                        found = true;
                    }

                    if (found)
                    {
                        visible++;
                    }
                }
            }

            return visible;
        }

        static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine("Original matrix:");

            int rows = matrix.GetLength(0);

            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],-3} ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] ParseFile(string[] reader)
        {
            int[,] m = new int[reader.Length, reader.Length];

            var y = 0;

            foreach (var r in reader)
            {
                for (int i = 0; i < r.Length; i++)
                {
                    m[y, i] = int.Parse($"{r[i]}");
                }

                y++;
            }

            return m;
        }
    }
}