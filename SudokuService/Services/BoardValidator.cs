using SudokuService.Contracts;
using SudokuService.Models;
using System.Collections.Generic;
using System.Linq;

namespace SudokuService.Services
{
    public class BoardValidator : IBoardValidator
    {
        public Result Validate(SudokuBoard board)
        {
            Result result = new Result();
            if (board.Cells.Count() != 81)
            {
                result.Error = "The sent board is invalid.";
                return result;
            }

            Cell[] filledCells = board.Cells.Where(x => x.GetValue() != 0).ToArray();
            foreach (var cell in filledCells)
            {
                List<int> neighbours = board.GetCellNeighbourValues(cell);
                if (neighbours.Any(x => x == cell.GetValue()))
                {
                    result.Error = "The sent board is invalid.";
                    return result;
                }
            }
            return result;
        }
    }
}