using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    public struct TaskOptionData
    {
        public QuestList questName;
        public int questIndex;
        public bool shouldEventStop=false;

        public TaskOptionData(QuestList name, int questIndex)
        {
            this.questName = name;
            this.questIndex = questIndex;
        }
    }
    internal class MyTask
    {
        public string text { get; private set; }
        public string[] options { get; private set; }
        public int chosenOption { get; private set; }
        public QuestList previousQuest{ get;  set; }

        public Dictionary<string, TaskOptionData> optionList;

        private bool isReward=false;
       
        private Player player;
        private Enemy enemy;
        private Items reward;



        public MyTask(string text, Dictionary<string, TaskOptionData> choices)
        {
            this.text = text;
            optionList = choices;
            this.previousQuest = previousQuest;
        }

        public MyTask(Player player, Enemy enemy, Items reward)
        {
            this.player = player;
            this.enemy = enemy;
            this.reward = reward;
            isReward = true;
        }

        public int StartTask()
        {
            if (enemy != null)
            {
                combat();
                return -1;
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

        private bool combat()
        {
            Combat newCombat = new Combat(player,enemy);
            newCombat.RunCombat();
            player.GetExp(enemy.exp);
            player.GetItem(reward);
            return true;
        }
        private int Conversation()
        {
            QuestionMenu newChoice = new QuestionMenu(text, optionList);
            chosenOption = newChoice.ChangeOption();
            return chosenOption;
        }
    }
}
