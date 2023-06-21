using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_AiSD.Item;
using Projekt_AiSD.Player_Staff;
using static System.Console;


namespace Projekt_AiSD.Menues
{
    internal class EqMenu
    {
        public int firstItemIndex = 0;
        public int selectedIndex = 1;
        public int lastItemIndex = 2;
        private Player player;
        public EqMenu( Player player)
        {
            this.player = player;          
        }

        protected void DisplayOptions()
        {
            SetCursorPosition(10, 3);
            Write(player.name);
            for (int i = 0; i<player.stats.Count;i++)
            {
                SetCursorPosition(10, i + 5);
                Write($"{player.stats.ElementAt(i).Key.name}: {player.stats.ElementAt(i).Key.value}");
            }
            if (Equipment.equipedWeapon != null)
            {
                string[] arts = Equipment.equipedWeapon.art.Split("\r\n");
                for (int i = 0; i < arts.Length; i++)
                {
                    string s2 = arts[i];
                    SetCursorPosition(75, i + 2);
                    Write(s2);
                }
            }
            if (Equipment.equipedArmor != null)
            {
                string dsa = "\\_              _/\r\n] --__________-- [\r\n|       ||       |\r\n\\       ||       /\r\n [      ||      ]\r\n |______||______|\r\n |------..------|\r\n ]      ||      [\r\n  \\     ||     /\r\n   [    ||    ]\r\n   \\    ||    /\r\n    [   ||   ]\r\n     \\__||__/\r\n        --";
                string[] art2 = Equipment.equipedArmor.art.Split("\r\n");
                for (int i = 0; i < art2.Length; i++)
                {
                    string s2 = art2[i];
                    SetCursorPosition(100, i + 2);
                    Write(s2);
                }
            }
            string middleLine = new String('|', 22);
            for (int i = 0;i < middleLine.Length;i++)
            {
                SetCursorPosition(WindowWidth / 2 - 7, i);
                Write(middleLine[i]);
            }
            Write("\n");
            WriteLine(new String('_',WindowWidth));
            if (Equipment.AllPlayerItems.Count > 0)
            {
                Equipment.AllPlayerItems[selectedIndex].getItemArt();
                ForegroundColor = ConsoleColor.White;
                Write("                    ");
                Equipment.AllPlayerItems[firstItemIndex].getItemName();
                ForegroundColor = ConsoleColor.White;
                Write("                      [");
                Equipment.AllPlayerItems[selectedIndex].getItemName();
                ForegroundColor = ConsoleColor.White;
                Write("]                      ");
                Equipment.AllPlayerItems[lastItemIndex].getItemName();
            }
            ResetColor();
        }
        public int ChangeOption()
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
                    lastItemIndex = selectedIndex;
                    selectedIndex = firstItemIndex;
                    firstItemIndex--;
                    if (firstItemIndex < 0)
                    {
                        firstItemIndex = Equipment.AllPlayerItems.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    firstItemIndex = selectedIndex;
                    selectedIndex = lastItemIndex;
                    lastItemIndex++;
                    if (lastItemIndex == Equipment.AllPlayerItems.Count)
                    {
                        lastItemIndex = 0;
                    }
                }
                else if (keyPressed == ConsoleKey.Escape)
                    Game.RunMainMenu();

            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }

    }
}
