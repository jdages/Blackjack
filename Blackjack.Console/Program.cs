using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            
            var webClient = new WebClient();
            webClient.DownloadString("ENTER URL HERE");

        }
    }
}
