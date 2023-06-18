using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class Player
    {
        public int exp { get; set; }
        public int hp { get; private set; }
        private int maxHp;
        public int attack { get; private set; }
        public int armor { get; private set; }
        private string name;
        public Equipment equipment { get; set; }
        public string[] attackList = { "swing", "Throw a stone", "block", "Shout","back" };

        public Player(string name)
        {
            this.name = name;
            this.exp = 0;
            this.hp = 10;
            maxHp = hp;
            attack = 10;
            armor = 10;
        }

        public void changeHp(int value)
        {
            hp += value;
            if (hp <= 0)
                Game.GameOver();
        }

        public void AddArmorModifier(int modifier)
        {
            armor = armor + modifier;
        }

        public void AddAttackModifier(int modifier)
        {
            attack = attack + modifier;
        }


    }
}
