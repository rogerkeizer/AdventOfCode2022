/*
 * https://adventofcode.com/2022/day/6
 * 
 */

internal class Program
{
    private static void Main(string[] args)
    {
        string dataStream = File.ReadAllText("input.txt");

        List<char> found = new();

        var isMarker = false;

        for (int i = 3; i < dataStream.Length; i++)
        {
            if (i >= 3)
            {
                var marker = dataStream.Skip(i - 3).Take(4).Select(x => x).ToList();

                isMarker = marker.Distinct().Count() == marker.Count;
            }

            if (isMarker) 
            {
                Console.WriteLine(i + 1);
            }
        }
    }
}