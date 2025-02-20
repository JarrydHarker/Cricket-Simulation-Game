using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Cricket
{
    public class Delivery
    {
        public Player Batsman { get; set; }
        public Player Bowler { get; set; }
        public GameState gameState { get; set; }
        List<Result> PossibleResults;
        List<Result> ExtraResults;
        public Result Result { get; set; }

        public Delivery(Player Batsman, Player Bowler, GameState gameState) 
        {
            this.Batsman = Batsman;
            this.Bowler = Bowler;
            this.gameState = gameState;

            PossibleResults = new List<Result>
            {
                new Dot(gameState.Format),
                new One(gameState.Format),
                new Two(gameState.Format),
                new Three(gameState.Format),
                new Four(gameState.Format),
                new Six(gameState.Format),
                new Wicket(gameState.Format),
                new Wide(gameState.Format),
                new NoBall(gameState.Format),
                new LegBye(gameState.Format),
                new Bye(gameState.Format)
            };

            ExtraResults = PossibleResults.Where(x => int.TryParse(x.Symbol, out int num) == true).ToList();
        }

        public Result Simulate()
        {
            Result result = GetResult(PossibleResults);

            /*switch (result.Symbol)
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
            }*/

            return result;
        }

        public void BowlDelivery(Player Bowler)
        {

        }

        public void FaceDelivery(Player Batsman)
        {

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
