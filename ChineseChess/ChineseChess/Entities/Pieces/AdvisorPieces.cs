using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;

namespace ChineseChess.Entities.Pieces
{
    /// <summary>
    /// 士
    /// </summary>
    public class AdvisorPieces : BasePieces
    {
        public AdvisorPieces(PiecesColorEnum color) : base(color)
        {
        }

        protected override bool CanMove(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            if (board.IsInPalace(to, Color))
            {
                return from.IsDiagonal(to) &&
                    from.GetDiagonalDistance(to) == 1;
            }

            return false;
        }
    }
}