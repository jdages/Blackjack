using System;

namespace Blackjack.Play.Player_Strategy
{
    [Serializable]
    public class PlayerStrategy
    {
        public virtual bool HitSoftSeventeen => true;
        public virtual bool TakesInsurance { get; set; }
    }
}