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
        public Weapon equipedWeapon = null;
        public Armor equipedArmor = null;
        public int itemIndex;


        public void equipItem(Items item,Player player)
        {
            if(item.GetType()==typeof(Weapon)) 
            {
                equipedWeapon = (Weapon)item;
            }
            if (item.GetType() == typeof(Armor))
            {
                equipedArmor = (Armor)item;
            }
            item.Equip(player);
        }

        public void useItem(Items item)
        {
            AllItems.Remove(item);
        }

        public void DisplayEquipmentMenu()
        {
            EqMenu newmenu = new EqMenu(this);
            int seletecedint = newmenu.ChangeOption();
        }

        public void AddItem(Items item)
        {
            AllItems.Add(item);
        }
    }
}
