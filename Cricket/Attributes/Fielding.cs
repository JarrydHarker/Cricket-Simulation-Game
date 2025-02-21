using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket.Attributes
{
    public static class Fielding
    {
        public static Catching Catching = new Catching(0);
        public static ThrowAccuracy ThrowAccuracy = new ThrowAccuracy(0);
        public static ArmStrength ArmStrength = new ArmStrength(0);
        public static GroundFielding GroundFielding = new GroundFielding(0);
        public static Reflexes Reflexes = new Reflexes(0);
        public static Diving Diving = new Diving(0);
        public static Wicketkeeping Wicketkeeping = new Wicketkeeping(0);
    }

    public class Catching : Attribute
    {
        public Catching(int Value)
        {
            Name = "Catching";
            Description = "Ability to track, catch, and hold on to balls in the air";
            this.Value = Value;
        }
    }

    public class ThrowAccuracy : Attribute
    {
        public ThrowAccuracy(int Value)
        {
            Name = "Throw Accuracy";
            Description = "Ability to precisely hit the stumps from the field";
            this.Value = Value;
        }
    }

    public class ArmStrength : Attribute
    {
        public ArmStrength(int Value)
        {
            Name = "Arm Strength";
            Description = "Power behind throws from the deep";
            this.Value = Value;
        }
    }

    public class Reflexes : Attribute
    {
        public Reflexes(int Value)
        {
            Name = "Reflexes";
            Description = "Speed in reacting to edges or sharp shots. More important when fielding in close, in the slips, and wicketkeeping";
            this.Value = Value;
        }
    }

    public class GroundFielding : Attribute
    {
        public GroundFielding(int Value)
        {
            Name = "Ground Fielding";
            Description = "Ability to stop balls and save runs";
            this.Value = Value;
        }
    }

    public class Diving : Attribute
    {
        public Diving(int Value)
        {
            Name = "Diving";
            Description = "Skill in making diving stops or catches";
            this.Value = Value;
        }
    }

    public class Wicketkeeping : Attribute
    {
        public Wicketkeeping(int Value)
        {
            Name = "Wicketkeeping";
            Description = "Glove work, stumping speed, and catching behind the stumps";
            this.Value = Value;
        }
    }
}
