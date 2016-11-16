﻿namespace Blackjack.API.Models
{
    public class ResultModel
    {
        public string Name { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal EndingBalance { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Pushes { get; set; }

    }
}