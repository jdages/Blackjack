using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Play.Entities
{
    public class DealerHand : Hand
    {
        public DealerHand()
        {
            
        }

        public Card GetShowCard()
        {
            return Cards[1];
        }

        public bool IsBlackjack()
        {
            return Cards.Any(a => a.IsAce) && Cards.Any(a => a.Value == 10);
        }

        public void AddCard(Card newCard)
        {
            Cards.Add(newCard);
        }
    }
}