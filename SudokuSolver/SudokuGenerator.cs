namespace SudokuSolver;

// This will be used for generating and testing Sudoku games, and potentially turn into a parser for images
public class SudokuGenerator
{
    // 9x9 square must be filled in with numbers from 1-9 with no repeated numbers in each line horizontally or vertically
    // There are also 3x3 squares marked out in the grid, each of these squares cannot have repeating numbers either
    public void test()
    {
        var s = new Square(3, 3);
    }
}

class Square
{
    private string[,] Grid;

    public Square(int sizeX, int sizeY)
    {
        Grid = new string[sizeX, sizeY];
        for (int row = 0; row < sizeX; row++)
        {
            for (int content = 0; content < sizeY; content++)
            {
                Grid[row, content] += "y";
            }
        }

        Console.WriteLine(this.ToString());
    }

    public override string ToString()
    {
        string formatted = "";
        for (int row = 0; row < Grid.GetLength(0); row++)
        {
            for (int content = 0; content < Grid.GetLength(1); content++)
            {
                formatted += Grid[row, content];
            }

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
        this.squares = squares;
    }

    public override string ToString()
    {
        string formatted;
        foreach (var square in squares)
        {
        }

        return base.ToString();
    }
}