# Sudoku Solver

## Project Overview
This project a solver for Sudoku puzzles. The project uses a Depth First Search (DFS) algorithm, and includes functionality to generate valid, solvable Sudoku puzzles of varying difficulty.

## Features

1. **Sudoku Solver**: Can solve any Sudoku puzzle. Currently the implemented solution uses a brute-force DFS algorithm which while not the most efficient, ensures that a solution will be found if one exists.

2. **Puzzle Generation**: The program can generate valid, solvable Sudoku puzzles of varying difficulty.


## Current Limitations
1. DFS algorithm has to start from the top left corner of the grid (0,0)
2. Grid size is 9x9

## Installation and Usage

This project is developed in C#. You will need the .NET 7.x to run it.

1. Clone this repository to your local machine.
2. Open the project in your favorite IDE that supports C# (such as Visual Studio / Rider).
3. Compile and run the project.

If you want to use the command line, navigate to the project directory and use the `dotnet run` command.

## Roadmap

1. **Unique Solution Validation**: Ability to verify whether a given puzzle has a unique solution or multiple solutions.
2. **Performance optimisations**: Implementation of other algorithms to improve efficency
3. **Bulk Generation with Multi-threading**: Implementation of a mulithreaded solution to bulk-create solvable puzzles and save these in a format that can easily be exported.
4. **Dynamic Grid sizing**: Allowing for dynamically sized grids instead of the fixed 9x9

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details. 
