using System;
using System.Runtime.CompilerServices;

namespace Cricket.Attributes
{
    public class PaceBowling : Bowling
    {
        public Yorker Yorker = new Yorker(0);
        public Bouncer Bouncer = new Bouncer(0);
        public Slow Slow = new Slow(0);
        public Swing Swing = new Swing(0);
        public Seam Seam = new Seam(0);
    }

    public class SpinBowling : Bowling 
    {
        public static Spin Spin = new Spin(0);
        public static Flight Flight = new Flight(0);
    }

    public class Bowling
    {
        public Control Control = new Control(0);
        public Speed Speed = new Speed(0);
        public Stock Stock = new Stock(0);
    }

    public class Control : Attribute
    {
        public Control(int Value)
        {
            Name = "Control";
            Description = "Ability to consistently hit the right areas";
            this.Value = Value;
        }
    }

    public class Speed : Attribute
    {
        public Speed(int Value)
        {
            Name = "Speed";
            Description = "The pace at which a bowler delivers the ball";
            this.Value = Value;
        }
    }

    public class Swing : Attribute
    {
        public Swing(int Value)
        {
            Name = "Swing";
            Description = "Skill in moving the ball in the air (outswing/inswing)";
            this.Value = Value;
        }
    }

    public class Stock : Attribute
    {
        public Stock(int Value)
        {
            Name = "Stock Ball";
            Description = "The ability to bowl a stock ball";
            this.Value = Value;
        }
    }

    public class Seam : Attribute
    {
        public Seam(int Value)
        {
            Name = "Seam";
            Description = "Skill in moving the ball off-the-pitch";
            this.Value = Value;
        }
    }

    public class Spin : Attribute
    {
        public Spin(int Value)
        {
            Name = "AgainstSpin";
            Description = "Ability to turn the ball sharply";
            this.Value = Value;
        }
    }

    public class Flight : Attribute
    {
        public Flight(int Value)
        {
            Name = "Flight";
            Description = "Skill in deceiving batters in the air";
            this.Value = Value;
        }
    }

    public class Yorker : Attribute
    {
        public Yorker(int Value)
        {
            Name = "Yorker";
            Description = "Ability to bowl fuller deliveries close to the batsman's toes";
            this.Value = Value;
        }
    }

    public class Bouncer : Attribute
    {
        public Bouncer(int Value)
        {
            Name = "Bouncer";
            Description = "Ability to bowl short deliveries past the batsmen's head";
            this.Value = Value;
        }
    }

    public class Slow : Attribute
    {
        public Slow(int Value)
        {
            Name = "Slower Ball";
            Description = "Ability to bowl a slower ball to decieve the batsman";
            this.Value = Value;
        }
    }
}


