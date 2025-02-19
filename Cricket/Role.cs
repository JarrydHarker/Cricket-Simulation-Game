using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    public static class PlayerRoles
    {
        public static Role[] Roles = { new Batter(), new WicketKeeper(), new AllRounder(), new Bowler() };
    }

    public class Batter : Role
    {
        public Batter()
        {
            Id = 0;
            Name = "Batter";
            Description = "";
        }
    }

    public class Bowler : Role
    {
        public Bowler()
        {
            Id = 3;
            Name = "Bowler";
            Description = "";
        }
    }

    public class AllRounder : Role
    {
        public AllRounder()
        {
            Id = 2;
            Name = "All Rounder";
            Description = "";
        }
    }

    public class WicketKeeper : Role
    {
        public WicketKeeper()
        {
            Id = 1;
            Name = "Wicket Keeper";
            Description = "";
        }
    }

    public abstract class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
