using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_AiSD.Item;
using Projekt_AiSD.Menues;

namespace Projekt_AiSD.Player_Staff
{
    internal class Equipment
    {
        public static List<Items> AllPlayerItems = new List<Items>();
        public static EqMenu eqMenu;
        private static Player player;
        public static Weapon equipedWeapon;
        public static Armor equipedArmor;
        public int itemIndex;
        public static int selectedIndex;

        public Equipment(Player player)
        {
            Equipment.player = player;
            eqMenu = new EqMenu(player);
        }
        private static void equipItem(Items item)
        {
            if (item.GetType() == typeof(Weapon))
            {
                equipedWeapon = (Weapon)item;
            }
            if (item.GetType() == typeof(Armor))
            {
                equipedArmor = (Armor)item;
            }
            item.Equip(player);
        }

        private static void useItem(Items item)
        {
            AllPlayerItems.Remove(item);
        }

        public static void DisplayEquipmentMenu()
        {           
            selectedIndex = eqMenu.ChangeOption();
            if(AllPlayerItems.Count > 0) { 
                if (AllPlayerItems[selectedIndex].GetType()==typeof(Weapon)|| AllPlayerItems[selectedIndex].GetType() == typeof(Armor))
                {
                    equipItem(AllPlayerItems[selectedIndex]);
                }
                else
                {
                    useItem(AllPlayerItems[selectedIndex]);
                }
            }
        }

        public void AddItem(Items item)
        {
            AllPlayerItems.Add(item);
        }
    }
}
