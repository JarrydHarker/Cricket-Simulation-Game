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
        public Score Score = new Score();
        public List<Result> PossibleResults;

        public Match(Format format, Team teamA, Team teamB)
        {
            Format = format;
            TeamA = teamA;
            TeamB = teamB;

            PossibleResults = new List<Result>
            {
                new Dot(format),
                new One(format),
                new Two(format),
                new Three(format),
                new Four(format),
                new Six(format),
                new Wicket(format),
                new Wide(format),
                new NoBall(format),
                new LegBye(format),
                new Bye(format)
            };
        }

        public string SimulateInnings()
        {
            string output = "";
            int currentOver = 1;

            while (Score.Wickets < 10 && Score.Overs.Count < Format.Overs)
            {
                this.Score.AddOver(SimulateOver(currentOver, Score.Wickets));

                output += $"{currentOver}. " + Score.Overs[currentOver - 1].ToString() + "\n";

                currentOver++;
            }

            int extraballs = Score.GetNumDeliveries() % 6;
            
            if (extraballs > 0) 
            {
                output += $"\n {Score.Runs}/{Score.Wickets} in {Convert.ToInt32(Math.Floor((double)Score.GetNumDeliveries() / 6))}.{extraballs} overs";
            }else
            {
                output += $"\n {Score.Runs}/{Score.Wickets} in {Convert.ToInt32(Math.Floor((double)Score.GetNumDeliveries() / 6))} overs";
            }

            return output;
        }

        public Over SimulateOver(int overNumber, int TotalWickets)
        {
            Over over = new Over(overNumber, new Player(), PossibleResults, TotalWickets);
            over.Simulate();

            return over;
        }
    }
}
