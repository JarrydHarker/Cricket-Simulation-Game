﻿using System;
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
                output += $"\n {Score.Runs}/{Score.Wickets} in {Convert.ToInt32(Math.Floor((double)Score.GetNumDeliveries() / 6))}.{extraballs} overs\n Run Rate: {Score.CalcRunRate()}";
            } else
            {
                output += $"\n {Score.Runs}/{Score.Wickets} in {Convert.ToInt32(Math.Floor((double)Score.GetNumDeliveries() / 6))} overs\n Run Rate: {Score.CalcRunRate()}";
            }

            return output;
        }

        public Over SimulateOver(int overNumber, int TotalWickets)
        {
            Tuple<Player, Player> batsmen = new Tuple<Player, Player>(
                TeamB.players.FirstOrDefault(x => x.Role.Name == "Batter"),
                TeamB.players.Skip(1).FirstOrDefault(x => x.Role.Name == "Batter")
            );

            Over over = new Over(overNumber, TeamA.players.Where(x => x.Role.Name == "Bowler").FirstOrDefault(), batsmen, PossibleResults, TotalWickets);
            over.Simulate();

            return over;
        }
    }
}
