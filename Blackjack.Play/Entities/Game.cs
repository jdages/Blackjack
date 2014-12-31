using System.Collections.Generic;
using Blackjack.Play.Dealer_Strategy;

namespace Blackjack.Play.Entities
{
    public class Game
    {
        private Shoe _shoe;
        private List<Player> _players;
        private DealerStrategy _dealerStrategy;
        private List<Card> _dealerCards = new List<Card>(); 
        private Dictionary<Player,List<Card>> _playerCards = new Dictionary<Player, List<Card>>();

        Card DealerShowCard { get { return _dealerCards[1]; } }

        public Game(Shoe shoe, List<Player> players, DealerStrategy dealerStrategy)
        {
            _dealerStrategy = dealerStrategy;
            _players = players;
            _shoe = shoe;
        }

        public void Play()
        {
            if (_shoe.IsDead())
                return;

            Deal();
            

            return;
        }

        private void Deal()
        {
            foreach (var player in _players)
                _playerCards.Add(player,new List<Card>{_shoe.GetCardFromShoe()});
            
            _dealerCards.Add(_shoe.GetCardFromShoe());

            foreach (var player in _players)
                _playerCards[player].Add(_shoe.GetCardFromShoe());
            
        }
    }

    public class Hand
    {
        
    }
}