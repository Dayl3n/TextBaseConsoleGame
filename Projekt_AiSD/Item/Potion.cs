using Projekt_AiSD.Player_Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD.Item
{
    internal class Potion : Items
    {
        protected static string potionArt = " (___)\r\n      <   >\r\n       ) (\r\n      /`-.\\\r\n     /     \\\r\n    / _    _\\\r\n   :,' `-.' `:\r\n   |         |\r\n   :         ;\r\n    \\       /\r\n     `.___.'";
        public Potion(string name) : base(potionArt, name, itemRarity.common, false)
        {

        }
        public new void getName()
        {
            Console.WriteLine("potion " + name);
        }

        public override void Equip(Player player)
        {
            Console.WriteLine("U can't equip potions");
        }

        virtual public int UsePotion()
        {
            return 3;
        }
    }
}
