using AdventOfCodeday9;
using Xunit;

namespace AdventOfCodeDay9.Tests
{
    public class MoveTests
    {
        [Fact]
        public void MoveRight()
        {
            var position = new Position(0, 0);
            var expected = new Position(1, 0);

            var result = position.Move(Direction.Right);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }

        [Fact]
        public void MoveLeft()
        {
            var position = new Position(0, 0);
            var expected = new Position(-1, 0);

            var result = position.Move(Direction.Left);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }

        [Fact]
        public void MoveUp()
        {
            var position = new Position(0, 0);
            var expected = new Position(0, 1);

            var result = position.Move(Direction.Up);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }

        [Fact]
        public void MoveDown()
        {
            var position = new Position(0, 0);
            var expected = new Position(0, -1);

            var result = position.Move(Direction.Down);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }

        [Fact]
        public void MoveUpRight()
        {
            var position = new Position(0, 0);
            var expected = new Position(1, 1);

            var result = position
                .Move(Direction.Up)
                .Move(Direction.Right);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }

        [Fact]
        public void MoveUpLeft()
        {
            var position = new Position(0, 0);
            var expected = new Position(-1, 1);

            var result = position
                .Move(Direction.Up)
                .Move(Direction.Left);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }

        [Fact]
        public void MoveDownRight()
        {
            var position = new Position(0, 0);
            var expected = new Position(1, -1);

            var result = position
                .Move(Direction.Down)
                .Move(Direction.Right);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }

        [Fact]
        public void MoveDownLeft()
        {
            var position = new Position(0, 0);
            var expected = new Position(-1, -1);

            var result = position
                .Move(Direction.Down)
                .Move(Direction.Left);

            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
        }
    }
}