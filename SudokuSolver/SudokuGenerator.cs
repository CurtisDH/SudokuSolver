namespace SudokuSolver
{
    public class SudokuGenerator
    {
        // Verify unique solution -- TODO implement later

        public Grid CreateRandomPuzzle(int missingCells = 50)
        {
            var grid = new Grid(9, 9);
            var dfs = new DepthFirstSearch(grid, true);
            dfs.StartSearch(0, 0);

            // randomise grid by removing random cells
            var unpacked = grid.Unpack();
            int removeCells = 55;
            System.Random x = new Random();
            System.Random y = new Random();
            for (int i = 0; i < removeCells; i++)
            {
                var cell = unpacked[x.Next(0, 9), y.Next(0, 9)];
                while (!cell.Filled)
                {
                    cell = unpacked[x.Next(0, 9), y.Next(0, 9)];
                }

                cell.Clear();
            }

            grid = dfs.PackGrid(unpacked);

            return grid;
        }

        public Grid LoadExistingGameTest()
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