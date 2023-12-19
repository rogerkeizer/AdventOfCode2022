// https://adventofcode.com/2022/day/7
//
// input-test.text
//
//- / (dir)
//  - a(dir)
//    - e(dir)
//      - i(file, size = 584)
//    - f(file, size = 29116)
//    - g(file, size = 2557)
//    - h.lst(file, size = 62596)
//  - b.txt(file, size = 14848514)
//  - c.dat(file, size = 8504156)
//  - d(dir)
//    - j(file, size = 4060174)
//    - d.log(file, size = 8033020)
//    - d.ext(file, size = 5626152)
//    - k(file, size = 7214296)
//
// star 1: 95437

namespace AdventOfCodeDay7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = ReadLines("input.txt");

            List<AbsolutePath> dirs = ParseDirectories(lines);

            SolveStar1(dirs);

            SolveStar2(dirs);

            Console.ReadKey();
        }

        private static void SolveStar1(List<AbsolutePath> dirs)
        {
            var total = dirs.Where(x => x.Size <= 100000).Sum(x => x.Size);

            Console.WriteLine($"star 1: {total}");
        }

        private static void SolveStar2(List<AbsolutePath> dirs)
        {
            if (dirs != null)
            {
                var dirsSorted = dirs.OrderBy(s => s.Size).ToArray();

                var root = dirsSorted.Last();

                var spaceOnDisk = 70000000 - root.Size;

                var spaceToUpdate = 30000000 - spaceOnDisk;

                Console.WriteLine($"root: {root.Size}");

                Console.WriteLine($"space needed: {spaceToUpdate}");

                for (int i = 0; i < dirsSorted.Length; i++)
                {
                    Console.WriteLine($"{dirsSorted[i].Path} - {dirsSorted[i].Size}");

                    if (dirsSorted[i].Size > spaceToUpdate)
                    {
                        Console.WriteLine($"star 2: {dirsSorted[i].Size}");

                        break;
                    }
                }
            }
        }

        private static List<AbsolutePath> ParseDirectories(List<string> lines)
        {
            var dirs = new List<AbsolutePath>();

            var paths = new List<string>();

            foreach (var line in lines)
            {
                if (line.Equals("$ cd .."))
                {
                    paths = paths.SkipLast(1).ToList();
                }
                else if (line.StartsWith("$ cd"))
                {
                    var dir = line.Split(' ').Last();

                    paths.Add(dir);

                    var directoryName = string.Join('/', paths);

                    if (!dirs.Any(x => x.Path == directoryName))
                    {
                        dirs.Add(new AbsolutePath { Path = directoryName });
                    }
                }
                else if (int.TryParse(line.Split(' ')[0], out int fileSize))
                {
                    dirs.Where(x => string
                        .Join('/', paths)
                        .Contains(x.Path))
                        .ToList()
                        .ForEach(x => x.Size += fileSize);
                }
            }

            return dirs;
        }

        private static List<string> ReadLines(string input)
        {
            List<string> lines = new();

            using StreamReader reader = new(input);

            while (reader != null && !reader.EndOfStream)
            {
                var r = reader.ReadLine();

                if (r != null)
                {
                    lines.Add(r);
                }
            }

            return lines;
        }
    }
}