using Backgammon.Nyc.Managers;
using Backgammon.Nyc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backgammon.Nyc.Controllers
{
    public class GamesController : ApiController
    {
        // GET: api/Games
        public IEnumerable<Game> Get()
        {
            return GameManager.All;
        }

        private Game GetGame(string code)
        {
            return GameManager.Get(code);
        }

        // GET: api/Games/ABCDEF
        public HttpResponseMessage Get(string code)
        {
            var game = GetGame(code);
            if (game == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Game not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, game);
            }
        }

        // GET: api/Games/{code}/RollDice
        public HttpResponseMessage RollDice(string code)
        {
            var game = GetGame(code);
            if (game == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Game not found");
            }
            else
            {
                // Check if we are in a state to roll more dice
                if (game.ActiveDice.Count == 0)
                {
                    // OK no more dice, we can roll
                }
            }
        }

        // POST: api/Games/ABCDEF
        public HttpResponseMessage Move(string code, [FromBody]Move move)
        {
            // First lookup the game
            var game = GetGame(code);
            if (game == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Game not found");
            }
            else
            {

            }
        }

        // PUT: api/Game/
        public void Put()
        {
        }

        // DELETE: api/Game/ABCDEF
        public HttpResponseMessage Delete(string code)
        {
            var game = GameManager.Games.SingleOrDefault(g => g.Code == code);
            if (game == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Game not found");
            }
            else
            {
                // Delete the game 
                GameManager.Games.Remove(game);

                // Return OK response
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
