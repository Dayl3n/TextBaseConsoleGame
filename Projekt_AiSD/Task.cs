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
    internal class Task
    {
        public string text { get; private set; }
        public string[] options { get; private set; }
        public int chosenOption { get; private set; }
        public QuestList previousQuest{ get;  set; }

        public Dictionary<string, TaskOptionData> optionList;



        public Task(string text, Dictionary<string, TaskOptionData> choices)
        {
            this.text = text;
            optionList = choices;
            this.previousQuest = previousQuest;
        }

        public int StartTask()
        {      
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
            //TODO
            return false;
        }
        private int Conversation()
        {
            QuestionMenu newChoice = new QuestionMenu(text, optionList);
            chosenOption = newChoice.ChangeOption();
            return chosenOption;
        }
    }
}
