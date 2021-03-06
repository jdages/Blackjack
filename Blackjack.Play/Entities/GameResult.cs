﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Play.Entities
{
    [Serializable]
    public class GameResult
    {
        public int DecksInShoe { get; set; }
        public int TotalHands { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int TotalPushes { get; set; }
        public decimal TotalWinAmount { get; set; }
        public List<Player> PlayerOutcomes { get; set; }

        public GameResult()
        {
            PlayerOutcomes = new List<Player>();
        }
        public override string ToString()
        {
            return string.Format("Total Decks: {0}\nTotal Wins: {1}\nTotal Pushes: {2}\nTotal Losses: {3}", DecksInShoe, TotalWins,
                TotalPushes, TotalLosses);
        }
    }

    public static class GameResultExtensions
    {
        public static string CollectedOutcomes(this List<GameResult> results)
        {
            return string.Format("Total Decks: {0}\nTotal Wins: {1}\nTotal Pushes: {2}\nTotal Losses: {3}\nTotal Win Amount: {4}\nTotal Hands: {5}", results.First().DecksInShoe, results.Sum(a=>a.TotalWins),
                results.Sum(a => a.TotalPushes), results.Sum(a => a.TotalLosses), results.Sum(a=>a.TotalWinAmount), results.Sum(a=>a.TotalHands));
        }

    }
}