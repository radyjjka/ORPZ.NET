using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB3NET
{
    public class LDeck : Deck
    {
        private LinkedList<Card> _cards;

        public LDeck()
        {
            _cards = new LinkedList<Card>();
        }
        
        public override void addCard(int suit, int value)
        {
            if (_cards.Count >= 52)
            {
                throw new Exception("Too much cards.");
            }
            Card newCard = CardCreator.createCard(suit, value);
            var cards = returnCards();
            if (_cards.FirstOrDefault(findCard => findCard.Suit == newCard.Suit && findCard.Value == newCard.Value) != null)
            {
                throw new Exception("Already in deck.");
            }

            _cards.AddLast(newCard);
        }

        public override List<Card> returnCards()
        {
            return _cards.ToList();
        }
    }
}