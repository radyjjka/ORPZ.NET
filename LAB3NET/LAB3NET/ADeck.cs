using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB3NET
{
    public class ADeck : Deck
    {
        private Card[] _cards;

        public ADeck()
        {
            _cards = new Card[52];
        }

        public override void addCard(int suit, int value)
        {
            if (_cards[51] is object)
            {
                throw new Exception("Too much cards.");
            }
            
            Card newCard = CardCreator.createCard(suit, value);
            var cards = returnCards();

            if (cards.FirstOrDefault(c => c.Suit == newCard.Suit && c.Value == newCard.Value) != null)
            {
                throw new Exception("Already in deck.");
            }

            for (int i = 0; i < _cards.Length; i++)
            {
                _cards[i] = newCard;
                break;
            }

        }

        public override List<Card> returnCards()
        {
            return _cards.Where(c=>c!=null).ToList();
        }
    }
}