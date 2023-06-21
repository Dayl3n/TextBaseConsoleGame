using Projekt_AiSD.Player_Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD.Item
{
    internal class Armor : Items
    {

        public Armor(string art, string name, itemRarity rarity, int bonus) : base(art, name, rarity, false)
        {
            modifier = bonus;
        }

        public override void Equip(Player player)
        {
            player.AddArmorModifier(modifier);
        }
    }
}
