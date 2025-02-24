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
        public Player OnStrikeBatsman { get; set; }
        public Tuple<Player, Player> CurrentBatsmen { get; set; }
        public int Length = 6;
        public int Runs;
        public int Wickets;
        public int Extras;
        public List<Result> DeliveryResults = new List<Result>();
        List<Result> PossibleResults = new List<Result>();
        List<Result> ExtraResults;
        int TotalWickets;

        public Over(int number, Player bowler, Tuple<Player, Player> batsmen,List<Result> possibleResults, int TotalWickets)
        {
            Number = number;
            Bowler = bowler;
            CurrentBatsmen = batsmen;
            OnStrikeBatsman = CurrentBatsmen.Item1;

            PossibleResults = possibleResults;
            ExtraResults = possibleResults.Where(x => int.TryParse(x.Symbol, out int num) == true).ToList();
            this.TotalWickets = TotalWickets;
        }

        public void Simulate()
        {
            int ballCount = 1;

            while (ballCount <= Length && Wickets + TotalWickets < 10)
            {
                Delivery delivery = new Delivery(OnStrikeBatsman, Bowler, new GameState(SelectFormat.Formats[0], new Score(), this));

                Result result = delivery.Simulate();
                DeliveryResults.Add(result);

                switch (result.Symbol)
                {
                    case "1":
                        Runs++;
                        OnStrikeBatsman = OnStrikeBatsman == CurrentBatsmen.Item1 ? OnStrikeBatsman = CurrentBatsmen.Item2 : CurrentBatsmen.Item1;
                        break;
                    case "2":
                        Runs += 2;
                        break;
                    case "3":
                        Runs += 3;
                        OnStrikeBatsman = OnStrikeBatsman == CurrentBatsmen.Item1 ? OnStrikeBatsman = CurrentBatsmen.Item2 : CurrentBatsmen.Item1;
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
                        Result noBallResult = delivery.GetResult(ExtraResults,0);//Need to Change
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

                        if (nbRuns % 2 == 1)
                        {
                            OnStrikeBatsman = OnStrikeBatsman == CurrentBatsmen.Item1 ? OnStrikeBatsman = CurrentBatsmen.Item2 : CurrentBatsmen.Item1;
                        }

                        break;
                    case "Lb":
                        Result legByeResult = delivery.GetResult(ExtraResults, 0);//Need to Change
                        int lbRuns = int.Parse(legByeResult.Symbol);

                        if (result is LegBye)
                        {
                            LegBye legBye = result as LegBye;

                            legBye.Update(lbRuns);
                            result = legBye;
                        }

                        Runs += lbRuns;
                        Extras += lbRuns;

                        if (lbRuns % 2 == 1)
                        {
                            OnStrikeBatsman = OnStrikeBatsman == CurrentBatsmen.Item1 ? OnStrikeBatsman = CurrentBatsmen.Item2 : CurrentBatsmen.Item1;
                        }
                        break;
                    case "B":
                        Result byeResult = delivery.GetResult(ExtraResults, 0);//Need to Change
                        int bRuns = int.Parse(byeResult.Symbol);

                        if (result is LegBye)
                        {
                            LegBye bye = result as LegBye;

                            bye.Update(bRuns);
                            result = bye;
                        }

                        Runs += bRuns;
                        Extras += bRuns;

                        if (bRuns % 2 == 1)
                        {
                            OnStrikeBatsman = OnStrikeBatsman == CurrentBatsmen.Item1 ? OnStrikeBatsman = CurrentBatsmen.Item2 : CurrentBatsmen.Item1;
                        }
                        break;
                    default:
                        break;
                }

                ballCount++;
            }
        }

        public override string ToString()
        {
            string output = "| ";

            for (int i = 0; i < DeliveryResults.Count; i++)
            {
                output += DeliveryResults[i].Symbol + " ";
            }

            output += "|";

            return output;

        }
    }
}
