using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class Weapon : Items
    {
        private int modifier = 0;
        public Weapon(string art, string name, int rarity, int size, int value) : base(art, name, rarity, size, false)
        {
            modifier = value;
        }

        public new void getName()
        {
            Console.WriteLine("sword " + name);
        }

        public override void Equip(Player player)
        {
            isequpid = !isequpid;
            player.AddAttackModifier(modifier);
        }
    }
}
