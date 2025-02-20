namespace Cricket
{
    public class GameState
    {
        public Format Format { get; set; }
        public Score Score { get; set; }
        public Over Over { get; set; }

        public GameState(Format format, Score currentScore, Over currentOver) 
        {
            Format = format;
            Score = currentScore;
            Over = currentOver;
        }
    }
}