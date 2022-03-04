using System;
using System.Collections.Generic;
using System.IO;

namespace blackjackconsole
{
    class SaveData {
        // TODO: comment this
        public static int cash = 100;
        public static int wins = 0;
        public static int losses = 0;
        public static int pushes = 0;
        public static int bet = 0;
        public static string savefile = null;

        public static void Init() {
            savefile = Environment.GetEnvironmentVariable("localappdata") + @"\blackjack.txt";
            if (!File.Exists(savefile)) {
                File.Create(savefile);
            }
            LoadSave();
        }

        public static bool Save() {
            try {
                File.WriteAllText(savefile, cash + "\n" + wins + "\n" + losses + "\n" + pushes);
                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Could not save data.");
                return false;
            }
        }
        public static bool LoadSave() {
            try
            {
                if (File.Exists(savefile))
                {
                    var lines = File.ReadAllLines(savefile);
                    cash = Convert.ToInt32(lines[0]);
                    wins = Convert.ToInt32(lines[1]);
                    losses = Convert.ToInt32(lines[2]);
                    pushes = Convert.ToInt32(lines[3]);
                    return true;
                }
                else
                {
                    CreateSave();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Save file not found or corrupted");
                throw;
            }
        }

        public static bool CreateSave() {
            try
            {
                if (!File.Exists(savefile))
                {
                    File.Create(savefile);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Save file couldn't be created");
                throw;
            }
        }
    }
}