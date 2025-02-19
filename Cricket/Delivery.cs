namespace Cricket
{
    public class Delivery
    {
        public Ball Ball { get; set; }
        public Result Result { get; set; }
        
        public Delivery(Ball ball, Result result) 
        {
            Ball = ball;
            Result = result;
        }
    }
}