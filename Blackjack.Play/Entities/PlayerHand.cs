namespace Blackjack.Play.Entities
{

    public class PlayerHand : Hand
    {

        public PlayerHand()
        {
            
        }

        public bool IsComplete()
        {
            if (!IsSoft() && Value() >= 17)
                return true;
            return false;
        }
    }
}