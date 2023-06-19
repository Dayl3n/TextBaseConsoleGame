using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt_AiSD
{
    internal class DataBaseReader : Game
    {
        public List<Items> weaponList = new List<Items>();
        public DataBaseReader()
        {
            itemsList();
        }
        private void itemsList()
        {
            try
            {
                string itemsPath = "C:\\Users\\Kuba\\source\\repos\\Projekt_AiSD\\weapons.csv";
                using (StreamReader reader = new StreamReader(itemsPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string item = reader.ReadLine();
                        string[] rowData = item.Split(';');
                        string art = rowData[0].Replace(@"\r\n","\r\n");
                        Weapon newWeapon = new Weapon(art, rowData[1], (itemRarity)Enum.Parse(typeof(itemRarity), rowData[2]), (itemSize)Enum.Parse(typeof(itemSize), rowData[3]), int.Parse(rowData[4]));
                        weaponList.Add(newWeapon);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("plik");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private Event PlotReader()
        {
            Event newEvent = new Event();
            Quest MainQuest = new Quest(QuestList.MainQuest, player);
            Quest OldSword = new Quest(QuestList.OldSword, player);
            Quest Wagoon = new Quest(QuestList.Wagoon, player);
            try
            {
                string csvPlotPath = @"";
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("plik");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            return newEvent;
        }
    }
}
