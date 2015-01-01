namespace Blackjack.Play.Entities
{
    public class GameResult
    {
        public int DecksInShoe { get; set; }
        public int TotalHands { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int TotalPushes { get; set; }
        public decimal TotalWinAmount { get; set; }

        public override string ToString()
        {
            return string.Format("Total Decks: {0}\nTotal Wins: {1}\nTotal Pushes: {2}\nTotal Losses: {3}", DecksInShoe, TotalWins,
                TotalPushes, TotalLosses);
        }
    }
}