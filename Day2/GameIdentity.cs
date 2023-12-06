namespace AdventOfCode2023.Day2
{
    internal struct GameIdentity
    {
        internal int Id { get; set; }
        internal List<Game> Games { get; set; }
        internal static GameIdentity GetGameIdentityAndGames(string line)
        {
            var strings = line.Split(':');
            var identity = strings[0].Replace("Game", string.Empty).Trim();
            var games = strings[1].Trim().Split(';');

            return new()
            {
                Id = int.Parse(identity),
                Games = games.Select(x => new Game
                {
                    Revealed = x.Trim().Split(',').Select(y => y.Trim().Split(' ')).ToDictionary(y => y[1], y => int.Parse(y[0]))
                }).ToList()
            };
        }
    }
}