using Xunit;

namespace AdventOfCodeday9.Tests
{
    public class FollowTests
    {
        [Theory]
        [InlineData(1, 0, 0, 1, 0, 1)]
        [InlineData(0, 1, 0, 1, 0, 1)]
        [InlineData(1, 0, 1, 0, 1, 0)]
        [InlineData(0, 1, 1, 0, 1, 0)]
        public void NoFollow(int xh, int yh, int xt, int yt, int xr, int yr)
        {
            var head = new Position(xh, yh);
            var tail = new Position(xt, yt);
            var expected = new Position(xr, yr);

            var result = tail.Follow(head, tail);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }

        [Theory]
        [InlineData(2, 0, 0, 1, 1, 0)]
        [InlineData(0, 2, 0, 1, 0, 1)]
        [InlineData(2, 0, 1, 0, 1, 0)]
        [InlineData(0, 2, 1, 0, 0, 1)]
        [InlineData(3, 0, 1, -1, 2, 0)]
        [InlineData(0, 3, -1, 1, 0, 2)]
        public void Follow(int xh, int yh, int xt, int yt, int xr, int yr)
        {
            var head = new Position(xh, yh);
            var tail = new Position(xt, yt);
            var expected = new Position(xr, yr);

            var result = tail.Follow(head, tail);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }
    }
}
