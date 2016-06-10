using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Play.Dealer_Strategy;
using Blackjack.Play.Entities;
using Blackjack.Play.Player_Strategy;

namespace Blackjack.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var allOutcomes = new List<GameResult>();
            
            Parallel.For(0,100000, body =>
            {
                var shoe = new Shoe(8);

                var game = new Game(shoe, new List<Player> { new Player(new TraditionalStrategy(), "Dages", 100m) },
                    new VegasStrategy());
                allOutcomes.Add(game.Play());
            });
            
            System.Console.WriteLine(allOutcomes.CollectedOutcomes());
            System.Console.ReadLine();

        }
    }
}
