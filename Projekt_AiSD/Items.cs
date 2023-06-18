using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    
    internal class Items
    {                
        //public itemRarity rarity { get; private set;}
        //protected itemSize size;
        public string name { get; protected set; }
        public string art { get; protected set; }
        public bool isequpid;

        protected string[] rarity = { "common", "uncommon", "rare", "epic", "legendary" };
        protected string[] size = { "small", "medium", "large" };
        public string itemRarity;
        protected string itemSize;


        public Items(string art,string name, int rarityIndex, int sizeIndex, bool isequpable) 
        {
            this.art = art;
            this.name = name;
            this.itemRarity = rarity[rarityIndex];
            this.isequpid = isequpable;
            this.itemSize = size[sizeIndex];
        }

        public void getItemInfo()
        {
            Console.Write(art);
            Console.WriteLine($"{name}\n{itemRarity}\n{itemSize}");
        }

        virtual public void Equip(Player player)
        {
        }
    }
}
