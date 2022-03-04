using System;

namespace blackjackconsole
{
    class Program
    {
        static void Main()
        {
            SaveData.Init();
            MainMenu();
        }

        public static void MainMenu() { // bless github copilot it just made this function by itself B)
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Stats");
            Console.WriteLine("3. Exit");
            var option = Console.ReadKey();

            switch (option.KeyChar)
            {
                case '1':
                    SaveData.Save();
                    SetBet();
                    Game.Run();
                    break;
                case '2':
                    SaveData.Save();
                    Stats();
                    break;
                case '3':
                    SaveData.Save();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    MainMenu();
                    break;
            }
        }

        public static void AskForRestart() { // i might just use the main menu function instead :skull:, ill let it slip for now
            Console.Write("\n\n");
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            var option = Console.ReadKey();

            switch (option.KeyChar)
            {
                case '1':
                    Program.SetBet();
                    Console.Write("\n\n\n\n\n\n\n\n\n");
                    Game.Run();
                    break;
                case '2':
                    MainMenu();
                    Console.Write("\n\n\n\n\n\n\n\n\n");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    AskForRestart();
                    break;
            }
        }

        public static void SetBet() { // i love github copilot
            Console.WriteLine("How much would you like to bet?");
            int bet2 = Convert.ToInt32(Console.ReadLine());
            if (bet2 > SaveData.cash) {
                Console.WriteLine("You don't have enough money!");
                SetBet();
            }
            else {
                SaveData.bet = bet2;
                SaveData.cash -= bet2;
                return;
            }
        }

        public static void Stats() {
            Console.WriteLine("Cash: " + SaveData.cash);
            Console.WriteLine("Wins: " + SaveData.wins);
            Console.WriteLine("Losses: " + SaveData.losses);
            Console.WriteLine("Pushes: " + SaveData.pushes);
            MainMenu();
        }
    }
}
