using ChineseChess.Entities.Board;
using ChineseChess.Entities.Pieces;
using ChineseChess.ValueObjects;
using NUnit.Framework;

namespace ChineseChess.Test.Entities.ChessBoard
{
    public class ChineseChessBoardTest
    {
        [Test]
        public void ShouldInitializeAllPiecesAtRightPosition()
        {
            var board = new ChineseChessBoard();

            Assert.True(board.GetPiece(new BoardPosition(0, 0)) is ChariotPieces);
            Assert.True(board.GetPiece(new BoardPosition(0, 1)) is HorsePieces);
            Assert.True(board.GetPiece(new BoardPosition(0, 2)) is ElephantPieces);
            Assert.True(board.GetPiece(new BoardPosition(0, 3)) is AdvisorPieces);
            Assert.True(board.GetPiece(new BoardPosition(0, 4)) is GeneralPieces);
            Assert.True(board.GetPiece(new BoardPosition(0, 5)) is AdvisorPieces);
            Assert.True(board.GetPiece(new BoardPosition(0, 6)) is ElephantPieces);
            Assert.True(board.GetPiece(new BoardPosition(0, 7)) is HorsePieces);
            Assert.True(board.GetPiece(new BoardPosition(0, 8)) is ChariotPieces);

            Assert.True(board.GetPiece(new BoardPosition(9, 0)) is ChariotPieces);
            Assert.True(board.GetPiece(new BoardPosition(9, 1)) is HorsePieces);
            Assert.True(board.GetPiece(new BoardPosition(9, 2)) is ElephantPieces);
            Assert.True(board.GetPiece(new BoardPosition(9, 3)) is AdvisorPieces);
            Assert.True(board.GetPiece(new BoardPosition(9, 4)) is GeneralPieces);
            Assert.True(board.GetPiece(new BoardPosition(9, 5)) is AdvisorPieces);
            Assert.True(board.GetPiece(new BoardPosition(9, 6)) is ElephantPieces);
            Assert.True(board.GetPiece(new BoardPosition(9, 7)) is HorsePieces);
            Assert.True(board.GetPiece(new BoardPosition(9, 8)) is ChariotPieces);

            Assert.True(board.GetPiece(new BoardPosition(2, 1)) is CannonPieces);
            Assert.True(board.GetPiece(new BoardPosition(2, 7)) is CannonPieces);

            Assert.True(board.GetPiece(new BoardPosition(7, 1)) is CannonPieces);
            Assert.True(board.GetPiece(new BoardPosition(7, 7)) is CannonPieces);

            Assert.True(board.GetPiece(new BoardPosition(3, 0)) is SoldierPieces);
            Assert.True(board.GetPiece(new BoardPosition(3, 2)) is SoldierPieces);
            Assert.True(board.GetPiece(new BoardPosition(3, 4)) is SoldierPieces);
            Assert.True(board.GetPiece(new BoardPosition(3, 6)) is SoldierPieces);
            Assert.True(board.GetPiece(new BoardPosition(3, 8)) is SoldierPieces);

            Assert.True(board.GetPiece(new BoardPosition(6, 0)) is SoldierPieces);
            Assert.True(board.GetPiece(new BoardPosition(6, 2)) is SoldierPieces);
            Assert.True(board.GetPiece(new BoardPosition(6, 4)) is SoldierPieces);
            Assert.True(board.GetPiece(new BoardPosition(6, 6)) is SoldierPieces);
            Assert.True(board.GetPiece(new BoardPosition(6, 8)) is SoldierPieces);
        }
    }
}