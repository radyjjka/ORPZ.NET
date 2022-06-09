using System;

namespace LAB3NET
{
    public static class Program
    {
        private static int userChoice()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please try again");
                }
            }
        }
        
        static void Main(string[] args)
        {
            Deck myDeck = null;
            do
            {
                DeckCreator myDeckCreator;
                Console.WriteLine("Please choose the type of the deck :");
                Console.WriteLine("1) Array Deck");
                Console.WriteLine("2) Linked List Deck");

                switch (userChoice())
                {
                    case 1:
                        myDeckCreator = new ADCreator();
                        myDeck = myDeckCreator.createDeck();
                        break;
                    case 2:
                        myDeckCreator = new LDCreator();
                        myDeck = myDeckCreator.createDeck();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            } while (myDeck == null);

            Console.Clear();

            while (true)
            {
                Console.WriteLine("Please choose your next action : ");
                Console.WriteLine("1) Add a card");
                Console.WriteLine("2) Show the deck");
                switch (userChoice())
                {
                    case 1:
                        addCard(myDeck);
                        break;
                    case 2:
                        printCards(myDeck);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }

        private static void addCard(Deck deck)
        {
            Console.WriteLine("Please choose card suit : ");
            Console.WriteLine("1) Spades\t2) Clubs");
            Console.WriteLine("3) Hearts\t 4) Diamonds");
            int suit = userChoice();
            Console.WriteLine("Please choose card value : ");
            Console.WriteLine("1) Ace\t2) 2");
            Console.WriteLine("3) 3\t 4) 4");
            Console.WriteLine("5) 5\t 6) 6");
            Console.WriteLine("7) 7\t 8) 8");
            Console.WriteLine("9) 9\t 10) 10");
            Console.WriteLine("11) Jack\t 12) Queen");
            Console.WriteLine("13) King");
            int value = userChoice();
            
            deck.addCard(suit,value);
        }

        private static void printCards(Deck deck)
        {
            Console.WriteLine("Your deck : ");
            var cards = deck.returnCards();
            foreach (var c in cards)
            {
                if (c.Value == 1)
                {
                    Console.Write("Ace of ");
                }
                else if (c.Value == 11)
                {
                    Console.Write("Jack of ");
                }
                else if (c.Value == 12)
                {
                    Console.Write("Queen of ");
                }
                else if (c.Value == 13)
                {
                    Console.Write("King of ");
                }
                else
                {
                    Console.Write(c.Value + " of ");
                }

                if (c.Suit == 1)
                {
                    Console.Write("Spades");
                }
                else if (c.Suit == 2)
                {
                    Console.Write("Clubs");
                }
                else if (c.Suit == 3)
                {
                    Console.Write("Hearts");
                }
                else if (c.Suit == 4)
                {
                    Console.Write("Diamonds");
                }

                Console.WriteLine();
            }
            
        }
    }
}