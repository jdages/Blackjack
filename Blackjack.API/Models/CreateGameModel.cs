using System;
using System.Collections.Generic;

namespace Blackjack.API.Models
{
    [Serializable]
    public class CreateGameModel
    {
        public CreateGameModel()
        {
            Players = new List<PlayerModel>();
        }
        public int NumbersOfDecksInShoe { get; set; }
        public List<PlayerModel> Players { get; set; }

        public bool DealerHitsSoftSeventeen { get; set; }
    }

    [Serializable]
    public class PlayerModel
    {
        public string Name { get; set; }
        public bool HitSoftSeventeen { get; set; }
        public bool TakesInsurance { get; set; }

        public decimal StartingBalance { get; set; }
    }
}