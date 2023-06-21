using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_AiSD.Enemies;
using Projekt_AiSD.Item;
using Projekt_AiSD.Menues;
using Projekt_AiSD.Player_Staff;

namespace Projekt_AiSD.Plot
{
    public struct TaskOptionData
    {
        public QuestList questName;
        public int questIndex;
        public bool shouldEventStop = false;

        public TaskOptionData(QuestList name, int questIndex)
        {
            questName = name;
            this.questIndex = questIndex;
        }
    }
    internal class MyTask
    {
        public string text { get; private set; }
        public string[] options { get; private set; }
        public int chosenOption { get; private set; }
        public Dictionary<string, TaskOptionData> optionList;
        private bool isReward = false;

        private Player player;
        private Enemy enemy;
        private Items reward;



        public MyTask(string text, Dictionary<string, TaskOptionData> choices)
        {
            this.text = text;
            optionList = choices;
        }

        public MyTask(Player player, Enemy enemy, Dictionary<string, TaskOptionData> choices, Items reward = null)
        {
            this.player = player;
            this.enemy = enemy;
            this.reward = reward;
            isReward = true;
            optionList = choices;
        }

        public int StartTask()
        {
            if (enemy != null)
            {
                chosenOption = combat();
                return chosenOption;
            }
            else
                chosenOption = Conversation();
            return chosenOption;
        }


        public void addText(string text, string[] options)
        {
            this.text = text;
            this.options = options;
        }

        private int combat()
        {
            Combat newCombat = new Combat(player, enemy);
            int chosenOptionCombat=newCombat.RunCombat();
            player.GetExp(enemy.exp);
            //player.GetItem(reward);
            return chosenOption;
        }
        private int Conversation()
        {
            QuestionMenu newChoice = new QuestionMenu(text, optionList);
            chosenOption = newChoice.ChangeOption();
            return chosenOption;
        }
    }
}
