using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;

namespace ChineseChess.Entities.Pieces
{
    /// <summary>
    /// 车
    /// </summary>
    public class ChariotPieces : BasePieces
    {
        public ChariotPieces(PiecesColorEnum color) : base(color)
        {
        }

        protected override bool CanMove(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            return (from.IsSameCol(to) || from.IsSameRow(to)) &&
                board.GetNumOfPiecesBetweenRowOrCol(from, to) == 0;
        }
    }
}