using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class HealingPotion : Potion
    {
        public HealingPotion(string name, itemRarity rarity, itemSize size) : base(name, rarity, size)
        {
        }

        public int Heal()
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
