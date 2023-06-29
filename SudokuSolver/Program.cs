using System.Diagnostics;

namespace SudokuSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sg = new SudokuGenerator();
            var grid = sg.test();
            Console.WriteLine(grid.ToString());
            var DFS = new DepthFirstSearch(grid);
            Console.WriteLine();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            (bool solved, grid) = DFS.StartSearch(0, 0);
            sw.Stop();
            // Console.WriteLine($"solved:{solved} elapsed time:{sw.Elapsed.TotalMilliseconds}ms \n{grid.ToString()}");
            //
            sg.test2();
        }
    }
}