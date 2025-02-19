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
        public int Length = 6;
        public int Runs;
        public int Wickets;
        public int Extras;
        public List<Delivery> Deliveries = new List<Delivery>();
        public List<Result> PossibleResults = new List<Result>();
        public List<Result> ExtraResults;
        int TotalWickets;

        public Over(int number, Player bowler, List<Result> possibleResults, int TotalWickets)
        {
            Number = number;
            Bowler = bowler;

            PossibleResults = possibleResults;
            ExtraResults = possibleResults.Where(x => int.TryParse(x.Symbol, out int num) == true).ToList();
            this.TotalWickets = TotalWickets;
        }

        public void Simulate()
        {
            int ballCount = 1;

            while (ballCount <= Length && Wickets + TotalWickets < 10)
            {
                Result result = GetResult(PossibleResults);

                switch (result.Symbol)
                {
                    case "1":
                        Runs++;
                        break;
                    case "2":
                        Runs += 2;
                        break;
                    case "3":
                        Runs += 3;
                        break;
                    case "4":
                        Runs += 4;
                        break;
                    case "6":
                        Runs += 6;
                        break;
                    case "W":
                        Wickets++;
                        break;
                    case "Wd":
                        Runs++;
                        Extras++;
                        Length++;
                        break;
                    case "NB":
                        Result noBallResult = GetResult(ExtraResults);
                        int nbRuns = int.Parse(noBallResult.Symbol);

                        if (result is NoBall)
                        {
                            NoBall noBall = result as NoBall;

                            noBall.Update(nbRuns);
                            result = noBall;
                        }

                        Runs += nbRuns + 1;
                        Extras++;
                        Length++;
                        break;
                    case "Lb":
                        Result legByeResult = GetResult(ExtraResults);
                        int lbRuns = int.Parse(legByeResult.Symbol);

                        if (result is LegBye)
                        {
                            LegBye legBye = result as LegBye;

                            legBye.Update(lbRuns);
                            result = legBye;
                        }

                        Runs += lbRuns;
                        Extras += lbRuns;
                        break;
                    case "B":
                        Result byeResult = GetResult(ExtraResults);
                        int bRuns = int.Parse(byeResult.Symbol);

                        if (result is LegBye)
                        {
                            LegBye bye = result as LegBye;

                            bye.Update(bRuns);
                            result = bye;
                        }

                        Runs += bRuns;
                        Extras += bRuns;
                        break;
                    default:
                        break;
                }

                Deliveries.Add(new Delivery(new Ball(), result));

                ballCount++;
            }
        }

        public override string ToString()
        {
            string output = "| ";

            for (int i = 0; i < Deliveries.Count; i++)
            {
                output += Deliveries[i].Result.Symbol + " ";
            }

            output += "|";

            return output;

        }

        Result GetResult(List<Result> results)
        {
            Random random = new Random();
            float roll = (float)random.NextDouble(); // Random value between 0 and 1
            float cumulativeProbability = 0f;

            foreach (var result in results)
            {
                cumulativeProbability += result.Probability;
                if (roll <= cumulativeProbability)
                {
                    return result;
                }
            }

            return results[^1]; // Fallback in case of floating point precision errors
        }
    }
}
