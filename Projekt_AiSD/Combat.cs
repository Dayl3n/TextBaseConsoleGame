using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class Combat
    {
        private Enemy enemy;
        private Player player;
        private string[] playerOptions = { "Attack", "Items", "Run" };
        //private string[] playerAttack;
        private int selectedOption;
        private Menu combatMenu;
        private Menu attackMenu;
        

        public Combat(Player player, Enemy enemy) 
        {
            this.player = player;
            this.enemy = enemy;
            combatMenu = new CombatMenu(this.player, this.enemy);
        }

        public void RunCombat()
        {
            while (enemy.hp != 0)
            {
                selectedOption = combatMenu.ChangeOption();
                switch (selectedOption)
                {
                    case 0:
                        Attack();
                        break;
                    case 1:
                        Items();
                        break;
                    case 2:
                        Run();
                        break;
                }
            }
        }
        private void Attack()
        {
            attackMenu = new CombatMenu(player, enemy, player.attackList);
            selectedOption = attackMenu.ChangeOption();
            switch (selectedOption)
            {
                case 0:
                    Swing();
                    break;
                case 1:
                    ThrowStone();
                    break;
                case 2:
                    Block();
                    break;
                case 3:
                    Shout();
                    break;
                case 4:
                    RunCombat();
                    break;
            }
        }
        private void Items()
        {
            Console.WriteLine("EQ");
        }
        private void Run()
        {
            Event test = new Event();    
        }


        private void Swing()
        {
            int dmg = RandomNumberGenerator.GetInt32(player.attack / 2, player.attack);            
            enemy.changeHp(-1*dmg);
            player.changeHp(-enemy.Attack());
        }
        private void ThrowStone()
        {
            int dmg = RandomNumberGenerator.GetInt32(player.attack / 4, player.attack / 2);
            enemy.changeHp(-1 * dmg);
            player.changeHp(-enemy.Attack());
        }

        private void Block()
        {
            int tempEnemyAttack = enemy.Attack()-player.armor/5;
            player.changeHp(-1*tempEnemyAttack);
        }
        private void Shout()
        {
            int chancesToScare = RandomNumberGenerator.GetInt32(101);
            if (chancesToScare > 99)
                enemy.changeHp(-10000);
            player.changeHp(-enemy.Attack());
        }
    }
}
