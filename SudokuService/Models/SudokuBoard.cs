using System.Collections.Generic;

namespace SudokuService.Models
{
    public class SudokuBoard
    {
        public Cell[] Cells { get; set; }

        public SudokuBoard()
        {
            Cells = new Cell[81];
            for (int i = 0; i < 81; i++)
            {
                Cells[i] = new Cell(i);
            }
        }

        public SudokuBoard(int[] numbers)
        {
            Cells = new Cell[81];
            for (int i = 0; i < 81; i++)
            {
                Cells[i] = new Cell(i, numbers[i]);
            }
        }

        public List<int> GetCellNeighbourValues(Cell cell)
        {
            List<int> neighbourPositons = GetCellNeighbourPositions(cell);
            List<int> values = new List<int>();
            foreach (int neighbour in neighbourPositons)
            {
                values.Add(Cells[neighbour].GetValue());
            }
            return values;
        }

        public static List<int> GetCellNeighbourPositions(Cell cell)
        {
            List<Position> neighbourPositons = cell.GetNeighbourPositions();
            List<int> positions = new List<int>();
            foreach (var neighbour in neighbourPositons)
            {
                int position = GetLinearPosition(neighbour);
                positions.Add(position);
            }
            return positions;
        }

        private static int GetLinearPosition(Position coordinates)
        {
            return coordinates.GetRow() * 9 + coordinates.GetColumn();
        }
    }
}