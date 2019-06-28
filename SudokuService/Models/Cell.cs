using System.Collections.Generic;
using System.Linq;

namespace SudokuService.Models
{
    public class Cell
    {
        private Position Position { get; set; }
        private int Value { get; set; }

        public Cell(int index)
        {
            Position = GetCoordinatePosition(index);
            Value = 0;
        }

        public Cell(int index, int value)
        {
            Position = GetCoordinatePosition(index);
            Value = value;
        }


        private Cell(Position position)
        {
            Position = position;
            Value = 0;
        }

        public int GetValue()
        {
            return Value;
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        private Position GetCoordinatePosition(int index)
        {
            int row = index / 9;
            int column = index % 9;
            Position position = new Position(row, column);
            return position;
        }

        public List<Position> GetNeighbourPositions()
        {
            List<Position> neighbourPositions = new List<Position>();
            neighbourPositions.AddRange(GetRowAndColumnNeighbourPositons());
            neighbourPositions.AddRange(GetBoxNeighbourPositions());
            neighbourPositions.RemoveAll(x => x.GetRow() == Position.GetRow() && x.GetColumn() == Position.GetColumn());
            return neighbourPositions.Distinct().ToList();
        }

        private List<Position> GetRowAndColumnNeighbourPositons()
        {
            List<Position> neighbourPositions = new List<Position>();
            for (int i = 0; i < 9; i++)
            {
                Position neighbourPositionInRow = new Position(Position.GetRow(), i);
                neighbourPositions.Add(neighbourPositionInRow);
                Position neighbourPositionInColumn = new Position(i, Position.GetColumn());
                neighbourPositions.Add(neighbourPositionInColumn);
            }
            return neighbourPositions;
        }

        private List<Position> GetBoxNeighbourPositions()
        {
            List<Position> neighbourPositions = new List<Position>();
            int firstRowInBoxIndex = GetFirstCellInBoxRowCoordinarte();
            int firstcolumnInBoxIndex = GetFirstCellInBoxColumnCoordinarte();

            for (int row = firstRowInBoxIndex; row < firstRowInBoxIndex + 3; row++)
            {
                for (int column = firstcolumnInBoxIndex; column < firstcolumnInBoxIndex + 3; column++)
                {
                    Position neighbourPositionInColumn = new Position(row, column);
                    neighbourPositions.Add(neighbourPositionInColumn);
                }
            }
            return neighbourPositions;
        }

        private int GetFirstCellInBoxRowCoordinarte()
        {
            int currentRow = Position.GetRow();
            return currentRow - currentRow % 3;
        }

        private int GetFirstCellInBoxColumnCoordinarte()
        {
            int currentColumn = Position.GetColumn();
            return currentColumn - currentColumn % 3;
        }
    }
}