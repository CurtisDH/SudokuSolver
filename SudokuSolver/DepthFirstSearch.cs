namespace SudokuSolver;

public class DepthFirstSearch
{
    private char[]? _choices;
    private readonly Cell[,] _cells;

    public DepthFirstSearch(Grid sudoku)
    {
        InitialiseChoices();
        _cells = UnpackGrid(sudoku);
    }

    public (bool, Grid) StartSearch()
    {
        // Returns false if unsolvable 
        return Dfs(0, 0);
    }

    // TODO change to while loop instead of recursion
    private (bool, Grid) Dfs(int row, int column)
    {
        if (row == 9) // filled all rows Sudoku is solved
        {
            return (true, PackGrid(_cells));
        }

        var cell = _cells[row, column];

        if (cell.Filled)
        {
            return Dfs(column == 8 ? (row + 1) : row, (column + 1) % 9);
        }

        foreach (var c in _choices)
        {
            if (!IsValidChoice(row, column, c)) continue;

            _cells[row, column].Set(c);
            var (isSolved, solvedGrid) = Dfs(column == 8 ? (row + 1) : row, (column + 1) % 9);

            if (isSolved)
            {
                return (true, solvedGrid);
            }

            _cells[row, column].Clear(); // leads to invalid path so remove the choice
        }

        // unsolvable
        return (false, PackGrid(_cells));
    }


    private bool IsValidChoice(int row, int col, char choice)
    {
        return CheckRow(row, choice) && CheckCol(col, choice) && CheckSquare(row, col, choice);
    }

    private bool CheckCol(int col, char c)
    {
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            var cell = _cells[i, col].Value;
            if (cell == c)
            {
                return false;
            }
        }

        return true;
    }


    private bool CheckRow(int row, char c)
    {
        for (int i = 0; i < _cells.GetLength(1); i++)
        {
            var cell = _cells[row, i].Value;
            if (cell == c)
            {
                return false;
            }
        }

        return true;
    }


    private bool CheckSquare(int row, int col, char choice)
    {
        int startRow = row / 3 * 3;
        int startCol = col / 3 * 3;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (startRow + i == row && startCol + j == col)
                    continue; //skip as its the current cell that is being checked

                var cell = _cells[startRow + i, startCol + j];
                if (cell.Value == choice)
                {
                    // value present in the square
                    return false;
                }
            }
        }

        return true;
    }


    private void InitialiseChoices()
    {
        var l = new List<char>();
        for (int i = 1; i <= 9; i++)
        {
            l.Add(i.ToString().ToCharArray()[0]);
        }

        _choices = l.ToArray();
        foreach (var ch in _choices)
        {
            Console.WriteLine($"CHOICE INIT:{ch}");
        }
    }


    // TODO this is hideous
    private Cell[,] UnpackGrid(Grid grid)
    {
        // TODO remove the hardcoded values
        var Cells = new Cell[9, 9];

        // Unpack squares into Cells array
        for (int sqRow = 0; sqRow < 3; sqRow++)
        {
            for (int sqCol = 0; sqCol < 3; sqCol++)
            {
                Square square = grid.Squares[sqRow, sqCol];

                for (int cellRow = 0; cellRow < 3; cellRow++)
                {
                    for (int cellCol = 0; cellCol < 3; cellCol++)
                    {
                        Cells[sqRow * 3 + cellRow, sqCol * 3 + cellCol] = square.cells[cellRow, cellCol];
                    }
                }
            }
        }

        return Cells;
    }
    // TODO this is hideous

    private Grid PackGrid(Cell[,] cells)
    {
        Grid grid = new Grid(9, 9);
        for (int sqRow = 0; sqRow < 3; sqRow++)
        {
            for (int sqCol = 0; sqCol < 3; sqCol++)
            {
                Square square = new Square(3);

                for (int cellRow = 0; cellRow < 3; cellRow++)
                {
                    for (int cellCol = 0; cellCol < 3; cellCol++)
                    {
                        square.cells[cellRow, cellCol] = cells[sqRow * 3 + cellRow, sqCol * 3 + cellCol];
                    }
                }

                grid.Squares[sqRow, sqCol] = square;
            }
        }

        return grid;
    }
}