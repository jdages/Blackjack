using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Blackjack.API.EF;
using Blackjack.API.Models;
using Blackjack.Play.Dealer_Strategy;
using Blackjack.Play.Entities;
using Blackjack.Play.Player_Strategy;
using Player = Blackjack.Play.Entities.Player;
using ResultModel = Blackjack.API.Models.ResultModel;
using Game = Blackjack.Play.Entities.Game;

namespace Blackjack.API.Controllers
{
    public class GameController : ApiController
    {

        
        // POST api/<controller>
        public List<ResultModel> Post([FromBody]CreateGameModel model)
        {
            var game = new Game(new Shoe(model.NumbersOfDecksInShoe), GetPlayers(model), GetDealerStrategy(model));

            var gameResult = game.Play();

            //SaveGameToDatabase(model, gameResult);
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

        private static void SaveGameToDatabase(CreateGameModel model, GameResult gameResult)
        {
            using (var context = new BlackjackContext())
            {
                try
                {
                    context.Games.Add(new EF.Game
                    {
                        Id = Guid.NewGuid(),
                        DealerHitsSeventeen = model.DealerHitsSoftSeventeen,
                        Losses = gameResult.TotalLosses,
                        Wins = gameResult.TotalWins,
                        NetChanges = gameResult.PlayerOutcomes.Sum(r => r.BankRoll) - model.Players.Sum(r => r.StartingBalance),
                        Players = gameResult.PlayerOutcomes.Select(r => new EF.Player
                        {
                            ID = Guid.NewGuid(),
                            Name = r.Name,
                            TookInsurance = r.Strategy.TakesInsurance
                        }).ToList()
                    });
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
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