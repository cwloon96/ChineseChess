namespace ChineseChess.Responses
{
    public class OngoingGameResponse
    {
        public string CurrentTurn { get; set; }

        public bool IsCheck { get; set; }

        public bool CanMove { get; set; }

        public bool IsEnd { get; set; }
    }
}