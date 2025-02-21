﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    public class Score
    {
        public int Runs;
        public int Wickets;
        public int Extras;
        public List<Over> Overs = new List<Over>();

        public Score()
        {

        }

        public void AddOver(Over over)
        {
            Overs.Add(over);

            Runs += over.Runs;
            Wickets += over.Wickets;
            Extras += over.Extras;
        }

        public int GetNumDeliveries()
        {
            return ((Overs.Count - 1) * 6) + Overs[Overs.Count -1].DeliveryResults.Count;
        }
    }
}
