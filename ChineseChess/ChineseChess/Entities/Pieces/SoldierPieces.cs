using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;

namespace ChineseChess.Entities.Pieces
{
    /// <summary>
    /// 兵
    /// </summary>
    public class SoldierPieces : BasePieces
    {
        public SoldierPieces(PiecesColorEnum color) : base(color)
        {
        }

        protected override bool CanMove(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            int steps = 0;

            if (from.IsSameCol(to))
                steps = from.GetRowDistance(to);
            else if (from.IsSameRow(to))
                steps = from.GetColDistance(to);

            if (steps != 1)
                return false;

            return (Color == PiecesColorEnum.Red && to.Row > from.Row) ||
                    (Color == PiecesColorEnum.Black && to.Row < from.Row) ||
                    !board.IsAtSelfSide(this, to); // move horizontally
        }
    }
}