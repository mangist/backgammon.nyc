using Backgammon.Nyc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backgammon.Nyc.Managers
{
    public static class GameManager
    {
        private static List<Game> Games { get; set; }

        public static IReadOnlyCollection<Game> All
        {
            get { return Games.AsReadOnly(); }
        }

        // Initialize our current games
        static GameManager()
        {
            Games = new List<Game>();
        }
        
        public static Game Get(string code)
        {
            return Games.SingleOrDefault(g => g.Code == code);
        }

        public static void Save(Game game)
        {
            Games.Add(game);
        }

    }
}