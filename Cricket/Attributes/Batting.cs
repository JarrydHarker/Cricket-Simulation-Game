using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket.Attributes
{
    public static class Batting
    {
        public static List<Attribute> Attributes = new List<Attribute>
        {
            new Technique(0),
            new ShotPower(0),
            new Timing(0),
            new Footwork(0),
            new OffSide(0),
            new LegSide(0),
            new Defense(0),
            new AgainstSpin(0),
            new AgainstPace(0)
        };
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
