namespace AdventOfCode2023.Day2
{
    public class D02P2: IPuzzleSolver
    {
        private readonly PuzzleReader<D02P2> _reader = new();
        public string PuzzleName => "Day2";

        public void Solve()
        {
            using var puzzleInput = _reader.GetPuzzleInput(PuzzleName);

            var total = 0;
            while (puzzleInput.ReadLine() is { } line)
            {
                var gameIdentity = GameIdentity.GetGameIdentityAndGames(line); 
                
                var maxValues = new Dictionary<string, int>();
                foreach (var game in gameIdentity.Games)
                {
                    foreach (var reveal in game.Revealed)
                    {
                        if (!maxValues.ContainsKey(reveal.Key))
                            maxValues.Add(reveal.Key, reveal.Value);
                        else
                            maxValues[reveal.Key] = Math.Max(maxValues[reveal.Key], reveal.Value);
                    }
                }
                
                var gameTotal = 1;
                foreach (var maxValue in maxValues)
                {
                    gameTotal *= maxValue.Value;
                }
                total += gameTotal;
            }

            Console.WriteLine(total);
        }
    }
}