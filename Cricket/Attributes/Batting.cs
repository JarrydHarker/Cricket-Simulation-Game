using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket.Attributes
{
    public static class Batting
    {
        public static Technique Technique = new Technique(0);
        public static ShotPower ShotPower = new ShotPower(0);
        public static Timing Timing = new Timing(0);
        public static Footwork Footwork = new Footwork(0);
        public static OffSide OffSide = new OffSide(0);
        public static LegSide LegSide = new LegSide(0);
        public static Defense Defense = new Defense(0);
        public static AgainstSpin AgainstSpin = new AgainstSpin(0);
        public static AgainstPace AgainstPace = new AgainstPace(0);
        public static FrontFoot FrontFoot = new FrontFoot(0);
        public static BackFoot BackFoot = new BackFoot(0);
    }

    public class BackFoot : Attribute
    {
        public BackFoot(int Value)
        {
            Name = "Back Foot";
            Description = "Ability to play shorter deliveries on the back foot";
            this.Value = Value;
        }
    }

    public class FrontFoot : Attribute
    {
        public FrontFoot(int Value)
        {
            Name = "Front Foot";
            Description = "Ability to play fuller deliveries on the front foot";
            this.Value = Value;
        }
    }

    public class Technique : Attribute
    {
        public Technique(int Value)
        {
            Name = "Technique";
            Description = "Overall batting skill and fundamentals";
            this.Value = Value;
        }
    }

    public class ShotPower : Attribute
    {
        public ShotPower(int Value)
        {
            Name = "Shot Power";
            Description = "Ability to strength behind shots for boundaries";
            this.Value = Value;
        }
    }

    public class Timing : Attribute
    {
        public Timing(int Value)
        {
            Name = "Timing";
            Description = "Ability to middle the ball, reducing nicks and edges";
            this.Value = Value;
        }
    }

    public class Footwork : Attribute
    {
        public Footwork(int Value)
        {
            Name = "Footwork";
            Description = "Ability to move around the crease, reducing LBWs";
            this.Value = Value;
        }
    }

    public class OffSide : Attribute
    {
        public OffSide(int Value)
        {
            Name = "Off-Side";
            Description = "Ability and tendency to play through the off-side";
            this.Value = Value;
        }
    }

    public class LegSide : Attribute
    {
        public LegSide(int Value)
        {
            Name = "Leg-Side";
            Description = "Ability and tendency to play on the leg-side";
            this.Value = Value;
        }
    }

    public class Defense : Attribute
    {
        public Defense(int Value)
        {
            Name = "Defense";
            Description = "Ability to defend";
            this.Value = Value;
        }
    }

    public class AgainstSpin : Attribute
    {
        public AgainstSpin(int Value)
        {
            Name = "AgainstSpin";
            Description = "Ability to play against spin bowlers";
            this.Value = Value;
        }
    }

    public class AgainstPace : Attribute
    {
        public AgainstPace(int Value)
        {
            Name = "AgainstPace";
            Description = "Ability to play against pace bowlers";
            this.Value = Value;
        }
    }
}
