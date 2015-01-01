using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Blackjack.Play.Entities
{
    public class Shoe
    {
        public int DecksInShoe { get; set; }
        private List<Card> _allCards;
        private static Random random = new Random();
        public Shoe(int numberOfDecksInShoe)
        {
            DecksInShoe = numberOfDecksInShoe;
            _allCards = new List<Card>();
            for (var x = 0; x < numberOfDecksInShoe; x++)
                _allCards.AddRange(Card.GetAllCards().ToList());

        }

        public Card GetCardFromShoe()
        {
            var card = _allCards[random.Next(_allCards.Count)];
            _allCards.Remove(card);
            return card;

        }

        public bool IsDead()
        {
            var twoThirdsPenetration = (int)((decimal)DecksInShoe*(decimal)52*((decimal)1/(decimal)3));
            return _allCards.Count() < twoThirdsPenetration;
        }
    }
    public static class CardExtensions
    {
        public static string CardDescription(this Card card)
        {
            string suit = "";
            switch (card.Suit)
            {
                case Suit.Clubs:
                    suit = "Clubs";
                    break;
                case Suit.Diamonds:
                    suit = "Diamonds";
                    break;
                case Suit.Hearts:
                    suit = "Hearts";
                    break;
                case Suit.Spades:
                    suit = "Spades";
                    break;
            }
            return string.Format("{0} of {1}", card.Name, suit);
        }
    }
}