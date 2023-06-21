using Projekt_AiSD.Player_Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD.Item
{
    internal class Weapon : Items
    {
        public Weapon(string art, string name, itemRarity rarity, int value) : base(art, name, rarity, false)
        {
            modifier = value;
        }

        public new void getName()
        {
            Console.WriteLine("sword " + name);
        }

        public override void Equip(Player player)
        {
            player.AddAttackModifier(modifier);
        }
    }
}
