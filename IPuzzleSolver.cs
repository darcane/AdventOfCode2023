namespace AdventOfCode2023
{
    public interface IPuzzleSolver
    {
        string PuzzleName { get; }
        void Solve();
    }
}