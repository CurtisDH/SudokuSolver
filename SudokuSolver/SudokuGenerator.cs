namespace SudokuSolver
{
    public class SudokuGenerator
    {
        public void test()
        {
            var grid = new Grid(9, 9);
            Console.WriteLine(grid.ToString());
        }
    }

    class Cell
    {
        public char Value { get; private set; }

        public Cell(char value = '#')
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    class Square
    {
        private Cell[,] cells;

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

    class Grid
    {
        private Square[,] squares;

        public Grid(int horizontalSize, int verticalSize)
        {
            int hs = horizontalSize / 3;
            int vs = verticalSize / 3;
            squares = new Square[hs, vs];
            for (int i = 0; i < hs; i++)
            {
                for (int j = 0; j < vs; j++)
                {
                    squares[i, j] = new Square(3);
                }
            }
        }

        public override string ToString()
        {
            string formatted = "";
            for (int i = 0; i < squares.GetLength(0); i++)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int j = 0; j < squares.GetLength(1); j++)
                    {
                        formatted += squares[i, j].ToString().Split('\n')[row] + " | ";
                    }

                    formatted = formatted.TrimEnd(' ', '|', ' ') + "\n"; // Remove trailing space and pipe
                }

                formatted += new String('-', 25) + "\n"; // Add horizontal line after each 3 rows
            }

            formatted = formatted.TrimEnd('\n', '-'); // Remove trailing new line and dash
            return formatted;
        }
    }
}