namespace AdventOfCode2023.Day2
{
    public class D02P1: IPuzzleSolver
    {
        private readonly PuzzleReader<D02P1> _reader = new();
        public string PuzzleName => "Day2";

        private readonly Dictionary<string, int> _allowedMax = new()
        {
            {"red",12},
            {"green",13},
            {"blue",14}
        };

        public void Solve()
        {
            using var puzzleInput = _reader.GetPuzzleInput(PuzzleName);

            var total = 0;
            while (puzzleInput.ReadLine() is { } line)
            {
                var gameIdentity = GameIdentity.GetGameIdentityAndGames(line); 
                var shouldSkip = false;

                foreach (var game in gameIdentity.Games)
                {
                    foreach (var reveal in game.Revealed)
                    {
                        if (reveal.Value > _allowedMax[reveal.Key])
                        {
                            shouldSkip = true;
                            break;
                        }
                    }

                    if (shouldSkip)
                        break;

                }
                if (shouldSkip)
                    continue;
                total += gameIdentity.Id;
            }

            Console.WriteLine(total);
        }
    }
}