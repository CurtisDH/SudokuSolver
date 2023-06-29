namespace SudokuSolver;

public class Grid
{
    public Square[,] Squares { get; private set; }

    public Grid(int horizontalSize, int verticalSize)
    {
        int hs = horizontalSize / 3;
        int vs = verticalSize / 3;
        Squares = new Square[hs, vs];
        for (int i = 0; i < hs; i++)
        {
            for (int j = 0; j < vs; j++)
            {
                Squares[i, j] = new Square(3);
            }
        }
    }

    public void LoadExistingGame(char[,] sudoku)
    {
        int gridSize = sudoku.GetLength(0); // only supports a square grid atm

        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                int squareRow = row / 3;
                int squareCol = col / 3;

                int cellRow = row % 3;
                int cellCol = col % 3;

                if (sudoku[row, col] == '0')
                {
                    sudoku[row, col] = '#';
                }

                Squares[squareRow, squareCol].cells[cellRow, cellCol].Set(sudoku[row, col]);
            }
        }
    }


    public override string ToString()
    {
        string formatted = "";
        for (int i = 0; i < Squares.GetLength(0); i++)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int j = 0; j < Squares.GetLength(1); j++)
                {
                    formatted += Squares[i, j].ToString().Split('\n')[row] + " | ";
                }

                formatted = formatted.TrimEnd(' ', '|', ' ') + "\n"; // Remove trailing space and pipe
            }

            formatted += new String('-', 25) + "\n"; // Add horizontal line after each 3 rows
        }

        formatted = formatted.TrimEnd('\n', '-'); // Remove trailing new line and dash
        return formatted;
    }
}