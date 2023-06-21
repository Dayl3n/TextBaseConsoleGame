using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_AiSD.DataBase;
using Projekt_AiSD.Enemies;
using Projekt_AiSD.Menues;
using Projekt_AiSD.Player_Staff;
using Projekt_AiSD.Plot;
using static System.Console;
using static Projekt_AiSD.QuestList;

namespace Projekt_AiSD
{
    internal class Game
    {
        public static MainMenu mainMenu = new MainMenu();
        public static Player player;
        public static DataBaseReader reader = new DataBaseReader(player);
        public static Equipment equipment = new Equipment(player);
        public void Start()
        {
            Title = "Pustkowia";
            RunMainMenu();
        }
        public static void RunMainMenu()
        {
            Clear();
            Game mainMenuGame_object = new Game();

            int selectedIndex = mainMenu.ChangeOption();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    if (mainMenuGame_object.CreateCharacter()&&mainMenu._isRunning==false)
                    {   
                        mainMenu._isRunning = true;
                        DataBaseReader reader = new DataBaseReader(player);
                        foreach(var Item in reader.ItemsList)
                        {
                            equipment.AddItem(Item.Value);
                        }
                        reader.firstEvent.SetupAndStartQuesting(new TaskOptionData(MainQuest, 0));
                    }
                    else
                    {

                    }
                    break;
                case 2:
                    Clear();
                    mainMenuGame_object.Load();
                    break;
                case 3:
                    Clear();
                    mainMenuGame_object.Credits();
                    break;
                case 4:
                    mainMenuGame_object.Exit();
                    break;
            }

        }

        private bool CreateCharacter()
        {
            if (player == null)
            {
                WriteLine("Please name your Character");
                string playerName = ReadLine();
                player = new Player(playerName);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Load() { WriteLine("load game in the future"); }

        private void Credits()
        {
            WriteLine("Wersja gry 0.0.1\n" +
                "Autor gry: Jakub Leszczyński\n" +
                "Nowoczesne Technologie w Kryminalistce, projekt zaliczeniowy na Algorytmy i sruktury danych\n" +
                "Wersja demo");
            if (ReadKey().Key == ConsoleKey.Escape)
                RunMainMenu();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        public static void GameOver()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine(@"
                    ██    ██     ██████  ██ ███████ ██████  
                    ██    ██     ██   ██ ██ ██      ██   ██ 
                    ██    ██     ██   ██ ██ █████   ██   ██ 
                    ██    ██     ██   ██ ██ ██      ██   ██ 
                     ██████      ██████  ██ ███████ ██████ ");
            ReadKey(true);
            Environment.Exit(0);
        }
        public static void centerText(string text, int length)
        {
            Console.WriteLine("\n"+String.Format("{0," + ((Console.WindowWidth / 2) + (length / 2)) + "}", text));
        }
    }
}
