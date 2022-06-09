using System.Collections.Generic;

namespace LAB3NET
{
    public abstract class Deck
    {
        public abstract void addCard(int suit, int value);
        public abstract List<Card> returnCards();
    }
}