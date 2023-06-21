using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Projekt_AiSD.Plot;
using Projekt_AiSD.Item;
using Microsoft.VisualBasic.FileIO;
using Projekt_AiSD.Player_Staff;
using Projekt_AiSD.Enemies;

namespace Projekt_AiSD.DataBase
{
    internal class DataBaseReader : Game
    {
        public Dictionary<int,Items> ItemsList = new Dictionary<int, Items>();
        public Event firstEvent = new Event();
        private Player player;
        public DataBaseReader(Player player)
        {
            this.player = player;
            itemsList();
            PlotReader();
        }
        private void itemsList()
        {
            try
            {
                string itemsPath = "C:\\Users\\Kuba\\source\\repos\\Projekt_AiSD\\Items.csv";
                using (StreamReader reader = new StreamReader(itemsPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string item = reader.ReadLine();
                        string[] rowData = item.Split(';');
                        switch (rowData[1])
                        {
                            case "Potion":
                                if (rowData[2].Trim() == "HealingPotion")
                                {
                                    Items newPotion = new HealingPotion(rowData[2]);
                                    ItemsList.Add((int)int.Parse(rowData[0]), newPotion);
                                }
                                else if (rowData[2].Trim() == "DamagePotion")
                                {
                                    Items newPotion = new DamagePotion(rowData[2]);
                                    ItemsList.Add((int)int.Parse(rowData[0]), newPotion);
                                }
                                break;
                            case "Weapon":
                                string weaponArt = rowData[2].Replace(@"\r\n","\r\n");
                                Items newWeapon = new Weapon(weaponArt, rowData[3], (itemRarity)Enum.Parse(typeof(itemRarity), rowData[4]), int.Parse(rowData[5]));
                                ItemsList.Add((int)int.Parse(rowData[0]), newWeapon);
                                break;
                            case "Armor":
                                string armorArt = rowData[2].Replace(@"\r\n", "\r\n");
                                Items newArmor = new Armor(armorArt, rowData[3], (itemRarity)Enum.Parse(typeof(itemRarity), rowData[4]), int.Parse(rowData[5]));
                                ItemsList.Add((int)int.Parse(rowData[0]), newArmor);
                                break;
                        }
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

        private void PlotReader()
        {

            Quest MainQuest_object = new Quest(QuestList.MainQuest, player);
            Quest OldSword_object = new Quest(QuestList.OldSword, player);
            Quest Wagoon_object = new Quest(QuestList.Wagoon, player);
            Quest Death_object = new Quest(QuestList.Death, player);
            Quest WrongWay_object = new Quest(QuestList.WrongWay, player);

            try
            {
                string csvPlotPath = @"C:\Users\Kuba\source\repos\Projekt_AiSD\Tasks-question.csv";
                using (StreamReader reader = new StreamReader(csvPlotPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string task = reader.ReadLine();
                        string[] rowData = task.Split(';');
                        string tekst = rowData[2].Replace(@"]", "\n");
                        int numberOfAnswers = int.Parse(rowData[4]);
                        string questType = rowData[1];
                        
                        switch (questType)
                        {
                            case "MainQuest":
                            {
                                MainQuest_object.addTask(int.Parse(rowData[0]), new MyTask(tekst, Option(numberOfAnswers, rowData)));
                                break;
                            }
                            case "Wagoon":
                            {
                                Wagoon_object.addTask(int.Parse(rowData[0]), new MyTask(tekst, Option(numberOfAnswers, rowData)));
                                break;
                            }
                            case "OldSword":
                            {
                                OldSword_object.addTask(int.Parse(rowData[0]), new MyTask(tekst, Option(numberOfAnswers, rowData)));
                                break;
                            }
                            case "Death":
                            {
                                Death_object.addTask(int.Parse(rowData[0]), new MyTask(tekst, Option(numberOfAnswers, rowData)));
                                break;
                            }
                            case "WrongWay":
                            {
                                WrongWay_object.addTask(int.Parse(rowData[0]), new MyTask(tekst, Option(numberOfAnswers, rowData)));
                                break;
                            }

                        }
                    }
                }                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("plik");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            try
            {
                string csvEnemiesPath = @"C:\Users\Kuba\source\repos\Projekt_AiSD\Enemies.csv";
                using (StreamReader reader = new StreamReader(csvEnemiesPath))
                {
                    while (!reader.EndOfStream)
                    {
                        string task = reader.ReadLine();
                        string[] rowData = task.Split(';');
                        string art = rowData[3].Replace(@"\r\n", "\r\n");
                        int numberOfAnswers = int.Parse(rowData[9]);
                        string questType = rowData[1];
                        string monsterType = rowData[2];
                        Enemy enemy;
                        switch (monsterType)
                        {
                            case "Kobold":
                            {
                                    enemy = new Kobold(art, int.Parse(rowData[5]), int.Parse(rowData[6]), int.Parse(rowData[7]), int.Parse(rowData[8]));
                                break;
                            }
                            case "Wolf":
                            {
                                    enemy = new Wolf(art, int.Parse(rowData[5]), int.Parse(rowData[6]), int.Parse(rowData[7]), int.Parse(rowData[8]));
                                    break;
                            }
                            case "Dragon":
                            {
                                    enemy = new Dragon(art, int.Parse(rowData[5]), int.Parse(rowData[6]), int.Parse(rowData[7]), int.Parse(rowData[8]));
                                    break;
                            }
                            default:
                            {
                                    enemy = null;
                                    break;
                            }
                        }
                        switch (questType)
                        {
                            case "MainQuest":
                            {
                                MainQuest_object.addTask(int.Parse(rowData[0]), new MyTask(player, enemy , OptionCombat(numberOfAnswers, rowData)));
                                break;
                            }
                            case "Wagoon":
                            {
                                Wagoon_object.addTask(int.Parse(rowData[0]), new MyTask(player, enemy, OptionCombat(numberOfAnswers, rowData)));
                                break;
                            }
                        case "OldSword":
                            {
                                OldSword_object.addTask(int.Parse(rowData[0]), new MyTask(player, enemy, OptionCombat(numberOfAnswers, rowData)));
                                break;
                            }
                            case "Death":
                            {
                                Death_object.addTask(int.Parse(rowData[0]), new MyTask(player, enemy, OptionCombat(numberOfAnswers, rowData)));
                                break;
                            }
                            case "WrongWay":
                            {
                                WrongWay_object.addTask(int.Parse(rowData[0]), new MyTask(player, enemy, OptionCombat(numberOfAnswers, rowData)));
                                break;
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("plik");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            MainQuest_object.SortTaskList();
            Wagoon_object.SortTaskList();
            OldSword_object.SortTaskList();
            WrongWay_object.SortTaskList();
            Death_object.SortTaskList();

            firstEvent.AddQuest(MainQuest_object);
            firstEvent.AddQuest(Wagoon_object);
            firstEvent.AddQuest(OldSword_object);
            firstEvent.AddQuest(Death_object);
            firstEvent.AddQuest(WrongWay_object);


        }

        private Dictionary<string, TaskOptionData> Option(int numberOfAnswers, string[] data)
        {
            Dictionary<string, TaskOptionData> option = new Dictionary<string, TaskOptionData>();

            int help = 5;
            for (int i = 0; i < numberOfAnswers; i++)
            {
                option.Add(data[help], new TaskOptionData((QuestList)Enum.Parse(typeof(QuestList), data[help + 1]), int.Parse(data[help + 2])));
                help += 3;
            }
            return option;
        }
        private Dictionary<string, TaskOptionData> OptionCombat(int numberOfAnswers, string[] data)
        {
            Dictionary<string, TaskOptionData> option = new Dictionary<string, TaskOptionData>();

            int help = 10;
            for (int i = 0; i < numberOfAnswers; i++)
            {
                option.Add(data[help], new TaskOptionData((QuestList)Enum.Parse(typeof(QuestList), data[help + 1]), int.Parse(data[help + 2])));
                help += 3;
            }
            return option;
        }


    }
}