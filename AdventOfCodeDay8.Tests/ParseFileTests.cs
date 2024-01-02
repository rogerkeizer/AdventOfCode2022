using Xunit;

namespace AdventOfCodeDay8.Tests
{
    public class ParseFileTests
    {
        [Fact]
        public void ParseFile_string_input_generates_grid_of_int()
        {
            var grid = AdventOfCodeDay8.Program.ParseFile(new string[] { "30373", "25512", "65332", "33549", "35390" });

            int[,] expected = {
                {3,0,3,7,3 },
                {2,5,5,1,2 },
                {6,5,3,3,2 },
                {3,3,5,4,9 },
                {3,5,3,9,0 }
            };

            Assert.Equal(expected, grid);
        }
    }
}

