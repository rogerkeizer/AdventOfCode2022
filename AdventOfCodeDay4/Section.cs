namespace AdventOfCodeDay4
{
    internal class Section
    {
        public List<int> range = new();

        public void AddToRange(int start, int end)
        {
            for (var i = start; i <= end; i++)
            {
                range.Add(i);
            }
        }
    }
}
