using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Projekt_AiSD
{
    internal class EqMenu : Menu
    {
        private Equipment items = new Equipment();
        public int firstItemIndex;
        public int lastItemIndex;
        private string charArt = @"
                                               /////^\\\\\
                                                | ^   ^ |
                                               @ (o) (o) @
                                                |   <   |
                                                |  ___  |
                                                 \_____/
                                               ____|  |____
                                              /            \
                                             / /|        |\ \
                                            / / |        | \ \
                                           / /  |        |  \ \
                                          ( <   |        |   > )
                                           \ \  |        |  / /
                                            \ \ |        | / /
                                             \ \|________|/ /";

        public EqMenu(Equipment eq)
        {
            items = eq;
        }

        protected override void DisplayOptions()
        {
            WriteLine(charArt+"\n");
            items.AllItems[selectedIndex].getItemArt();         
            ForegroundColor = ConsoleColor.White;                               
            Write("                    ");
            items.AllItems[firstItemIndex].getItemName();
            ForegroundColor = ConsoleColor.White;
            Write("                      [");
            items.AllItems[selectedIndex].getItemName();
            ForegroundColor = ConsoleColor.White;
            Write("]                      ");
            items.AllItems[lastItemIndex].getItemName();
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

                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == 0)
                    {
                        firstItemIndex = items.AllItems.Count - 1;
                    }
                    else
                    {
                        firstItemIndex = selectedIndex - 1;                        
                    }
                    lastItemIndex = selectedIndex + 1;
                    if (selectedIndex < 0)
                        selectedIndex = items.AllItems.Count - 1;
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == items.AllItems.Count)
                    {
                        lastItemIndex = 0;
                    }
                    else
                    {                        
                        lastItemIndex = selectedIndex + 1;
                    }
                    firstItemIndex = selectedIndex - 1;
                    if (selectedIndex == items.AllItems.Count)
                        selectedIndex = 0;
                }
                else if (keyPressed == ConsoleKey.Escape)
                    Game.RunMainMenu();

            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }

    }
}
