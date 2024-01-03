using Xunit;

namespace AdventOfCodeDay8.Tests
{
    public class FindScenicScoreTests
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
        public void FindScenicScore_returns_product_of_all_directions()
        {
            var expectedScore = 16;

            var matrix = Program.ParseFile(example);

            var actualScore = Program.FindScenicScore(matrix);

            Assert.Equal(expectedScore, actualScore);
        }
    }
}
