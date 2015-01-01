﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Blackjack.Play.Dealer_Strategy;

namespace Blackjack.Play.Entities
{
    public class Game
    {
        private Shoe _shoe;
        private List<Player> _players;
        private DealerStrategy _dealerStrategy;
        private DealerHand _dealerHand = new DealerHand();
        private Dictionary<Player, PlayerHand> _playerCards = new Dictionary<Player, PlayerHand>();
        private int _playerWins;
        private int _playerLosses;
        private int _playerPushes;

        Card DealerShowCard { get { return _dealerHand.GetShowCard(); } }

        public Game(Shoe shoe, List<Player> players, DealerStrategy dealerStrategy)
        {
            _dealerStrategy = dealerStrategy;
            _players = players;
            _shoe = shoe;
        }

        public GameResult Play()
        {
            var hands = 0;
            while (!_shoe.IsDead())
            {
                Deal();
                OfferInsurance();
                DealerBlackjack();
                CompletePlayerHands();
                CompleteDealerHands();
                DetermineOutcomes();
                Pay();
                CalculateIntermediateOutcomes();
                ClearHands();
                hands++;
            }
            return CalculateOutcomes(hands);
        }

        private void CalculateIntermediateOutcomes()
        {
            _playerWins += _playerCards.Count(a => a.Value.Outcome == HandOutcomes.Winner);
            _playerLosses += _playerCards.Count(a => a.Value.Outcome == HandOutcomes.Loser);
            _playerPushes += _playerCards.Count(a => a.Value.Outcome == HandOutcomes.Push);
        }

        private GameResult CalculateOutcomes(int hands)
        {
            var result = new GameResult();
            result.DecksInShoe = _shoe.DecksInShoe;
            result.TotalHands = hands;
            result.TotalWins = _playerWins;
            result.TotalLosses = _playerLosses;
            result.TotalPushes = _playerPushes;
            return result;
        }

        private void ClearHands()
        {
            _playerCards = new Dictionary<Player, PlayerHand>();
            _dealerHand = new DealerHand();
        }

        private void Pay()
        {
            

        }

        private void DetermineOutcomes()
        {
            foreach (var player in _players)
                _playerCards[player].AwardOutcomes(_dealerHand.Value());
        }

        private void CompleteDealerHands()
        {
            if (_playerCards.All(a => a.Value.IsBusted()))
                return;
            while (!_dealerHand.IsComplete())
                _dealerHand.AddCard(_shoe.GetCardFromShoe());
        }

        private void CompletePlayerHands()
        {
            foreach (var player in _players)
            {
                var hand = _playerCards[player];
                while (!hand.IsComplete() && !hand.IsKilled)
                    hand.AddCard(_shoe.GetCardFromShoe());
            }
        }

        private void DealerBlackjack()
        {
            if (_dealerHand.IsBlackjack())
                CompleteHands();

        }

        private void CompleteHands()
        {
            foreach (var player in _players)
                _playerCards[player].Kill();
        }

        private void OfferInsurance()
        {
            if (DealerShowCard.IsAce)
                foreach (var player in _players)
                    player.OfferInsurance();
        }

        private void Deal()
        {
            foreach (var player in _players)
            {
                player.ChargePlayer(1m);
                var newHand = new PlayerHand();
                newHand.AddCard(_shoe.GetCardFromShoe());
                _playerCards.Add(player, newHand);
            };

            _dealerHand.AddCard(_shoe.GetCardFromShoe());

            foreach (var player in _players)
            {
                _playerCards[player].AddCard(_shoe.GetCardFromShoe());
            }

            _dealerHand.AddCard(_shoe.GetCardFromShoe());
        }
    }


}