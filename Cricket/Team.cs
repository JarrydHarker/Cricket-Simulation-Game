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

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
}
