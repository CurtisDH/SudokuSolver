namespace SudokuSolver;

public class DepthFirstSearch
{
    // we want to input a grid
    // choose a starting point (0,0)
    // select a number, check if its valid by doing the following
    // 1. Check the contents of the current square the cell is situated in
    // 2. check the entire row
    // 3. check the entire column
    // if a number conflicts, we return false, 'returning control' back recursively.
    // if it doesn't we set the value, and move onto the next cell and repeat the process

    private char[] Choices;

    public bool SolveGame(Grid sudoku)
    {
        InitialiseChoices();
        return Dfs(sudoku);
    }

    private bool Dfs(Grid g)
    {
        var cells = UnpackGrid(g);
        var cellRowLength = cells.GetLength(0);
        var cellColLength = cells.GetLength(1);
        for (int i = 0; i < cellRowLength; i++)
        {
            for (int j = 0; j < cellColLength; j++)
            {
                
            }
        }

        // Unsolvable
        return false;
    }


    private void InitialiseChoices()
    {
        var l = new List<char>();
        for (int i = 1; i < 9; i++)
        {
            Console.WriteLine(i);
            l.Add((char)i);
        }

        Choices = l.ToArray();
    }


    // TODO this is hideous
    private Cell[,] UnpackGrid(Grid grid)
    {
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
}