using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;
using System;

namespace ChineseChess.Entities.Pieces
{
    /// <summary>
    /// 马
    /// </summary>
    public class HorsePieces : BasePieces
    {
        public HorsePieces(PiecesColorEnum color) : base(color)
        {
        }

        protected override bool CanMove(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            var rowDistance = Math.Abs(from.Row - to.Row);
            var colDistance = Math.Abs(from.Col - to.Col);

            if (rowDistance == 2 && colDistance == 1)
            {
                return board.GetPiece(new BoardPosition((from.Row + to.Row) / 2, from.Col)) == null;
            }
            else if (colDistance == 2 && rowDistance == 1)
            {
                return board.GetPiece(new BoardPosition(from.Row, (from.Col + to.Col) / 2)) == null;
            }

            return false;
        }
    }
}