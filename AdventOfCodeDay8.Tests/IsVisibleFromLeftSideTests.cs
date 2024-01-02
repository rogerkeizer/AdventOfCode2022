using Xunit;

namespace AdventOfCodeDay8.Tests
{
    public class IsVisibleFromLeftSideTests
    {
        public static readonly string[] example = new string[] { "30373", "25512", "65332", "33549", "35390" };

        [Fact]
        public void IsVisibleFromLeftSide_returns_false_when_previous_col_is_higher_for_a_position()
        {
            int[,] matrix = Program.ParseFile(example);

            Assert.True(Program.IsVisibleFromLeftSide(matrix, 0, 0));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 0, 1));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 0, 2));
            Assert.True(Program.IsVisibleFromLeftSide(matrix, 0, 3));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 0, 4));

            Assert.True(Program.IsVisibleFromLeftSide(matrix, 1, 0));
            Assert.True(Program.IsVisibleFromLeftSide(matrix, 1, 1));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 1, 2));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 1, 3));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 1, 4));

            Assert.True(Program.IsVisibleFromLeftSide(matrix, 2, 0));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 2, 1));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 2, 2));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 2, 3));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 2, 4));

            Assert.True(Program.IsVisibleFromLeftSide(matrix, 3, 0));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 3, 1));
            Assert.True(Program.IsVisibleFromLeftSide(matrix, 3, 2));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 3, 3));
            Assert.True(Program.IsVisibleFromLeftSide(matrix, 3, 4));

            Assert.True(Program.IsVisibleFromLeftSide(matrix, 4, 0));
            Assert.True(Program.IsVisibleFromLeftSide(matrix, 4, 1));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 4, 2));
            Assert.True(Program.IsVisibleFromLeftSide(matrix, 4, 3));
            Assert.False(Program.IsVisibleFromLeftSide(matrix, 4, 4));
        }
    }
}
