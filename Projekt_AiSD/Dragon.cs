using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class Dragon : Enemy
    {
        public Dragon(string art, int hp, int givenExp, int AttackValue, int armorValue) : base(art, hp, givenExp, AttackValue, armorValue)
        {
        }

        public new int Attack()
        {
            attackList.Clear();
            setAttacks();
            int chosenAttack = RandomNumberGenerator.GetInt32(3);
            return attackList[chosenAttack]();
        }

        private void setAttacks()
        {
            attackList.Add(DragonBreath);
            attackList.Add(TailSwing);
            attackList.Add(Claws);
        }
        private int DragonBreath()
        {
            int dmg = RandomNumberGenerator.GetInt32(attack, (int)(attack*1.5));
            return dmg;
        }
        private int TailSwing()
        {
            int dmg = RandomNumberGenerator.GetInt32(attack / 2, attack);
            return dmg;
        }
        private int Claws()
        {
            int dmg = attack;
            return dmg;
        }
    }
}
