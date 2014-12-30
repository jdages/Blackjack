using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Play.Entities;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = string.Empty;
            var shoe = new Shoe(1);
            for (var x = 0; x < 52; x++)
            {
                var cardFromShoe = shoe.GetCardFromShoe();
                output += cardFromShoe.CardDescription() + 
                    "\n";
                Console.WriteLine(cardFromShoe.CardDescription());
            }
            File.WriteAllText("c:\\deploy\\cards.txt",output);
            Console.ReadKey();

        }
    }
}
