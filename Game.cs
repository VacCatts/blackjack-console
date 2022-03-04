using System;
using blackjackconsole;

namespace blackjackconsole
{
    class Game
    {
        public static void Run()
        {
            // give the player and dealer their two cards
            Player.GiveCards();
            Dealer.GiveCards();

            // and then ask the player for input
            AskForInput();
        }

        static void AskForInput() // this scuffed ass input function :skull:
        {
            if (Player.HasBusted() && Dealer.HasBusted()) // if any of the players have busted, lose function
                Lose();
            Console.WriteLine("What would you like to do?"); // ask the player what they want to do
            Console.WriteLine("1. Hit");
            Console.WriteLine("2. Stand");
            Console.WriteLine("3. Exit");
            var option = Console.ReadKey(false); // get those mf keys :skull:

            switch (option.KeyChar) // holy god im so happy i used a switch instead of an if so i dont get called yandev v2
            {
                case '1':
                    Player.Hit();
                    AskForInput();
                    break;
                case '2':
                    Player.Stand();
                    break;
                case '3':
                    Environment.Exit(0); // :trolley:
                    break;
                default:
                    Console.WriteLine("Invalid input"); // invalid input :skull:
                    AskForInput();
                    break;
            }
        }

        public static void Lose() {
            if (Player.total > Dealer.total && !Player.HasBusted() || Dealer.HasBusted()) // if players total is more than dealers total and player hasnt busted, or the dealer has busted
            {
                Console.WriteLine("You win!");
                SaveData.wins++;
                SaveData.cash += SaveData.bet * 2;
            }
            else if (Player.total < Dealer.total && !Dealer.HasBusted() || Player.HasBusted()) // if players total is less than dealers total and dealer hasnt busted, or the player has busted
            {
                Console.WriteLine("You lose!");
                SaveData.losses++;
            }
            else // push
            {
                Console.WriteLine("Push!");
                SaveData.pushes++;
                SaveData.cash += SaveData.bet;
            }
            Program.AskForRestart(); // i did it i made a restart function B)
        }
    }
}
