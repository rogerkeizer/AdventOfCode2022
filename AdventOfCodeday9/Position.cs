namespace AdventOfCodeday9
{
    public record Position
    {
        public int x;
        public int y;

        public Position(int x2, int y2)
        {
            x = x2;
            y = y2;
        }

        public Position Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Up:
                    y++;
                    break;
                default:
                    y--;
                    break;
            }

            return new Position(x, y);
        }

        public Position Follow(Position head, Position tail)
        {
            if (IsNextToEachOther(head, tail))
            {
                return tail;
            }

            var xdif = NormalizeDistance(head.x - tail.x);

            var ydif = NormalizeDistance(head.y - tail.y);

            return new Position(tail.x + xdif, tail.y + ydif);
        }


        private static bool IsNextToEachOther(Position head, Position tail)
        {
            var xdif = Math.Abs(head.x - tail.x);

            var ydif = Math.Abs(head.y - tail.y);

            return xdif <= 1 && ydif <= 1;
        }

        private static int NormalizeDistance(int distance)
        {
            if (distance > 0)
            {
                return 1;
            }

            if (distance < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}
