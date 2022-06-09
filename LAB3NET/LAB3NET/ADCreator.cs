namespace LAB3NET
{
    public class ADCreator : DeckCreator
    {
        public override Deck createDeck()
        {
            return new ADeck();
        }
    }
}