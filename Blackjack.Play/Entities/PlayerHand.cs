using Blackjack.Play.Player_Strategy;

namespace Blackjack.Play.Entities
{

    public class PlayerHand : Hand
    {
        public bool IsComplete(PlayerStrategy strategy, Card dealerCard)
        {
            var playerValue = Value();
            var dealerShowValue = dealerCard.Value;
            if (!IsSoft() && playerValue >= 17)
                return true;

            if (IsSoft() && playerValue == 17)
                return !strategy.HitSoftSeventeen;

            if (dealerShowValue >= 2 && dealerShowValue <= 6)
            {
                if (playerValue >= 12)
                    return true;
            }


            return false;
        }
    }
}