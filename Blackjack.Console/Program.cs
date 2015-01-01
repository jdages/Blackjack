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
            string output = string.Empty;
            var shoe = new Shoe(8);

            var game = new Game(shoe, new List<Player> {new Player(new TraditionalStrategy(), "Dages")},
                new VegasStrategy());
            GameResult result = game.Play();
            System.Console.WriteLine(result.ToString());
            System.Console.ReadKey();

        }
    }
}
