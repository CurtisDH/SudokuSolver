namespace SudokuSolver;

public class Cell
{
    public char Value { get; private set; }
    public bool Filled { get; private set; }
    private const char DefaultVal = '#';

    public Cell(char value = DefaultVal)
    {
        Value = value;
    }

    public void Set(char value)
    {
        if (value == DefaultVal)
        {
            Clear();
            return;
        }

        Value = value;
        Filled = true;
    }

    public void Clear()
    {
        Value = '#';
        Filled = false;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}