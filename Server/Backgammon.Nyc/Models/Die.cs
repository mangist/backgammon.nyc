using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backgammon.Nyc.Models
{
    public class Die
    {
        public int Value { get; private set; }
        public Die(int sides)
        {
            if (sides < 2)
                throw new ArgumentException("Invalid die, must have at least 2 sides");

            var random = new Random();
            Value = random.Next(1, sides);
        }

        public static Die SixSided
        {
            get { return new Die(6); }
        }
    }
}