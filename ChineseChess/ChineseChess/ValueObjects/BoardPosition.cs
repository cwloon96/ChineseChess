using System;

namespace ChineseChess.ValueObjects
{
    public class BoardPosition
    {
        public int Row { get; private set; }

        public int Col { get; private set; }

        public BoardPosition(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool IsSameRow(BoardPosition target) => Row == target.Row;

        public bool IsSameCol(BoardPosition target) => Col == target.Col;

        public bool IsDiagonal(BoardPosition target) => Math.Abs(target.Row - Row) == Math.Abs(target.Col - Col);

        public int GetRowDistance(BoardPosition target)
        {
            if (!IsSameCol(target))
                throw new Exception("Not at same col");

            return Math.Abs(target.Row - Row);
        }

        public int GetColDistance(BoardPosition target)
        {
            if (!IsSameRow(target))
                throw new Exception("Not at same row");

            return Math.Abs(target.Col - Col);
        }

        public int GetDiagonalDistance(BoardPosition target)
        {
            if (!IsDiagonal(target))
                throw new Exception("Not diaganol");

            return Math.Abs(target.Row - Row);
        }
    }
}