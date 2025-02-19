using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket.Attributes
{
    public static class Mental
    {
        public static List<Attribute> Attributes = new List<Attribute>
        {
            new Composure(0),
            new Decisions(0),
            new Concentration(0),
            new Aggression(0),
            new Leadership(0),
            new WorkRate(0),
            new BigMatches(0),
        };

        public class Composure : Attribute
        {
            public Composure(int Value)
            {
                Name = "Composure";
                Description = "Ability to stay calm under pressure";
                this.Value = Value;
            }
        }

        public class Decisions : Attribute
        {
            public Decisions(int Value)
            {
                Name = "Decisions";
                Description = "Ability to make the right decision at the right time";
                this.Value = Value;
            }
        }

        public class Concentration : Attribute
        {
            public Concentration(int Value)
            {
                Name = "Concentration";
                Description = "Ability to focus over long innings or spells";
                this.Value = Value;
            }
        }

        public class Aggression : Attribute
        {
            public Aggression(int Value)
            {
                Name = "Aggression";
                Description = "How aggressive the mindset when batting/bowling/fielding";
                this.Value = Value;
            }
        }

        public class Leadership : Attribute
        {
            public Leadership(int Value)
            {
                Name = "Leadership";
                Description = "The ability to lead a team";
                this.Value = Value;
            }
        }

        public class WorkRate : Attribute
        {
            public WorkRate(int Value)
            {
                Name = "Work Rate";
                Description = "The effort level this player is able to produce and maintain";
                this.Value = Value;
            }
        }

        public class BigMatches : Attribute
        {
            public BigMatches(int Value)
            {
                Name = "Big Matches";
                Description = "Ability to perform in crucial moments";
                this.Value = Value;
            }
        }
    }
}
