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

            SolveStar2(matrix);

        }

        private static void SolveStar1(int[,] matrix)
        {
            //PrintMatrix(matrix);

            var visible = FindVisibleTrees(matrix);

            Console.WriteLine($"Number of visible trees: {visible}");
        }

        private static void SolveStar2(int[,] matrix)
        {
            var scenic = FindScenicScore(matrix);

            Console.WriteLine($"Highest scenic score: {scenic}");

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

        public static int CalculateScenicScoreUp(int[,] matrix, int posX, int posY)
        {
            var score = 0;

            var currentHeight = matrix[posX, posY];

            if (posX - 1 == -1)
            {
                return 0;
            }

            if (posX - 1 == 0)
            {
                return 1;
            }

            int x = posX - 1;

            while (x > -1)
            {
                var newHeight = matrix[x, posY];

                score++;

                if (newHeight >= currentHeight)
                {
                    break;
                }

                x--;
            }

            return score;
        }

        public static int CalculateScenicScoreDown(int[,] matrix, int posX, int posY)
        {
            var score = 0;

            var currentHeight = matrix[posX, posY];

            if (posX + 1 == matrix.GetLength(0))
            {
                return 0;
            }

            if (posX + 1 == matrix.GetLength(0) - 1)
            {
                return 1;
            }

            int x = posX + 1;

            while (x < matrix.GetLength(0))
            {
                var newHeight = matrix[x, posY];

                score++;

                if (newHeight >= currentHeight)
                {
                    break;
                }

                x++;
            }

            return score;
        }

        public static int CalculateScenicScoreLeft(int[,] matrix, int posX, int posY)
        {
            var score = 0;

            var currentHeight = matrix[posX, posY];

            if (posY - 1 == -1)
            {
                return 0;
            }

            if (posY - 1 == 0)
            {
                return 1;
            }

            int y = posY - 1;

            while (y > -1)
            {
                var newHeight = matrix[posX, y];

                score++;

                if (newHeight >= currentHeight)
                {
                    break;
                }

                y--;
            }

            return score;
        }

        public static int CalculateScenicScoreRight(int[,] matrix, int posX, int posY)
        {
            var score = 0;

            var currentHeight = matrix[posX, posY];

            if (posY + 1 == matrix.GetLength(1))
            {
                return 0;
            }

            if (posY + 1 == matrix.GetLength(1) - 1)
            {
                return 1;
            }

            int y = posY + 1;

            while (y < matrix.GetLength(1))
            {
                var newHeight = matrix[posX, y];

                score++;

                if (newHeight >= currentHeight)
                {
                    break;
                }

                y++;
            }

            return score;
        }

        public static int FindScenicScore(int[,] matrix)
        {
            var scenicScore = 0;

            int rows = matrix.GetLength(0);

            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var up = CalculateScenicScoreUp(matrix, i, j);

                    var down = CalculateScenicScoreDown(matrix, i, j);

                    var left = CalculateScenicScoreLeft(matrix, i, j);

                    var right = CalculateScenicScoreRight(matrix, i, j);

                    if (up == 0)
                    {
                        up = 1;
                    }

                    if (down == 0)
                    {
                        down = 1;
                    }

                    if (left == 0)
                    {
                        left = 1;
                    }

                    if (right == 0)
                    {
                        right = 1;
                    }

                    var thisScore = up * down * left * right;

                    Console.WriteLine($"{scenicScore} - {thisScore} - {i} - {j}");

                    if (thisScore > scenicScore)
                    {
                        scenicScore = thisScore;
                    }
                }
            }

            return scenicScore;
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