using Projekt_AiSD.Player_Staff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Projekt_AiSD.Item
{

    internal class Items
    {
        public itemRarity rarity { get; private set; }
        protected itemSize size;
        public string name { get; protected set; }
        public string art { get; protected set; }
        private bool isequpid;
        public int modifier;



        public Items(string art, string name, itemRarity rarity, bool isequpable)
        {
            this.art = art;
            this.name = name;
            this.rarity = rarity;
            isequpid = isequpable;
            this.size = size;
        }

        public void getItemArt()
        {
            string[] dsadas = art.Split("\r\n");
            foreach (string s in dsadas)
            {
                WriteLine("                                                  " + s);
            }
        }
        public void getItemName()
        {
            switch (rarity)
            {
                case itemRarity.common:
                    {
                        ForegroundColor = ConsoleColor.White;
                        Write(name);
                        break;
                    }
                case itemRarity.uncommon:
                    {
                        ForegroundColor = ConsoleColor.Green;
                        Write(name);
                        break;
                    }
                case itemRarity.rare:
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        Write(name);
                        break;
                    }
                case itemRarity.epic:
                    {
                        ForegroundColor = ConsoleColor.Magenta;
                        Write(name);
                        break;
                    }
                case itemRarity.legendary:
                    {
                        ForegroundColor = ConsoleColor.DarkYellow;
                        Write(name);
                        break;
                    }
            }
        }



        virtual public void Equip(Player player)
        {
        }
    }
}
