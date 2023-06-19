using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Transactions;

namespace Projekt_AiSD
{
    
    internal class Quest
    {

        public Player character;
        private List<MyTask> taskList = new List<MyTask>();
        public int chosenOption;
        public QuestList questName;
        public int questIndex;

        public Quest(QuestList name,Player player)
        {
            this.questName = name;
            character = player;
        }


        public void addTask(MyTask task)
        {
            taskList.Add(task);
        }

        public TaskOptionData JumpToQuestIndex(int index)
        {
            questIndex=index;
            chosenOption=taskList[questIndex].StartTask();
            return taskList[questIndex].optionList.ElementAt(chosenOption).Value;
        }

        public TaskOptionData GoToNextTask()
        {
            if (questIndex == taskList.Count - 1)
            {
                Game.GameOver();//w zależności od questName różne zachowanie (sideQuest Wraca do MainQuesta jeśli MainQuest to śmierć/reset od pocztaku)
                TaskOptionData newTaskOptionData = new TaskOptionData();
                newTaskOptionData.shouldEventStop = true;
                return newTaskOptionData;
            }
            else
            {
                questIndex++;
                chosenOption=taskList[questIndex].StartTask();
                return taskList[questIndex].optionList.ElementAt(chosenOption).Value;
            }
        }
    }
}
