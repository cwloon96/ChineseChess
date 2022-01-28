using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;

namespace ChineseChess.Entities.Pieces
{
    /// <summary>
    /// 帅
    /// </summary>
    public class GeneralPieces : BasePieces
    {
        public GeneralPieces(PiecesColorEnum color) : base(color)
        {
        }

        protected override bool CanMove(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            if (board.IsInPalace(to, Color))
            {
                return (from.IsSameRow(to) && from.GetColDistance(to) == 1)
                    || (from.IsSameCol(to) && from.GetRowDistance(to) == 1);
            }

            return false;
        }

        public override bool CanKill(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            var targetPieces = board.GetPiece(to);

            if (targetPieces is GeneralPieces)
                return board.GetNumOfPiecesBetweenRowOrCol(from, to) == 0;

            return base.CanKill(board, from, to);
        }
    }
}