using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Blackjack.API.Models;
using Blackjack.Play.Dealer_Strategy;
using Blackjack.Play.Entities;
using Blackjack.Play.Player_Strategy;
using ResultModel = Blackjack.API.Models.ResultModel;

namespace Blackjack.API.Controllers
{
    public class GameController : ApiController
    {

        // POST api/<controller>
        public List<ResultModel> Post([FromBody]CreateGameModel model)
        {
            var game = new Game(new Shoe(model.NumbersOfDecksInShoe), GetPlayers(model), GetDealerStrategy(model));
            game.Play();
            return game.WebResults().Select(a => new ResultModel
            {
                StartingBalance = a.StartingBalance,
                EndingBalance = a.EndingBalance,
                Wins = a.Wins,
                Losses = a.Losses,
                Pushes = a.Pushes,
                Name = a.Name

            }).ToList();

        }

        private List<Player> GetPlayers(CreateGameModel model)
        {
            var players = new List<Player>();
            foreach (var player in model.Players)
            {
                var playerInfo = new Player(GetPlayerStrategy(player), player.Name, player.StartingBalance);
                players.Add(playerInfo);
            }
            return players;
        }

        private PlayerStrategy GetPlayerStrategy(PlayerModel player)
        {

            return new PlayerStrategy
            {
                TakesInsurance = player.TakesInsurance
            };
        }

        private DealerStrategy GetDealerStrategy(CreateGameModel model)
        {
            return model.DealerHitsSoftSeventeen ? (DealerStrategy)new VegasStrategy() : new OhioStrategy();
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