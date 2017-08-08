using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backgammon.Nyc.Models
{
    public class Point
    {
        public Player Owner { get; set; }
        public int Checkers { get; set; }

        public Point(Player owner, int numCheckers)
        {
            this.Owner = owner;
            this.Checkers = numCheckers;
        }
    }
}