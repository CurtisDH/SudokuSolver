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
            (bool solved, grid) = DFS.StartSearch();
            Console.WriteLine($"solved:{solved} \n{grid.ToString()}");
        }
    }
}