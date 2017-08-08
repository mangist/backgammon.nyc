using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backgammon.Nyc.Models
{
    public class MoveException : ApplicationException
    {
        public MoveException(string message) : base(message)
        { }
    }
}