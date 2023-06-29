namespace SudokuSolver;

public class Square
{
    public Cell[,] cells;

    public Square(int size)
    {
        cells = new Cell[size, size];
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                cells[row, col] = new Cell();
            }
        }
    }

    public override string ToString()
    {
        string formatted = "";
        for (int row = 0; row < cells.GetLength(0); row++)
        {
            for (int col = 0; col < cells.GetLength(1); col++)
            {
                formatted += cells[row, col].ToString() + " ";
            }

            if (row < cells.GetLength(0) - 1) // Do not add an extra line at the end
                formatted += "\n";
        }

        return formatted;
    }
}