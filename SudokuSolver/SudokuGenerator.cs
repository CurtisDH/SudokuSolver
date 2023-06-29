namespace SudokuSolver
{
    public class SudokuGenerator
    {
        // Things to consider when generating a board
        // Has to be unique -- TODO implement later
        // Could just generate a board by starting with a random number in a random cell?
        public Grid test2()
        {
            var grid = new Grid(9, 9);
            var dfs = new DepthFirstSearch(grid, true);
            var solved = dfs.StartSearch(0, 0);
            Console.WriteLine(grid.ToString());
            return grid;
        }

        public Grid test()
        {
            var grid = new Grid(9, 9);
            char[,] sudoku = new char[9, 9]
            {
                { '5', '3', '0', '0', '7', '0', '0', '0', '0' },
                { '6', '0', '0', '1', '9', '5', '0', '0', '0' },
                { '0', '9', '8', '0', '0', '0', '0', '6', '0' },
                { '8', '0', '0', '0', '6', '0', '0', '0', '3' },
                { '4', '0', '0', '8', '0', '3', '0', '0', '1' },
                { '7', '0', '0', '0', '2', '0', '0', '0', '6' },
                { '0', '6', '0', '0', '0', '0', '2', '8', '0' },
                { '0', '0', '0', '4', '1', '9', '0', '0', '5' },
                { '0', '0', '0', '0', '8', '0', '0', '7', '9' },
            };
            grid.LoadExistingGame(sudoku);
            return grid;
        }
    }
}