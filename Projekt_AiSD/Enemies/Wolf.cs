using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD.Enemies
{
    internal class Wolf : Enemy
    {
        public Wolf(string art, int hp, int givenExp, int AttackValue, int armorValue) : base(art, hp, givenExp, AttackValue, armorValue)
        {
        }

        public override int Attack()
        {         
            return Bite();
        }

        private int Bite()
        {
            return attack / 2;
        }
    }
}
