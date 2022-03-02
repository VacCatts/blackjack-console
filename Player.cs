using System;

namespace blackjackconsole
{
    class Player
    {
        public static int[] deck = {0,0,0,0,0};
        public static int total; // total of the cards (again)
        public static void GiveCards() // so the function gives the first 2 cards, theres def a better way to do it but i cba lol
        {
            var r = new Random();

            var card1 = r.Next(1, 11);
            var card2 = r.Next(1, 11);

            deck[0] = card1; 
            deck[1] = card2;

            total = card1 + card2;

            Console.WriteLine($"You got {card1} and {card2} for a total of {total}");
        }

        public static void Hit() // this cool hit function (it works)
        {
            var r = new Random();

            var card1 = r.Next(1, 11);

            for(int item = 0; item <= 5; item++) // i basically copied this from the Dealer.cs file (i lied its the other way around)
            {
                if(deck[item] == 0)
                {
                    deck[item] = card1;
                    total += card1;
                    break;
                }
            }

            total = GetAllArrayInt(deck);

            Console.WriteLine($"You got {card1} for a total of {total}");

            if (HasBusted()) { // if the player has busted, he loses (no shit sherlock)
                Console.WriteLine("You busted!");
                Program.Lose();
            }
        }

        public static void Stand() // the stand :moyai: 
        {
            Console.WriteLine($"You stood with a total of {total}");
            FinishTurn();
        }

        public static void FinishTurn() // finish players turn (this is how blackjack works yes?)
        {
            Console.WriteLine("Dealer's turn");
            Dealer.RevealCards(); // show dealers cards (it was about time)
            Dealer.AI(); // the dealer "AI"
        }

        public static int GetAllArrayInt(int[] array) // again why do i do these things?
        {
            var total2 = 0;
            foreach(var item in array)
            {
                total2 += item;
                //Console.WriteLine(item);
            }
            return total2;
        }

        public static bool HasBusted() // check if has busted if yes return true if no return false
        {
            if(total > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}