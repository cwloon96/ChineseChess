using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;

namespace ChineseChess.Entities.Pieces
{
    /// <summary>
    /// 象
    /// </summary>
    public class ElephantPieces : BasePieces
    {
        public ElephantPieces(PiecesColorEnum color) : base(color)
        {
        }

        protected override bool CanMove(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            int midRow = (from.Row + to.Row) / 2;
            int midCol = (from.Col + to.Col) / 2;

            return board.IsAtSelfSide(this, to) &&
                from.IsDiagonal(to) &&
                from.GetDiagonalDistance(to) == 2 &&
                board.GetPiece(new BoardPosition(midRow, midCol)) == null;
        }
    }
}