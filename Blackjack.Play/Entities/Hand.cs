using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Play.Entities
{
    public class Hand
    {
        protected List<Card> Cards = new List<Card>();

        public int HandValue()
        {
            var count = Cards.Sum(a => a.Value);
            if (count <= 11 && Cards.Any(a => a.IsAce))
                count += 10;
            return count;
        }

        public bool IsSoft()
        {
            return Cards.Sum(a => a.Value) <= 11 && Cards.Any(a => a.IsAce);

        }
        public bool IsBusted()
        {
            return HandValue() > 21;
        }

    }
}