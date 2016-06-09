using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blackjack.API.Models;
using Blackjack.Play.Dealer_Strategy;
using Blackjack.Play.Entities;
using Blackjack.Play.Player_Strategy;

namespace Blackjack.API.Controllers
{
    public class GameController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public decimal Post([FromBody]CreateGameModel model)
        {
            var game = new Game(new Shoe(model.NumbersOfDecksInShoe), GetPlayers(model), GetDealerStrategy(model));
            return 1m;
            //   var outcomes = game.Play();
            // return outcomes.TotalWins;

        }

        private List<Player> GetPlayers(CreateGameModel model)
        {
            var players = new List<Player>();
            foreach (var player in model.Players)
            {
             var p = new Player(GetPlayerStrategy(player),player.Name,player.StartingBalance);   
            }
            return players;
        }

        private PlayerStrategy GetPlayerStrategy(PlayerModel player)
        {

            return new PlayerStrategy
            {
                HitSoftSeventeen = player.HitSoftSeventeen,
                TakesInsurance = player.TakesInsurance
            };
        }

        private DealerStrategy GetDealerStrategy(CreateGameModel model)
        {
            return model.DealerHitsSoftSeventeen ? (DealerStrategy) new VegasStrategy() : new OhioStrategy();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}