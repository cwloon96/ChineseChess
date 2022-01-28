using ChineseChess.Entities.Board;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;

namespace ChineseChess.Entities.Pieces
{
    public interface IPieces
    {
        PiecesColorEnum Color { get; }

        bool Move(ChineseChessBoard board, BoardPosition from, BoardPosition to);

        bool CanKill(ChineseChessBoard board, BoardPosition from, BoardPosition to);
    }
}