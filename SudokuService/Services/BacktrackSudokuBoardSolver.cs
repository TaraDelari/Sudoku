using SudokuService.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SudokuService.Models
{
    class BacktrackSudokuBoardSolver : ISudokuBoardSolver
    {
        public Result<int[]> Solve(SudokuBoard board)
        {
            Result<int[]> result = new Result<int[]>();
            LinkedList<Cell> unsolvedCells = new LinkedList<Cell>(board.Cells.Where(x => x.GetValue() == 0).ToList());
            if (!FillCells(unsolvedCells, board))
                result.Error = "Failed solving the board.";
            else
            {
                result.Data = board.Cells.Select(x => x.GetValue()).ToArray();
            }
            return result;
        }

        private bool FillCells(LinkedList<Cell> unsolvedCells, SudokuBoard board)
        {
            Cell currentCell = unsolvedCells.First();
            unsolvedCells.RemoveFirst();

            List<int> possibleValues = GetPossibleCellValues(currentCell, board);

            foreach (int value in possibleValues)
            {
                currentCell.SetValue(value);
                if (!unsolvedCells.Any())
                    return true;
                if (FillCells(unsolvedCells, board))
                    return true;
            }

            currentCell.SetValue(0);
            unsolvedCells.AddFirst(currentCell);
            return false;
        }

        private List<int> GetPossibleCellValues(Cell cell, SudokuBoard board)
        {
            List<int> potentialValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> neighbourValues = GetCellNeighbourValues(cell, board);
            List<int> possibleValues = potentialValues.Except(neighbourValues).ToList();
            return possibleValues;
        }

        private List<int> GetCellNeighbourValues(Cell cell, SudokuBoard board)
        {
            return board.GetCellNeighbourValues(cell);
        }
    }
}