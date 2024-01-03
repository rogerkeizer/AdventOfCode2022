using Xunit;

namespace AdventOfCodeDay8.Tests
{
    public class CalculateScenicScoreRightTests
    {
        public static readonly string[] example = new string[]
        { "30373",
          "25512",
          "65332",
          "33549",
          "35390"
        };

        [Fact]
        public void CalculateScenicScoreRight_returns_product_of_visible_trees_in_right_direction()
        {
            int[,] matrix = Program.ParseFile(example);

            Assert.Equal(2, Program.CalculateScenicScoreRight(matrix, 0, 0));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 0, 1));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 0, 2));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 0, 3));
            Assert.Equal(0, Program.CalculateScenicScoreRight(matrix, 0, 4));

            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 1, 0));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 1, 1));
            Assert.Equal(2, Program.CalculateScenicScoreRight(matrix, 1, 2));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 1, 3));
            Assert.Equal(0, Program.CalculateScenicScoreRight(matrix, 1, 4));

            Assert.Equal(4, Program.CalculateScenicScoreRight(matrix, 2, 0));
            Assert.Equal(3, Program.CalculateScenicScoreRight(matrix, 2, 1));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 2, 2));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 2, 3));
            Assert.Equal(0, Program.CalculateScenicScoreRight(matrix, 2, 4));

            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 3, 0));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 3, 1));
            Assert.Equal(2, Program.CalculateScenicScoreRight(matrix, 3, 2));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 3, 3));
            Assert.Equal(0, Program.CalculateScenicScoreRight(matrix, 3, 4));

            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 4, 0));
            Assert.Equal(2, Program.CalculateScenicScoreRight(matrix, 4, 1));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 4, 2));
            Assert.Equal(1, Program.CalculateScenicScoreRight(matrix, 4, 3));
            Assert.Equal(0, Program.CalculateScenicScoreRight(matrix, 4, 4));

        }
    }
}
