using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket
{
    public static class SelectFormat
    {
        public static List<Format> Formats = new List<Format> { new T20(), new ODI(), new Test() };
    }

    public abstract class Format
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Overs { get; set; }
    }

    public class ODI : Format
    {
        public ODI()
        {
            Name = "ODI";
            Description = "One Day International";
            Overs = 50;
        }
    }

    public class T20 : Format
    {
        public T20()
        {
            Name = "T20";
            Description = "Twenty-Twenty Match";
            Overs = 20;
        }
    }

    public class Test : Format
    {
        public Test()
        {
            Name = "Test";
            Description = "Test Match";
            Overs = 90;
        }
    }
}
