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
                Delivery delivery = new Delivery(OnStrikeBatsman, Bowler, new GameState(SelectFormat.Formats[0], new Score() , this));
                DeliveryResults.Add(delivery.Simulate());

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
