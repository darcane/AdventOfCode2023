namespace AdventOfCode2023.Day1
{
    public class D1P1: IPuzzleSolver
    {
        private readonly PuzzleReader<D1P1> _reader = new();
        public string PuzzleName => "Day1";

        public void Solve()
        {
            using var puzzleInput = _reader.GetPuzzleInput(PuzzleName);

            var total = 0;

            while (puzzleInput.ReadLine() is { } line)
            {
                int first = -1, last = -1;

                foreach (var c in line)
                {
                    if (int.TryParse(c.ToString(), out _))
                    {
                        if (first == -1)
                        {
                            first = int.Parse(c.ToString());
                        }
                        last = int.Parse(c.ToString());
                    }
                }

                total += (first * 10) + last;
            }

            Console.WriteLine(total);
        }
    }
}