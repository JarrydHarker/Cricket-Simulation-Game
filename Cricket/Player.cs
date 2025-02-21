using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Cricket.Attributes;

namespace Cricket
{
    public class Player
    {
        public string Name { get; set; }
        public Role Role { get; set; }
        public BattingPosition BattingPos { get; set; }
        public Dictionary<string, Attributes.Attribute> Attributes = new Dictionary<string, Attributes.Attribute>();
        private static Random random = new Random();

        public Player()
        {
            Name = "Generated Player";

            int roleId = WeightedRandom(new int[] { 0, 1, 2, 3}, new double[] { 0.35, 0.1, 0.2, 0.35 });
            Role = PlayerRoles.Roles[roleId];

            BattingPos = AssignBattingPosition(roleId);
        }

        public Player(string Name, int roleId)
        {
            this.Name = Name;

            Role = PlayerRoles.Roles[roleId];

            BattingPos = AssignBattingPosition(roleId);
        }

        public Player(int roleId)
        {
            Name = "Generated Player";

            Role = PlayerRoles.Roles[roleId];

            PaceBowling bowling = new PaceBowling();

            Attributes.Add(bowling.Seam.Name, bowling.Seam);
            Attributes.Add(bowling.Yorker.Name, bowling.Yorker);
            Attributes.Add(bowling.Bouncer.Name, bowling.Bouncer);
            Attributes.Add(bowling.Swing.Name, bowling.Swing);
            Attributes.Add(bowling.Slow.Name, bowling.Slow);

            BattingPos = AssignBattingPosition(roleId);
        }

        public override string ToString()
        {
            return $"Name: {Name}\nRole: {Role.Name}\nBatting Category: {BattingPos.Category.Name}\nPreffered Position: {BattingPos.PrefferedPosition}";
        }

        private int WeightedRandom(int[] values, double[] probabilities)
        {
            double rand = random.NextDouble();
            double cumulative = 0.0;
            for (int i = 0; i < values.Length; i++)
            {
                cumulative += probabilities[i];
                if (rand < cumulative)
                {
                    return values[i];
                }
            }

            return values[values.Length - 1]; // Fallback (should never happen)
        }

        private BattingPosition AssignBattingPosition(int roleId)
        {
            switch (roleId)
            {
                case 0: // Batsman
                    return new BattingPosition(random.Next(1, 7));
                case 1: // Wicketkeeper Batsman (Usually 3-7)
                    return new BattingPosition(WeightedRandom(new int[] { 3, 4, 5, 6, 7 }, new double[] { 0.1, 0.15, 0.2, 0.2, 0.35 }));
                case 2: // All-Rounder (Usually 4-8)
                    return new BattingPosition(WeightedRandom(new int[] { 4, 5, 6, 7, 8 }, new double[] { 0.1, 0.15, 0.2, 0.3, 0.25 }));
                case 3: // Bowler (Usually 8-11)
                    return new BattingPosition(WeightedRandom(new int[] { 8, 9, 10, 11 }, new double[] { 0.15, 0.25, 0.3, 0.3 }));
                default:
                    return new BattingPosition(random.Next(1, 12)); // Fallback case
            }
        }
    }
}
