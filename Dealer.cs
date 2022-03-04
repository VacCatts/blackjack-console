using System;

namespace blackjackconsole
{
    // REMINDER TO NOT LOOK AT THE CODE
    // ill try to make it as readable as possible for you with comments
    // with love, vaccat
    class Dealer
    {
        public static int[] deck = {0,0,0,0,0};
        public static int total; // total of the cards
        public static void GiveCards()
        {
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = 0;
            }

            var r = new Random();

            var card1 = r.Next(1, 11);
            var card2 = r.Next(1, 11);

            deck[0] = card1;
            deck[1] = card2;

            if (HasBusted()) { // making sure you cant get a total of over 21 from the first two cards
                deck[1] -= 1;
            }

            total = card1 + card2;

            Console.WriteLine($"The dealer's revealed card is {card1}"); // pretty self explanatory
        }

        public static void Hit()
        {
            var r = new Random();

            var card1 = r.Next(1, 11);

            try // i believe try catching is a bit like cheating but whatever lol
            {
                for(int item = 0; item <= 5; item++) // i basically copied this from the Dealer.cs file (i lied its the other way around)
                {
                    if(deck[item] == 0)
                    {
                        deck[item] = card1;
                        total += card1;
                        break;
                    }
                }
            }
            catch (IndexOutOfRangeException) // if the deck is full
            {
                Stand();
                return;
            }

            total = GetAllArrayInt(deck); // getting the total of the array (i have no idea why i do this but its there just in case)

            Console.WriteLine($"The dealer got {card1} for a total of {total}"); // he got the card doe :skull:
            if (HasBusted()) { // check if the dealer has busted, if yes, he loses
                Console.WriteLine("The dealer busted!");
                Game.Lose();
            }

            if (Player.total > total && !HasBusted()) { // if the player has a higher total than the dealer and the dealer hasnt busted, try to hit again
                Hit();
            } else { // else stand
                Stand();
            }
        }

        public static void Stand() // so i guess i should just use Program.Lose???
        {
            //Console.WriteLine($"The dealer with a total of {total}");
            Game.Lose();
        }

        public static void RevealCards() // print out dealers cards
        {
            // TODO: dont print the 0s
            Console.WriteLine($"The dealer has the cards {deck[0]}, {deck[1]}, {deck[2]}, {deck[3]}, {deck[4]} for a total of {total}");
        }

        public static int GetAllArrayInt(int[] array) // so this is the ancient way of counting the total, still works !
        {
            var total2 = 0;
            foreach(var item in array)
            {
                total2 += item;
            }
            return total2;
        }

        public static bool HasBusted() // check if the dealer has busted
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

        public static void AI() { // the dealer "AI" (in quotes), it will hit until the total is over 17 or the player has a higher number
            if (total < 17 || Player.total < total && !HasBusted()) {
                Hit();
            }
            else {
                Stand();
            }
        }
    }
}