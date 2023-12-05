using System.Text;

namespace AdventOfCode2023
{
    public class PuzzleReader<T> where T: IPuzzleSolver
    {
        public StreamReader GetPuzzleInput(string puzzleName)
        {
            var fileName = $"{typeof(T).Namespace?.Split('.').Last()}\\{puzzleName}.txt";
            var fs = File.OpenRead(fileName);
            var sr = new StreamReader(fs, Encoding.UTF8);
            return sr;
        }
    }
}