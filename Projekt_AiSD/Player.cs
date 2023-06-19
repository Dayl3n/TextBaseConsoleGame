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
        private int exp { get; set; }
        public int hp { get; private set; }
        private int maxHp;
        public int attack { get; private set; }
        public int armor { get; private set; }
        private string name;
        public Equipment equipment =new Equipment();
        public string[] attackList = { "swing", "Throw a stone", "block", "Shout","back" };

        public Player(string name)
        {
            this.name = name;
            exp = 0;
            hp = 10;
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

        public void GetItem(Items item)
        {
            equipment.AddItem(item);
        }
        public void GetExp(int exp)
        {
            this.exp += exp;
        }

    }
}
