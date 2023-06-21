using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Projekt_AiSD.Menues
{
    internal class MainMenu : Menu
    {
        private string[] choicesListMenu = { "New Game", "Save game", "Load game", "Credits", "Exit" };
        private bool isRunning;
        public bool _isRunning
        {
            get { return isRunning; }
            set
            {
                if (value)
                    choicesListMenu[0] = "Continue";
                isRunning = value;
            }
        }
        public MainMenu()
        {
            prompt = @"
                      
            ▄███████▄  ███    █▄     ▄████████     ███        ▄█   ▄█▄  ▄██████▄   ▄█     █▄   ▄█    ▄████████ 
            ███    ███ ███    ███   ███    ███ ▀█████████▄   ███ ▄███▀ ███    ███ ███     ███ ███   ███    ███ 
            ███    ███ ███    ███   ███    █▀     ▀███▀▀██   ███ ██▀   ███    ███ ███     ███ ███   ███    ███ 
            ███    ███ ███    ███   ███            ███   ▀  ▄█████▀    ███    ███ ███     ███ ███   ███    ███ 
        ▀█████████▀    ███    ███ ▀███████████     ███     ▀▀█████▄    ███    ███ ███     ███ ███ ▀███████████ 
            ███        ███    ███          ███     ███       ███ ██▄   ███    ███ ███     ███ ███   ███    ███ 
            ███        ███    ███    ▄█    ███     ███       ███ ▀███▄ ███    ███ ███ ▄█▄ ███ ███   ███    ███ 
           ▄████▀      ████████▀   ▄████████▀     ▄████▀     ███   ▀█▀  ▀██████▀   ▀███▀███▀  █▀    ███    █▀  
            ▀                        ▀                        ▀                                      ▀                                                                                                   
            ";
            isRunning = false;
        }

        protected override void DisplayOptions()
        {
            string prefix = " ";
            ForegroundColor = ConsoleColor.Red;
            Game.centerText(prompt, 103);
            for (int i = 0; i < choicesListMenu.Length; i++)
            {

                if (i == selectedIndex)
                {
                    prefix = " >";
                    ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = "";
                    ForegroundColor = ConsoleColor.Red;
                }

                if (choicesListMenu[i] == "Save game" && isRunning == false)
                {
                    ForegroundColor = ConsoleColor.DarkGray;
                }
                Game.centerText($"{prefix}{choicesListMenu[i]}", choicesListMenu[i].Length);

            }
            ResetColor();
        }

        public override int ChangeOption()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey();
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                        selectedIndex = choicesListMenu.Length - 1;
                    if (choicesListMenu[selectedIndex] == "Save game" && isRunning == false)
                    {
                        selectedIndex--;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == choicesListMenu.Length)
                        selectedIndex = 0;
                    if (choicesListMenu[selectedIndex] == "Save game" && isRunning == false)
                    {
                        selectedIndex++;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }

    }
}
