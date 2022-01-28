using ChineseChess.Entities.Pieces;
using ChineseChess.Enums;
using ChineseChess.ValueObjects;
using System;

namespace ChineseChess.Entities.Board
{
    public class ChineseChessBoard
    {
        private const int ROW = 10;
        private const int COL = 9;

        private IPieces[][] _board;

        private PiecesColorEnum _currentColor;
        private BoardStatusEnum _status;
        private PiecesColorEnum? _winner;

        public ChineseChessBoard()
        {
            _board = new IPieces[ROW][];

            for (int i = 0; i < ROW; i++)
                _board[i] = new IPieces[COL];

            _currentColor = PiecesColorEnum.Red;
            _status = BoardStatusEnum.OnGoing;

            InitializeBoard();
        }

        private void InitializeBoard()
        {
            InitializeGeneralRow(PiecesColorEnum.Red);
            InitializeGeneralRow(PiecesColorEnum.Black);

            InitializeCannonRow(PiecesColorEnum.Red);
            InitializeCannonRow(PiecesColorEnum.Black);

            InitializeSoldierRow(PiecesColorEnum.Red);
            InitializeSoldierRow(PiecesColorEnum.Black);
        }

        private void InitializeGeneralRow(PiecesColorEnum color)
        {
            int row = color == PiecesColorEnum.Red ? 0 : ROW - 1;

            _board[row][0] = new ChariotPieces(color);
            _board[row][1] = new HorsePieces(color);
            _board[row][2] = new ElephantPieces(color);
            _board[row][3] = new AdvisorPieces(color);
            _board[row][4] = new GeneralPieces(color);
            _board[row][5] = new AdvisorPieces(color);
            _board[row][6] = new ElephantPieces(color);
            _board[row][7] = new HorsePieces(color);
            _board[row][8] = new ChariotPieces(color);
        }

        private void InitializeCannonRow(PiecesColorEnum color)
        {
            int row = color == PiecesColorEnum.Red ? 2 : 7;

            _board[row][1] = new CannonPieces(color);
            _board[row][7] = new CannonPieces(color);
        }

        private void InitializeSoldierRow(PiecesColorEnum color)
        {
            int row = color == PiecesColorEnum.Red ? 3 : 6;

            _board[row][0] = new SoldierPieces(color);
            _board[row][2] = new SoldierPieces(color);
            _board[row][4] = new SoldierPieces(color);
            _board[row][6] = new SoldierPieces(color);
            _board[row][8] = new SoldierPieces(color);
        }

        public bool Move(BoardPosition from, BoardPosition to)
        {
            if (_status == BoardStatusEnum.End)
                throw new Exception("Game ended");

            if (!IsValidPosition(from) || !IsValidPosition(to))
                throw new Exception("Invalid position");

            var chosenPieces = GetPiece(from);

            if (chosenPieces == null)
                throw new Exception("No pieces on the position");

            if (chosenPieces.Color != _currentColor)
                throw new Exception("Not your turn now");

            if (chosenPieces.Move(this, from, to))
            {
                var targetPieces = GetPiece(to);

                _board[from.Row][from.Col] = null;
                _board[to.Row][to.Col] = chosenPieces;

                if (targetPieces is GeneralPieces)
                    EndGame();
                else
                    ChangeTurn();

                return true;
            }

            return false;
        }

        public IPieces GetPiece(BoardPosition position)
        {
            if (IsValidPosition(position))
                return _board[position.Row][position.Col];

            throw new Exception("Invalid Position");
        }

        public PiecesColorEnum GetPositionColor(BoardPosition position)
        {
            return position.Row <= 4 ? PiecesColorEnum.Red : PiecesColorEnum.Black;
        }

        public bool IsEndGame() => _status == BoardStatusEnum.End;

        public PiecesColorEnum? GetWinner() => _winner;

        public bool CanCheckGeneral(PiecesColorEnum color)
        {
            var oppColor = color == PiecesColorEnum.Red ? PiecesColorEnum.Black : PiecesColorEnum.Red;

            var oppGeneralPosition = GetGeneralPosition(oppColor);

            if (oppGeneralPosition == null)
                return false;

            for (int row = 0; row < ROW; row++)
            {
                for (int col = 0; col < COL; col++)
                {
                    var position = new BoardPosition(row, col);
                    var piece = GetPiece(position);

                    if (piece != null && piece.Color == color && piece.CanKill(this, position, oppGeneralPosition))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public BoardPosition GetGeneralPosition(PiecesColorEnum color)
        {
            (int fromRow, int toRow) = GetPalaceRowRange(color);
            (int fromCol, int toCol) = GetPalaceColRange();

            for (int row = fromRow; row <= toRow; row++)
            {
                for (int col = fromCol; col <= toCol; col++)
                {
                    var pieces = GetPiece(new BoardPosition(row, col));

                    if (pieces != null && pieces is GeneralPieces)
                        return new BoardPosition(row, col);
                }
            }

            return null;
        }

        public bool IsAtSelfSide(IPieces pieces, BoardPosition position) => pieces.Color == GetPositionColor(position);

        public bool IsInPalace(BoardPosition position, PiecesColorEnum color)
        {
            (int fromRow, int toRow) = GetPalaceRowRange(color);
            (int fromCol, int toCol) = GetPalaceColRange();

            return position.Row >= fromRow && position.Row <= toRow &&
                    position.Col >= fromCol && position.Col <= toCol;
        }

        public int GetNumOfPiecesBetweenRowOrCol(BoardPosition from, BoardPosition to)
        {
            int nums = 0;

            if (from.IsSameCol(to))
            {
                if (from.GetRowDistance(to) < 2)
                    return 0;

                int fromRow = Math.Min(from.Row, to.Row) + 1;
                int toRow = Math.Max(from.Row, to.Row);

                for (int i = fromRow; i < toRow; i++)
                    nums += GetPiece(new BoardPosition(i, from.Col)) == null ? 0 : 1;
            }
            else if (from.IsSameRow(to))
            {
                if (from.GetColDistance(to) < 2)
                    return 0;

                int fromCol = Math.Min(from.Col, to.Col) + 1;
                int toCol = Math.Max(from.Col, to.Col);

                for (int i = fromCol; i < toCol; i++)
                    nums += GetPiece(new BoardPosition(from.Row, i)) == null ? 0 : 1;
            }
            else
                throw new Exception("The positions are not in the same rol / col");

            return nums;
        }

        public PiecesColorEnum GetCurrentColor() => _currentColor;

        private (int, int) GetPalaceRowRange(PiecesColorEnum color)
        {
            if (color == PiecesColorEnum.Red)
                return (0, 2);

            return (7, 9);
        }

        private (int, int) GetPalaceColRange() => (3, 5);

        private bool IsValidPosition(BoardPosition position)
        {
            return position.Row >= 0 && position.Row < ROW &&
                    position.Col >= 0 && position.Col < COL;
        }

        private void EndGame() 
        { 
            _status = BoardStatusEnum.End; 
            _winner = _currentColor; 
        }

        private void ChangeTurn()
        {
            if (_currentColor == PiecesColorEnum.Black)
                _currentColor = PiecesColorEnum.Red;
            else
                _currentColor = PiecesColorEnum.Black;
        }
    }
}