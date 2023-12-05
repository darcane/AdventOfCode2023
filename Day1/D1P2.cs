namespace AdventOfCode2023.Day1
{
    public class D1P2 : IPuzzleSolver
    {
        private readonly PuzzleReader<D1P1> _reader = new();

        private static readonly List<string> numberList = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
        public string PuzzleName => "Day1";

        public void Solve()
        {
            using var puzzleInput = _reader.GetPuzzleInput(PuzzleName);

            var total = 0;

            while (puzzleInput.ReadLine() is { } line)
            {
                int first = -1, last = -1;

                var result = FindFirstAndLast(line);
                if (result.Item1 != null) first = GetIntOfString(result.Item1);
                last = GetIntOfString(result.Item2);

                total += (first * 10) + last;
            }

            Console.WriteLine(total);
        }

        private static int GetIntOfString(string number)
        {
            switch (number)
            {
                case "1":
                case "one":
                    return 1;

                case "2":
                case "two":
                    return 2;

                case "3":
                case "three":
                    return 3;

                case "4":
                case "four":
                    return 4;

                case "5":
                case "five":
                    return 5;

                case "6":
                case "six":
                    return 6;

                case "7":
                case "seven":
                    return 7;

                case "8":
                case "eight":
                    return 8;

                case "9":
                case "nine":
                    return 9;

                // Add additional cases as needed

                default:
                    // Handle the case where the input is not recognized
                    throw new ArgumentException("Invalid input");
            }
        }

        private static Tuple<string, string> FindFirstAndLast(string input)
        {
            string firstItem = "", lastItem = "";
            int firstIndex = int.MaxValue, lastIndex = -1;

            foreach (var item in numberList)
            {
                var index = input.IndexOf(item, StringComparison.Ordinal);
                var lIndex = input.LastIndexOf(item, StringComparison.Ordinal);
                if (index == -1) continue;
                if (index < firstIndex)
                {
                    firstItem = item;
                    firstIndex = index;
                }

                if (lIndex > lastIndex)
                {
                    lastItem = item;
                    lastIndex = lIndex;
                }
            }

            return Tuple.Create(firstItem, lastItem);
        }
    }
}