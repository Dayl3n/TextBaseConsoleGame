using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD.Item
{
    internal class DamagePotion : Potion
    {
        public DamagePotion(string name) : base(name)
        {
        }

        public int Dmg()
        {
            if (rarity == itemRarity.legendary)
                return 1000;
            switch (size)
            {
                case itemSize.small:
                    return 2;
                case itemSize.medium:
                    return 5;
                case itemSize.large:
                    return 8;
                default:
                    return 0;
            }
        }
    }
}
