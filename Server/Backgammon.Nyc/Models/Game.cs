using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Backgammon.Nyc.Models
{
    public class Game
    {
        // Code used to access the game state
        public string Code { get; private set; }

        public DateTime Created { get; private set; }

        public DateTime? LastMove { get; private set; }

        public List<Die> ActiveDice { get; private set; }

        // Whose turn is it
        public Player ActivePlayer { get; private set; }

        // Game state (24 points)
        public List<Point> Points { get; private set; }

        // Bar state
        public List<Point> Bar { get; private set; }
        public List<Point> BearOff { get; private set; }
                
        public GameState State { get; private set; }

        // Generates a random 6 character game code
        private string GenerateCode()
        {
            var dictionary = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var codeBuilder = new StringBuilder();
            var r = new Random();
            var dictLength = dictionary.Length;

            for (int i = 0; i < 6; i++)
            {
                codeBuilder.Append(dictionary[r.Next(0, dictLength)]);
            }

            return codeBuilder.ToString();
        }

        public Game()
        {
            // Creation time
            Created = DateTime.Now;

            // Unique game code
            Code = GenerateCode();

            // Create the board
            Points = new List<Point>(24);

            // Setup the checkers
            SetPoint(1, Player.White, 2);
            SetPoint(6, Player.Black, 5);
            SetPoint(8, Player.Black, 3);
            SetPoint(12, Player.White, 5);
            SetPoint(13, Player.Black, 5);
            SetPoint(17, Player.White, 3);
            SetPoint(19, Player.White, 5);
            SetPoint(24, Player.Black, 2);

            // Initialize empty points
            for (int p = 1; p <= 24; p++)
            {
                if (GetPoint(p) == null)
                {
                    SetPoint(p, Player.None, 0);
                }
            }

            // Start with initial roll
            State = GameState.InitialRoll;

            Bar = new List<Point>();
            Bar.Add(new Point(Player.White, 0));
            Bar.Add(new Point(Player.Black, 0));

            BearOff = new List<Point>();
            BearOff.Add(new Point(Player.White, 0));
            BearOff.Add(new Point(Player.Black, 0));

            // Create container for dice
            ActiveDice = new List<Die>();
        }

        private Point GetPoint(int position)
        {
            return Points[position - 1];
        }

        private void SetPoint(int position, Player player, int numCheckers)
        {
            Points[position - 1] = new Point(player, numCheckers);
        }

        private bool IsValidPosition(int position)
        {
            if (position < 1 || position > 24)
                return false;
            else
                return true;
        }

        public void Move(Player player, int startPoint, int endPoint)
        {
            // First validate the move is legal

            // Only the active player can move
            if (player != ActivePlayer)
            {
                throw new MoveException($"Not {player}'s turn");
            }
            
            // Cannot move from the same point to the same point
            if (startPoint == endPoint)
            {
                throw new MoveException("Start and end point are the same");
            }

            if (!IsValidPosition(startPoint))
            {
                throw new MoveException("Invalid starting point");
            }
            if (!IsValidPosition(endPoint))
            {
                throw new MoveException("Invalid end point");
            }

            // Move must be one of the dice rolls
            var distance = Math.Abs(endPoint - startPoint);
        }
    }
}