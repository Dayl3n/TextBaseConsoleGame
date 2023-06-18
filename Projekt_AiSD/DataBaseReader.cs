using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt_AiSD
{
    internal class DataBaseReader
    {
        public List<Items> weaponList = new List<Items>();
        public void itemsList()
        {
            try
            {
                string itemsPath = "C:\\Users\\Kuba\\source\\repos\\Projekt_AiSD\\items.txt";
                string fileContent = File.ReadAllText(itemsPath);
                string[] lines = fileContent.Split(new string[] { "\\r\\n" }, StringSplitOptions.None);

               

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');

                    if (data.Length == 5)
                    {
                        try
                        {
                            string art = data[1];
                            Console.WriteLine($"{art}");
                            Console.ReadKey();
                            string name = data[1];
                            Console.WriteLine($"{name}");
                            Console.ReadKey();
                            int rarity = int.Parse(data[2]);
                            int size = int.Parse(data[3]);
                            int value = int.Parse(data[4]);

                            Console.WriteLine($"{art}\n {name}\n{rarity}\n{size}\n{value}");
                            Console.ReadKey();

                            Weapon weapon = new Weapon(art, name, rarity, size, value);
                            weaponList.Add(weapon);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Nieprawidłowy format danych: {line}");
                            Console.ReadKey();
                        }
                    }
                }

                foreach (Weapon weapon in weaponList)
                {
                    Console.WriteLine($"Art: {weapon.art}");
                    Console.WriteLine($"Name: {weapon.name}");
                    Console.WriteLine($"Rarity: {weapon.itemRarity}");
                    Console.ReadKey(true);
                }


            }
            catch (FileNotFoundException e)           
            {
                Console.WriteLine("plik");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
