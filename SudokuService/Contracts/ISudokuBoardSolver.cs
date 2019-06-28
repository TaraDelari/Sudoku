using SudokuService.Models;

namespace SudokuService.Contracts
{
    public interface ISudokuBoardSolver
    {
        Result<int[]> Solve(SudokuBoard board);
    }
}