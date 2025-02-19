using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Cricket
{
    public abstract class Result
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Probability { get; set; }
        public string Symbol { get; set; }
    }

    public class Dot : Result
    {
        public Dot(Format format)
        {
            Name = "Dot ball";
            Symbol = ".";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.35f;
                    break;
                case "ODI":
                    Probability = 0.5f;
                    break;
                case "Test":
                    Probability = 0.6f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }
    }

    public class One : Result
    {
        public One(Format format)
        {
            Name = "1 Run";
            Symbol = "1";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.22f;
                    break;
                case "ODI":
                    Probability = 0.2f;
                    break;
                case "Test":
                    Probability = 0.15f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }
    }

    public class Two : Result
    {
        public Two(Format format)
        {
            Name = "2 Runs";
            Symbol = "2";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.08f;
                    break;
                case "ODI":
                    Probability = 0.07f;
                    break;
                case "Test":
                    Probability = 0.05f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }
    }

    public class Three : Result
    {
        public Three(Format format)
        {
            Name = "3 Runs";
            Symbol = "3";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.01f;
                    break;
                case "ODI":
                    Probability = 0.01f;
                    break;
                case "Test":
                    Probability = 0.01f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }
    }

    public class Four : Result
    {
        public Four(Format format)
        {
            Name = "4 Runs";
            Symbol = "4";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.12f;
                    break;
                case "ODI":
                    Probability = 0.07f;
                    break;
                case "Test":
                    Probability = 0.06f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }
    }

    public class Six : Result
    {
        public Six(Format format)
        {
            Name = "6 Runs";
            Symbol = "6";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.1f;
                    break;
                case "ODI":
                    Probability = 0.02f;
                    break;
                case "Test":
                    Probability = 0.01f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }
    }

    public class Wicket : Result
    {
        public Wicket(Format format)
        {
            Name = "Wicket";
            Symbol = "W";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.07f;
                    break;
                case "ODI":
                    Probability = 0.025f;
                    break;
                case "Test":
                    Probability = 0.015f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }
    }

    public class Wide : Result
    {
        public Wide(Format format)
        {
            Name = "Wide";
            Symbol = "Wd";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.02f;
                    break;
                case "ODI":
                    Probability = 0.015f;
                    break;
                case "Test":
                    Probability = 0.01f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }
    }

    public class NoBall : Result
    {
        public NoBall(Format format)
        {
            Name = "No Ball";
            Symbol = "NB";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.015f;
                    break;
                case "ODI":
                    Probability = 0.01f;
                    break;
                case "Test":
                    Probability = 0.01f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }

        public void Update(int Runs)
        {
            Symbol = "NB" + Runs;
        }
    }

    public class LegBye : Result
    {
        public LegBye(Format format)
        {
            Name = "Leg Bye";
            Symbol = "Lb";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.01f;
                    break;
                case "ODI":
                    Probability = 0.015f;
                    break;
                case "Test":
                    Probability = 0.015f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }

        public void Update(int Runs)
        {
            Symbol = "Lb" + Runs;
        }
    }

    public class Bye : Result
    {
        public Bye(Format format)
        {
            Name = "Bye";
            Symbol = "B";

            switch (format.Name)
            {
                case "T20":
                    Probability = 0.005f;
                    break;
                case "ODI":
                    Probability = 0.005f;
                    break;
                case "Test":
                    Probability = 0.005f;
                    break;
                default:
                    break;
            }

            Description = ""; //Need to add descriptions later
        }

        public void Update(int Runs)
        {
            Symbol = "B" + Runs;
        }
    }
}
