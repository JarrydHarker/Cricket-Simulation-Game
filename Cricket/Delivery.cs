using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace Cricket
{
    public class Delivery
    {
        public Player Batsman { get; set; }
        public Player Bowler { get; set; }
        public Ball Ball;
        public GameState gameState { get; set; }
        List<Result> PossibleResults;
        List<Result> ExtraResults;
        public Result Result { get; set; }
        private Random random = new Random();
        private float bowlingScore = 0;
        private float battingScore = 0;

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
            Ball ball = BowlDelivery(Bowler);
            CalcBowlingScore(ball, Bowler);
            float skillDiff = battingScore - bowlingScore;
            
            Result result = GetResult(PossibleResults, skillDiff);

            return result;
        }

        public Ball BowlDelivery(Player bowler)
        {
            int line = DetermineBowlingLine(bowler);
            int length = DetermineBowlingLength(bowler);

            return new Ball(line, length);
        }

        private int DetermineBowlingLength(Player bowler)
        {
            int output = 0;
            float length = (float)random.NextDouble() / 2;
            int control = bowler.Attributes["Control"].Value;

            // Attribute adjustment factor based on control (normalized)
            float adjustment = CalcAttributeAdjustment(control);

            // Move toward the 0.2-0.4 range if outside it, otherwise move away
            if (length < 0.2)
            {
                length += adjustment; // Push up toward 0.2
            } else if (length > 0.4)
            {
                length -= adjustment; // Push down toward 0.4
            }

            output = (int)Math.Round(Math.Clamp(length, 0f, 0.5f) * 10);

            return output;
        }

        public int DetermineBowlingLine(Player bowler)
        {
            int output = 0;
            float line = (float)(random.NextDouble() - 0.5f);
            int control = bowler.Attributes["Control"].Value;

            output = line < 0 ? (int)Math.Round((line + CalcAttributeAdjustment(control)) * 10) : (int)Math.Round((line - CalcAttributeAdjustment(control)) * 10);

            return output;
        }

        public void CalcBowlingScore(Ball ball, Player bowler)
        {
            List<Attributes.Attribute> attributes = new List<Attributes.Attribute>();
            float bowlingScore = 0;

            if (ball.Length < 1)
            {
                attributes.Add(bowler.Attributes["Bouncer"]);
            } else if (ball.Length > 4)
            {
                attributes.Add(bowler.Attributes["Yorker"]);
            }

            int deliveryType = random.Next(0, 4);

            switch (deliveryType)
            {
                case 1:
                    attributes.Add(bowler.Attributes["Slower Ball"]);
                    break;
                case 2:
                    attributes.Add(bowler.Attributes["Swing"]);
                    break;
                case 3:
                    attributes.Add(bowler.Attributes["Seam"]);
                    break;
                default:
                    attributes.Add(bowler.Attributes["Stock Ball"]);
                    break;
            }

            foreach (Attributes.Attribute attribute in attributes)
            {
                bowlingScore += CalcAttributeAdjustment(attribute.Value);
            }

            this.bowlingScore = bowlingScore;
        }

        public void CalcBattingScore(Ball ball, Player batter)
        {

        }

        public void FaceDelivery(Player Batsman, Ball Ball)
        {

        }

        private float CalcAttributeAdjustment(int attributeVal)
        {
            return (float)(((float)(attributeVal - 10) / 20) * 0.16); //Linear Scaling for now
        }

        public Result GetResult(List<Result> results, List<int> attributeVals)
        {
            float roll = (float)random.NextDouble(); // Random value between 0 and 1
            float cumulativeProbability = 0f;

            float adjustedRoll = roll;

            foreach (int attribute in attributeVals)
            {
                adjustedRoll += CalcAttributeAdjustment(attribute);
            }

            if (adjustedRoll < 0)
                adjustedRoll = 0;

            results = results.OrderBy(x => x.Score).ToList();

            foreach (var result in results)
            {
                cumulativeProbability += result.Probability;
                if (adjustedRoll <= cumulativeProbability)
                {
                    return result;
                }
            }

            return results[^1]; // Fallback in case of floating point precision errors
        }

        public Result GetResult(List<Result> results, float skillDifferential)
        {
            float roll = (float)random.NextDouble(); // Random value between 0 and 1
            float cumulativeProbability = 0f;

            float adjustedRoll = roll;

            adjustedRoll += skillDifferential;

            if (adjustedRoll < 0)
                adjustedRoll = 0;

            results = results.OrderBy(x => x.Score).ToList();

            foreach (var result in results)
            {
                cumulativeProbability += result.Probability;
                if (adjustedRoll <= cumulativeProbability)
                {
                    return result;
                }
            }

            return results[^1]; // Fallback in case of floating point precision errors
        }
    }
}
