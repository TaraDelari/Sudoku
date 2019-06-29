using SudokuService.Models;

namespace SudokuService.Contracts
{
    public interface IBoardValidator
    {
        Result Validate(SudokuBoard board);
    }
}
