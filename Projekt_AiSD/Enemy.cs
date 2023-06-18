using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class Enemy
    {
        public int hp { get; protected set; }
        public int  exp { get; protected set; }
        public int attack { get; protected set; }
        public int armor { get; protected set; }
        public string art;
        protected List<Func<int>> attackList = new List<Func<int>>();
        public Enemy(string art, int hp, int givenExp, int AttackValue, int armorValue) 
        {
            this.hp = hp;
            exp= givenExp;
            attack= AttackValue;
            armor= armorValue;
            this.art = art;
        }

        public void changeHp(int value)
        {
            hp += value;
        }

        public int Attack()
        {
            return attack;
        }       
    }
}
