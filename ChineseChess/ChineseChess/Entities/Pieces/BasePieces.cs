using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;
using System;

namespace ChineseChess.Entities.Pieces
{
    public abstract class BasePieces : IPieces
    {
        public PiecesColorEnum Color { get; private set; }

        public BasePieces(PiecesColorEnum color)
        {
            Color = color;
        }

        public bool Move(ChineseChessBoard board, BoardPosition from, BoardPosition to)
        {
            var targetPieces = board.GetPiece(to);
            if (targetPieces != null)
            {
                if (targetPieces.Color == Color)
                    throw new Exception("You can't kill allias");

                return CanKill(board, from, to);
            }

            return CanMove(board, from, to);
        }

        protected abstract bool CanMove(ChineseChessBoard board, BoardPosition from, BoardPosition to);

        public virtual bool CanKill(ChineseChessBoard board, BoardPosition from, BoardPosition to) => CanMove(board, from, to);
    }
}