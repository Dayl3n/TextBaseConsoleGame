using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD.Enemies
{
    internal class Kobold : Enemy
    {
        public Kobold(string art, int hp, int givenExp, int AttackValue, int armorValue) : base(art, hp, givenExp, AttackValue, armorValue)
        {
            setAttacks();
        }


        public override int Attack()
        {
            int chosenAttack = RandomNumberGenerator.GetInt32(3);
            return attackList[chosenAttack]();
        }
        private void setAttacks()
        {
            attackList.Add(WeaponAttack);
            attackList.Add(Bite);
            attackList.Add(ClawAttack);
        }
        private int WeaponAttack()
        {
            int dmg = RandomNumberGenerator.GetInt32(attack/2, (int)Math.Ceiling(attack*0.75));
            return dmg;
        }

        private int Bite()
        {          
            return attack / 2;
        }

        private int ClawAttack()
        {
            int dmg = RandomNumberGenerator.GetInt32(attack / 4, attack / 2);
            return dmg;
        }
    }
}
