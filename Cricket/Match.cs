using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    class Match
    {
        public Format Format { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public Score Score { get; set; }


        public Match() { }
    }
}
