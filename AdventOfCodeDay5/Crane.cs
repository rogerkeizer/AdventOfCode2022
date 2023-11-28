using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCodeDay5
{
    internal class Crane
    {
        private readonly List<List<int>> moves = new();

        private readonly Cargo _cargo;

        public Crane(Cargo cargo)
        { 
            _cargo = cargo;
        }

        public void GetRearrangementProcedure(string input)
        {
            using StreamReader reader = new(input);

            while (reader != null && !reader.EndOfStream)
            {
                var r = reader.ReadLine();

                if (r != null)
                {
                    moves.Add(GetMove(r));
                }
            }
        }

        public void MoveCargo()
        {
            foreach (var move in moves)
            {
                var numberOfCrates = move[0];

                var stackFrom = move[1];

                var stackTo = move[2];

                _cargo.GetCargoAndMove(stackFrom, stackTo, numberOfCrates);
            }
        }

        public string GetCratesOnTopOfStack()
        {
            StringBuilder result = new();

            var numberOfStacks = _cargo.crates.Count;

            for(int i = 1; i <= numberOfStacks; i++) 
            {
                result.Append(_cargo.crates[i][^1..]);
            }

            return result.ToString();
        }

        private static List<int> GetMove(string r)
        {
            var move = new List<int>();

            string[] strings = r.Split(' ');

            foreach (string s in strings) 
            {
                var result = string.Join(string.Empty, Regex.Matches(s, @"\d+").OfType<Match>().Select(m => m.Value));

                if (Regex.IsMatch(result, @"^\d+$"))
                { 
                    move.Add(Convert.ToInt32(result));
                }
            }

            return move;
        }
    }
}
