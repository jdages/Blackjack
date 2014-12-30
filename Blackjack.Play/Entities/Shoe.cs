using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Blackjack.Play.Entities
{
    public class Shoe
    {
        private List<Card> _allCards;
        private static Random random = new Random();
        public Shoe(int numberOfDecksInShoe)
        {
            _allCards = new List<Card>();
            //List<Deck> decks = new List<Deck>();
            for (var x = 0; x < numberOfDecksInShoe; x++)
                _allCards.AddRange(Card.GetAllCards().ToList());

            //_allCards = decks.SelectMany(a => a.GetAllCardsInDeck()).ToList();
        }

        public Card GetCardFromShoe()
        {
            var card = _allCards[random.Next(_allCards.Count)];
            _allCards.Remove(card);
            return card;

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