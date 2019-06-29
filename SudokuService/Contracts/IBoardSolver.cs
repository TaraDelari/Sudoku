using SudokuService.Models;

namespace SudokuService.Contracts
{
    public interface IBoardSolver
    {
        Result<int[]> Solve(SudokuBoard board);
    }
}