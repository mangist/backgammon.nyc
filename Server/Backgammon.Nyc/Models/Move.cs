using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backgammon.Nyc.Models
{
    public class Move
    {
        public Player Player { get; set; }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}