using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt_AiSD.QuestList;

namespace Projekt_AiSD
{
    internal class Event
    {
        private Dictionary<QuestList, Quest> quests = new Dictionary<QuestList, Quest>();
        private TaskOptionData data;
        private Quest currentQuest;

        public void SetupAndStartQuesting(TaskOptionData StartingData)
        {
            data = StartingData;
            currentQuest = quests.Where(quest => quest.Key == data.questName).Take(1).ElementAt(0).Value;
            data = currentQuest.JumpToQuestIndex(data.questIndex);
            StartQuestFlow();
        }

        public void StartQuestFlow()
        {
            while (!data.shouldEventStop)
            {
                if (data.questName != currentQuest.questName)
                {
                    currentQuest = quests.Where(quest => quest.Key == data.questName).Take(1).ElementAt(0).Value;
                    if (data.questIndex != -1)
                    {
                        data = currentQuest.JumpToQuestIndex(data.questIndex);
                    }
                    else
                    {
                        data = currentQuest.GoToNextTask();
                    }
                }
                else
                {
                    data = currentQuest.GoToNextTask();
                }
            }
        }

        public void AddQuest(Quest quest)
        {
            quests.Add(quest.questName, quest);
        }
    }
}
