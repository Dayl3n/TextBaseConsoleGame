using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class Equipment
    {
        public List<Items> AllItems = new List<Items>();
        public List<Items> equipedItems = new List<Items>();       
        public List<Items> unequipedItems = new List<Items>();
        public int itemIndex;


        public void equipItem(Items item,Player player)
        {
            unequipedItems.Remove(item);
            equipedItems.Add(item);
            item.Equip(player);
        }

        public void useItem(Items item)
        {
            unequipedItems.Remove(item);
        }

        public void DisplayEquipmentMenu()
        {
            foreach(var item in AllItems)
            {
                Console.Write(item.art);
            }
        }
    }
}
