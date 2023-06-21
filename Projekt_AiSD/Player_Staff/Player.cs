using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Projekt_AiSD.Item;

namespace Projekt_AiSD.Player_Staff
{
    internal struct PlayerStatData
    {
        public int value;
        public string name;
        
        public PlayerStatData(string name, int value)
        {
            this.value = value;
            this.name = name;
        }
    }
    internal class Player
    {
        private int exp { get; set; }
        public PlayerStatData hp = new PlayerStatData("Health Points", 20);
        private PlayerStatData maxHp;
        private PlayerStatData strenght;
        private PlayerStatData agility = new PlayerStatData("Agility", 10);
        private PlayerStatData wisdom = new PlayerStatData("Wisdom", 5);
        public PlayerStatData attack = new PlayerStatData("Attack", 10);
        public PlayerStatData armor = new PlayerStatData("Armor", 10);
        public int playerLvl;
        private int nextLvl;
        public string name;
        public Equipment equipment;
        public Dictionary<PlayerStatData, Action> stats = new Dictionary<PlayerStatData, Action>();
        public string[] attackList = { "swing", "Throw a stone", "block", "Shout", "back" };

        public int Strenght
        {
            get { return strenght.value; }
            set
            {
                strenght.value = value;
                hp.value += (int)Math.Floor(strenght.value * 0.5);
                armor.value += (int)Math.Floor(strenght.value / 4.0);
                maxHp = hp;
            }
        }

        public int Agility
        {
            get { return agility.value; }
            set
            {
                agility.value = value;
                attack.value += (int)Math.Floor(agility.value * 0.5);
                armor.value += (int)Math.Ceiling(agility.value / 4.0);
            }
        }

        public Player(string name)
        {
            playerLvl = 1;
            this.name = name;
            exp = 0;
            nextLvl = playerLvl * 100;
            strenght = new PlayerStatData("Strenght", 10);
            agility = new PlayerStatData("Agility", 10);
            wisdom = new PlayerStatData("Wisdom", 5);



            stats.Add(hp, IncreaseHealth);
            stats.Add(agility, IncreaseAgility);
            stats.Add(strenght, IncreaseStrenght);
            stats.Add(wisdom, IncreaseWisdom);
            stats.Add(attack, IncreaseAttack);
            stats.Add(armor, () => { Console.WriteLine("u cant directly increase your armor"); });
            equipment = new Equipment(this);
        }

        public void changeHp(int value)
        {
            hp.value += value;
            if (hp.value <= 0)
                Game.GameOver();
        }

        public void AddArmorModifier(int modifier)
        {
            armor.value = armor.value + modifier;
        }

        public void AddAttackModifier(int modifier)
        {
            attack.value = attack.value + modifier;
        }

        public void GetItem(Items item)
        {
            equipment.AddItem(item);
        }
        public void GetExp(int exp)
        {
            this.exp += exp;
        }

        private void IncreaseAgility()
        {
            Agility++;
        }

        private void IncreaseStrenght()
        {
            Strenght++;
        }

        private void IncreaseHealth()
        {
            hp.value++;
            maxHp.value++;
        }

        private void IncreaseAttack()
        {
            attack.value++;
        }

        private void IncreaseWisdom()
        {
            wisdom.value++;
        }

    }
}
