using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Blackjack.Play.Entities
{
    public class CompleteHand
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public DealerFinalHand DealerFinalHand { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class DealerFinalHand
    {
        public FinalCard[] DealerCards { get; set; }
    }
    

    public class FinalCard
    {
        public string Suit { get; set; }
        public string Value { get; set; }
    }
}
