using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Projekt_AiSD
{
    internal class CombatMenu : Menu
    {
        private string[] options = { "Attack", "Items", "Run" };
        private Enemy enemy;
        private Player player;
        public CombatMenu(Player player, Enemy enemy) 
        {
            this.enemy = enemy;
            this.player = player;
        }
        public CombatMenu(Player player, Enemy enemy, string[] options)
        {
            this.enemy = enemy;
            this.player = player;
            this.options = options;
        }

        protected override void DisplayOptions()
        {
            WriteLine(enemy.art);
            string prefix = "";
            WriteLine(new String('-', 70));
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    prefix = ">";
                }
                else
                {
                    prefix = " ";
                }
                WriteLine($"|{new String(' ', 65 - options[i].Length)}{prefix}{options[i]}{new String(' ', 3)}|");

            }
            WriteLine(new String('-', 70));
            WriteLine($"player hp: {player.hp}      enemy hp:{enemy.hp}");
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
                        selectedIndex = options.Length - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                        selectedIndex = 0;
                }
            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }
    }
}
