using SudokuService.Contracts;
using SudokuService.Models;

namespace SudokuService.Services
{
    public class Sudoku
    {
        private IBoardSolver _solver;
        private IBoardValidator _boardValidator;

        public Sudoku(IBoardSolver solver, IBoardValidator boardValidator)
        {
            _solver = solver;
            _boardValidator = boardValidator;
        }

        public Result<int[]> Solve(SudokuBoard board)
        {
            Result<int[]> result = new Result<int[]>();
            Result validationResult = _boardValidator.Validate(board);
            if (!validationResult.IsSuccess)
            {
                result.Error = validationResult.Error;
                return result;

            }
            return _solver.Solve(board);
        }
    }
}