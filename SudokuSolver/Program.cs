using System.Diagnostics;

namespace SudokuSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new SudokuGenerator();
            var grid = generator.CreateRandomPuzzle();
            Console.WriteLine(grid.ToString());
        }
    }
}