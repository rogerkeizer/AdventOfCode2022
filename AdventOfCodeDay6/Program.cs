/*
 * https://adventofcode.com/2022/day/6
 * 
 * star 1: Marker
 * mjqjpqmgbljsphdztnvjfqwrcgsmlb: first marker after character 7
 * bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 5
 * nppdvjthqldpwncqszvftbrmjlhg: first marker after character 6
 * nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 10
 * zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 11
 * 
 * star 2: Message marker
 * mjqjpqmgbljsphdztnvjfqwrcgsmlb: first marker after character 19
 * bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 23
 * nppdvjthqldpwncqszvftbrmjlhg: first marker after character 23
 * nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 29
 * zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 26
 */

internal class Program
{
    private static void Main(string[] args)
    {
        string dataStream = File.ReadAllText("input.txt");

        List<char> found = new();

        var isMarker = false;

        var isMessage = false;

        var markerlength = 4;

        var messageLength = 14;

        for (int i = (markerlength - 1); i < dataStream.Length; i++)
        {
            if (i >= (markerlength - 1))
            {
                var marker = dataStream.Skip(i - (markerlength - 1)).Take(markerlength).Select(x => x).ToList();

                isMarker = marker.Distinct().Count() == marker.Count;

                if (i >= (messageLength - 1))
                {
                    var message = dataStream.Skip(i - (messageLength - 1)).Take(messageLength).Select(x => x).ToList();

                    isMessage = message.Distinct().Count() == message.Count;
                }
            }

            if (isMarker) 
            {
                Console.WriteLine(i + 1);
            }

            if (isMessage)
            {
                Console.WriteLine($"Message: {i + 1}");
            }
        }
    }
}