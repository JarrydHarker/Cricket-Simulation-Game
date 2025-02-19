using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    public class Over
    {
        public int Number { get; set; }
        public Player Bowler { get; set; }
        public List<Delivery> Deliveries { get; set; }

        public Over()
        {

        }
    }
}
