namespace SudokuSolver;

public class DepthFirstSearch
{
    private char[]? _choices;
    private readonly Cell[,] _cells;
    private bool _useRandomChar = false;

    public DepthFirstSearch(Grid sudoku, bool useRandomChar = false)
    {
        this._useRandomChar = useRandomChar;
        InitialiseChoices();
        _cells = sudoku.Unpack();
    }

    public (bool, Grid) StartSearch(int x, int y)
    {
        // Returns false if unsolvable 
        return Dfs(x, y);
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

        if (_useRandomChar)
        {
            Random rng = new Random();
            l = l.OrderBy(n => rng.Next()).ToList();
        }

        _choices = l.ToArray();
    }

    // TODO this is hideous

    public Grid PackGrid(Cell[,] cells)
    {
        // TODO still gotta remove these magic numbers 
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