using ChineseChess.ValueObjects;

namespace ChineseChess.Requests
{
    public class MoveRequest
    {
        public BoardPosition From { get; set; }

        public BoardPosition To { get; set; }
    }
}