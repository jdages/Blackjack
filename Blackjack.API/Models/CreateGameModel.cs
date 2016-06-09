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
}