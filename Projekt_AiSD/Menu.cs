using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static Projekt_AiSD.QuestList;


namespace Projekt_AiSD
{
    internal class Menu
    {
        protected int selectedIndex = 0;
        protected Dictionary<string, TaskOptionData> choicesListQuest;
        protected string prompt { get; set; }

        
        virtual protected void DisplayOptions()
        {
            string prefix = " ";
            ForegroundColor = ConsoleColor.Red;
            if (choicesListQuest != null)
            {
                WriteLine("\n" + prompt);
                for (int i = 0; i < choicesListQuest.Count; i++)
                {

                    if (i == selectedIndex)
                    {
                        prefix = " >";
                        ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        prefix = " ";
                        ForegroundColor = ConsoleColor.Red;
                    }
                    WriteLine($"                            {prefix} {choicesListQuest.ElementAt(i).Key}");

                }
                ResetColor();
            }
        }
        virtual public int ChangeOption()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey();
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                        selectedIndex = choicesListQuest.Count - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == choicesListQuest.Count)
                        selectedIndex = 0;
                }
                else if (keyPressed == ConsoleKey.Escape)
                    Game.RunMainMenu();

            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }


    }
}
