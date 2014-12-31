using System.Collections.Generic;
using System.Linq;
using Blackjack.Play.Dealer_Strategy;

namespace Blackjack.Play.Entities
{
    public class Game
    {
        private Shoe _shoe;
        private List<Player> _players;
        private DealerStrategy _dealerStrategy;
        private DealerHand _hand = new DealerHand();
        private Dictionary<Player, List<Card>> _playerCards = new Dictionary<Player, List<Card>>();

        Card DealerShowCard { get { return _hand.GetShowCard(); } }

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

            OfferInsurance();
            DealerBlackjack();
            return;
        }

        private void DealerBlackjack()
        {
            if (_hand.IsBlackjack())
                _players.ForEach(a => a.CompleteHand(_hand));

        }

        private void OfferInsurance()
        {
            if (DealerShowCard.IsAce)
                foreach (var player in _players)
                {
                    player.OfferInsurance();
                }
        }

        private void Deal()
        {
            foreach (var player in _players)
                _playerCards.Add(player, new List<Card> { _shoe.GetCardFromShoe() });

            _hand.AddCard(_shoe.GetCardFromShoe());

            foreach (var player in _players)
                _playerCards[player].Add(_shoe.GetCardFromShoe());

            _hand.AddCard(_shoe.GetCardFromShoe());
        }
    }


}