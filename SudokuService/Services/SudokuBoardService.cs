using SudokuService.Contracts;
using SudokuService.Models;

namespace SudokuService.Services
{
    public class SudokuBoardService
    {
        private ISudokuBoardSolver _solver;

        public SudokuBoardService(ISudokuBoardSolver solver)
        {
            _solver = solver;
        }

        public Result<int[]> Solve(SolveRequest request)
        {
            Result<int[]> result = new Result<int[]>();
            SudokuBoard board = new SudokuBoard(request.BoardFields);
            Result validationResult = SudokuBoardValidator.Validate(board);
            if (!validationResult.IsSuccess)
            {
                result.Error = validationResult.Error;
                return result;

            }
            return _solver.Solve(board);
        }
    }
}