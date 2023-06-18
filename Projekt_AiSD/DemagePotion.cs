using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class DemagePotion : Potion
    {
        public DemagePotion(string name, int rarity, int size) : base(name, rarity, size)
        {          
        }
        
        public int Dmg()
        {
            if (itemRarity == "legendary")
                return 1000;
            switch (itemSize)
            {
                case "small":
                    return 2;
                case "medium":
                    return 5;
                case "large":
                    return 8;
                default:
                    return 0;
            }
        }
    }
}
