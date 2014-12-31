namespace Blackjack.Play.Player_Strategy
{
    public abstract class PlayerStrategy
    {
        public virtual bool HitSixteen { get { return true; } }
        public virtual bool TakesInsurance { get { return false; } } 
    }
}