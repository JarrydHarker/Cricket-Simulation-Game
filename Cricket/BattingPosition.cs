using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    public class BattingPosition
    {
        public int PrefferedPosition;
        public BattingCategory Category;

        public BattingPosition(int Pos)
        {
            PrefferedPosition = Pos;

            if (PrefferedPosition < 3)
            {
                Category = new Opener();
            } else if (PrefferedPosition == 3)
            {
                Category = new TopOrder();
            } else if (PrefferedPosition > 3 && PrefferedPosition < 8)
            {
                Category = new MiddleOrder();
            } else
            {
                Category = new LowerOrder();
            }
        }
    }

    public class TopOrder : BattingCategory
    {
        public TopOrder()
        {
            Name = "Top-Order Batsman";
            PositionRange = new List<int> { 1, 2, 3 };
        }
    }

    public class MiddleOrder : BattingCategory
    {
        public MiddleOrder()
        {
            Name = "Middle-Order Batsman";
            PositionRange = new List<int> { 4, 5, 6, 7 };
        }
    }

    public class LowerOrder : BattingCategory
    {
        public LowerOrder()
        {
            Name = "Lower-Order Batsman";
            PositionRange = new List<int> { 8, 9, 10, 11 };
        }
    }

    public class Opener : BattingCategory
    {
        public Opener()
        {
            Name = "Opener";
            PositionRange = new List<int> { 1, 2 };
        }
    }

    public class BattingCategory
    {
        public List<int> PositionRange = new List<int>();
        public string Name;
    }
}
