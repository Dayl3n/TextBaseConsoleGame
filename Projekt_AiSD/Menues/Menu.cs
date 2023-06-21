using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static Projekt_AiSD.QuestList;
using Projekt_AiSD.Plot;
using Projekt_AiSD.Player_Staff;

namespace Projekt_AiSD.Menues
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
                Game.centerText(prompt+"\n",prompt.Length);              
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
                    Game.centerText($"{prefix}{choicesListQuest.ElementAt(i).Key}",choicesListQuest.ElementAt(i).Key.Length);

                }
                ResetColor();

               
                WriteLine("\n\n\n\n\n" + new String('_',WindowWidth)+"\n\n");
                string instructions1 = "arrow up and down - selecet your option       press [enter] - confirm your choice";
                string instructions2 = "press[i] - open character view      press [esc] - pause game";               
                Game.centerText(instructions1, instructions2.Length);
                Game.centerText(instructions2, instructions1.Length);
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
                else if (keyPressed == ConsoleKey.I)
                {
                    Equipment.DisplayEquipmentMenu();
                    Game.RunMainMenu();
                }

            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }


    }
}
