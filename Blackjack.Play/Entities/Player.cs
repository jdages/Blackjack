using System.Collections.Specialized;
using Blackjack.Play.Player_Strategy;

namespace Blackjack.Play.Entities
{
    public class Player
    {

        public string Name { get; set; }
        public PlayerStrategy Strategy { get; private set; }

        public Player(PlayerStrategy strategy, string name = "Unknown")
        {
            Strategy = strategy;
            Name = name;
        }

    }
}