using System;

namespace SudokuService.Models
{
    public class Position : IEquatable<Position>
    {
        private int Row { get; set; }
        private int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int GetRow()
        {
            return Row;
        }

        public int GetColumn()
        {
            return Column;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        public bool Equals(Position other)
        {
            return other != null &&
                   Row == other.Row &&
                   Column == other.Column;
        }

        public override int GetHashCode()
        {
            var hashCode = 240067226;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }
    }
}