using System;

namespace Blackjack.API.Models
{
    [Serializable]
    public class PlayerModel
    {
        public string Name { get; set; }
        public bool HitSoftSeventeen { get; set; }
        public bool TakesInsurance { get; set; }

        public decimal StartingBalance { get; set; }
    }
}