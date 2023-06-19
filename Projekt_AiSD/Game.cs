using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static Projekt_AiSD.QuestList;

namespace Projekt_AiSD
{
    internal class Game
    {
        
        private bool gameStatus = false;
        public static Player player;
        private Dragon enemy = new Dragon("             __.-/|\r\n             \\`o_O'\r\n              =( )=  +-----+\r\n                U|   | BEN |" +
            "\r\n      /\\  /\\   / |   +-----+\r\n     ) /^\\) ^\\/ _)\\     |\r\n     )   /^\\/   _) \\    |\r\n     )   _ /  / _)  \\___|_\r\n /\\  )/\\/ || " +
            " | )_)\\___,|))\r\n<  >      |(,,) )__)    |\r\n ||      /    \\)___)\\\r\n | \\____(      )___) )____\r\n  \\______(_______;;;)__;;;)",
            100, 10, 5, 5);
        public void Start()
        {
            Title = "Pustkowia";
            RunMainMenu();
        }
        public static void RunMainMenu()
        {
            Clear();
            Game mainMenuGame_object = new Game();
            MainMenu mainMenu = new MainMenu();
            int selectedIndex = mainMenu.ChangeOption();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    if(mainMenuGame_object.CreateCharacter());
                        mainMenuGame_object.Plot();
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
        private void Plot()
        {
            Event newGame = new Event();

            string mainQuest_0_text = "Long long time ago there was a shitty looking dude that wanted to fuck your mum, what u do?";
            Dictionary<string, TaskOptionData> options_mainQuest_0 = new Dictionary<string, TaskOptionData>()
            {
                {"bitten shit out of him",new TaskOptionData(MainQuest, -1)},
                {"helping him", new TaskOptionData(OldSword, 0)},
                {"crying",new TaskOptionData(Wagoon, 0) }
            };
            MyTask mainQuest_0 = new MyTask(mainQuest_0_text, options_mainQuest_0);



            string mainQuest_1_text = "Well, u lost";
            Dictionary<string, TaskOptionData> options_mainQuest_1 = new Dictionary<string, TaskOptionData>()
            {
                {"Try again", new TaskOptionData(MainQuest, -1)},
                {"No U",new TaskOptionData(Wagoon, 0)},
                {"I admit my lose, now I'm helping him",new TaskOptionData(OldSword, 0)}
            };
            MyTask mainQuest_1 = new MyTask(mainQuest_1_text, options_mainQuest_1);

            

            string oldSword_0_text = "Bro, what is wrong with you?";
            Dictionary<string, TaskOptionData> options_oldSword_0 = new Dictionary<string, TaskOptionData>()
            {
                {"Enjoy yourself", new TaskOptionData(OldSword, -1)},
                {"Killing yourself", new TaskOptionData(Wagoon, 0)}
            };
            MyTask oldSword_0 = new MyTask(oldSword_0_text, options_oldSword_0);

            string deathInShadows_0_text = "C'mon little crybaby do something";
            Dictionary<string, TaskOptionData> options_deathInShadows_0 = new Dictionary<string, TaskOptionData>()
            {
                {"SHUT UP", new TaskOptionData(Wagoon, -1)}
            };
            MyTask deathInShadows_0 = new MyTask(deathInShadows_0_text, options_deathInShadows_0);

            Quest mainQuest_object = new Quest(MainQuest, player);
            Quest oldSword_object = new Quest(OldSword, player);
            Quest death_object = new Quest(Wagoon, player);

            mainQuest_object.addTask(mainQuest_0);
            mainQuest_object.addTask(mainQuest_1);
            oldSword_object.addTask(oldSword_0);
            death_object.addTask(deathInShadows_0);

            newGame.AddQuest(mainQuest_object);
            newGame.AddQuest(death_object);
            newGame.AddQuest(oldSword_object);

            newGame.SetupAndStartQuesting(new TaskOptionData(MainQuest, 0));

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
