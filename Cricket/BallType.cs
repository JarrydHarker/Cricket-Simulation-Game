namespace Cricket
{
    public class BallType
    {
        public Delivery Ball { get; set; }
        public Result Result { get; set; }
        
        public BallType(Delivery ball, Result result) 
        {
            Ball = ball;
            Result = result;
        }
    }
}