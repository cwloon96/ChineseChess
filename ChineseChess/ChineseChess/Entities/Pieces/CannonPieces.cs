using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;

namespace ChineseChess.Entities.Pieces
{
    /// <summary>
    /// 炮
    /// </summary>
    public class CannonPieces : BasePieces
    {
        public CannonPieces(PiecesColorEnum color) : base(color)
        {
        }

        protected override bool CanMove(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            return (from.IsSameCol(to) || from.IsSameRow(to)) &&
                board.GetNumOfPiecesBetweenRowOrCol(from, to) == 0;
        }

        public override bool CanKill(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            return (from.IsSameCol(to) || from.IsSameRow(to)) &&
                board.GetNumOfPiecesBetweenRowOrCol(from, to) == 1;
        }
    }
}