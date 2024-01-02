using Xunit;

namespace AdventOfCodeDay8.Tests
{
    public class FindVisibleTreesTests
    {
        public static readonly string[] example = new string[]
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };

        [Fact]
        public void FindVisibleTrees_from_all_directions_returns_no_duplicate_trees()
        {
            var expectedVisibleTrees = 21;

            var matrix = Program.ParseFile(example);

            var actualVisibleTrees = Program.FindVisibleTrees(matrix);

            Assert.Equal(expectedVisibleTrees, actualVisibleTrees);
        }
    }
}
