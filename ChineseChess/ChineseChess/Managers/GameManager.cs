using ChineseChess.Entities.Board;
using ChineseChess.Responses;
using ChineseChess.ValueObjects;
using System;

namespace ChineseChess.Managers
{
    public class GameManager
    {
        public ChineseChessBoard _currentGame;

        public OngoingGameResponse InitGame()
        {
            _currentGame = new ChineseChessBoard();

            return new OngoingGameResponse
            {
                CanMove = false,
                IsCheck = false,
                CurrentTurn = _currentGame.GetCurrentColor().ToString(),
            };
        }

        public OngoingGameResponse Move(BoardPosition from, BoardPosition to)
        {
            try
            {
                var currentColor = _currentGame.GetCurrentColor();

                if (_currentGame.Move(from, to))
                {
                    return new OngoingGameResponse
                    {
                        CanMove = true,
                        IsCheck = _currentGame.CanCheckGeneral(currentColor),
                        CurrentTurn = _currentGame.GetCurrentColor().ToString(),
                        IsEnd = _currentGame.IsEndGame()
                    };
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return new OngoingGameResponse
            {
                CanMove = false,
                IsCheck = false,
                CurrentTurn = _currentGame.GetCurrentColor().ToString(),
                IsEnd = _currentGame.IsEndGame(),
            };
        }
    }
}