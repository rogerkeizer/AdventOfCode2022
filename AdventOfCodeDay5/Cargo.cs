namespace AdventOfCodeDay5
{
    internal class Cargo
    {
        internal readonly Dictionary<int, string> crates = new();

        internal List<char> cratesToMove = new();

        internal string currentCrates = string.Empty;

        public Cargo(string input)
        {
            GetStartingStacksOfCrates(input);
        }

        internal void GetCargoAndMoveOneAtATime(int fromStack, int toStack, int numberCrates)
        {
            currentCrates = GetCratesAt(fromStack);

            GetCratesFromOneAtATime(numberCrates);

            PutCratesAt(toStack);

            RemoveCratesAt(fromStack, numberCrates);

            Reset();
        }

        internal void GetCargoAndMoveAllAtOnce(int fromStack, int toStack, int numberCrates)
        {
            currentCrates = GetCratesAt(fromStack);

            GetCratesFromAllAtOnce(numberCrates);

            PutCratesAt(toStack);

            RemoveCratesAt(fromStack, numberCrates);

            Reset();
        }

        private void GetStartingStacksOfCrates(string input)
        {
            using StreamReader reader = new(input);

            int i = 1;

            while (reader != null && !reader.EndOfStream)
            {
                var r = reader.ReadLine();

                if (r != null)
                {
                    crates.Add(i, GetCrates(r));

                    i++;
                }
            }
        }

        private static string GetCrates(string line)
        {
            return line.Split(' ')[1];
        }

        private void GetCratesFromOneAtATime(int numberCrates)
        {
            for (int i = currentCrates.Length; i > currentCrates.Length - numberCrates; i--)
            {
                cratesToMove.Add(currentCrates[i - 1]);
            }
        }

        private void GetCratesFromAllAtOnce(int numberCrates)
        {
            for (int i = currentCrates.Length - numberCrates; i < currentCrates.Length; i++)
            {
                cratesToMove.Add(currentCrates[i]);
            }
        }

        private string GetCratesAt(int fromStack)
        {
            return crates[fromStack];
        }

        private void PutCratesAt(int toStack)
        {
            for (int i = 0; i < cratesToMove.Count; i++)
            {
                crates[toStack] += cratesToMove[i];
            }
        }

        private void RemoveCratesAt(int fromStack, int numberCrates)
        {
            crates[fromStack] = currentCrates[..^numberCrates];
        }

        private void Reset()
        {
            currentCrates = string.Empty;

            cratesToMove = new();
        }
    }
}
