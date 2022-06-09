namespace LAB3NET
{
    public static class CardCreator
    {
        public static Card createCard(int suit, int value)
        {
            return new Card() {Suit = suit, Value = value};
        }
    }
}