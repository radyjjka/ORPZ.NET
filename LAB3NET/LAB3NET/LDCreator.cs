namespace LAB3NET
{
    public class LDCreator : DeckCreator
    {
        public override Deck createDeck()
        {
            return new LDeck();
        }
    }
}