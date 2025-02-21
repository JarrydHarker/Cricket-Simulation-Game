namespace Cricket
{
    public class Ball
    {
        public int Line { get; set; }
        public int Length { get; set; }


        public Ball(int Line, int Length) 
        {
            this.Line = Line;
            this.Length = Length;
        }
    }
}