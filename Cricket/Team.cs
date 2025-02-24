using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> players = new List<Player>();

        public Team()
        {

        }

        public void GenerateTeam()
        {
            Random random = new Random();
            players.Clear();

            int numKeepers = 0;
            int numBatsmen = 0;
            int numBowlers = 0;
            int numAllRounders = 0;

            for (int i = 0; i < 11; i++)
            {
                int roleId;

                // Ensure at least 1 wicketkeeper and randomly allow a second one after the 5th player
                if (numKeepers < 1 || (numKeepers < 2 && i > 5 && random.Next(0, 6) == 0))
                {
                    roleId = 1; // Wicketkeeper
                    numKeepers++;
                }
                // Ensure at least 3 specialist bowlers before adding more all-rounders
                else if (numBowlers < 3 || (numAllRounders < 3 && random.Next(0, 3) == 0))
                {
                    if (numBowlers < 3 || random.Next(0, 4) == 0)
                    {
                        roleId = 3; // Bowler
                        numBowlers++;
                    } else
                    {
                        roleId = 2; // All-Rounder
                        numAllRounders++;
                    }
                } else
                {
                    roleId = 0; // Batter
                    numBatsmen++;
                }

                Player newPlayer = new Player(roleId);

                switch (roleId)
                {
                    case 0:
                        newPlayer.Attributes["Technique"].Value = 10;
                        newPlayer.Attributes["Timing"].Value = 10;
                        newPlayer.Attributes["Footwork"].Value = 10;
                        newPlayer.Attributes["Leg-Side"].Value = 10;
                        newPlayer.Attributes["Off-Side"].Value = 10;
                        newPlayer.Attributes["Front Foot"].Value = 10;
                        newPlayer.Attributes["Back Foot"].Value = 10;
                        break;
                    case 3:
                        //newPlayer.Attributes["Pace"].Value = 20;
                        newPlayer.Attributes["Bouncer"].Value = 10;
                        newPlayer.Attributes["Yorker"].Value = 10;
                        newPlayer.Attributes["Swing"].Value = 10;
                        newPlayer.Attributes["Seam"].Value = 10;
                        newPlayer.Attributes["Slower Ball"].Value = 10;
                        newPlayer.Attributes["Control"].Value = 10;
                        newPlayer.Attributes["Stock Ball"].Value = 10;
                        break;
                }

                AddPlayer(newPlayer);
            }

            SortPlayers();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
            SortPlayers();
        }

        public void SortPlayers()
        {
            players = players.OrderBy(x => x.BattingPos.PrefferedPosition).ToList();
        }

        public override string ToString()
        {
            string output = "";

            foreach (Player player in players)
            {
                output += $"{players.IndexOf(player) + 1}. {player.Name} ({player.Role.Name}) - {player.BattingPos.Category.Name}\n";
            }

            return output;
        }
    }
}
