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
        private Dictionary<QuestList,Quest> quests= new Dictionary<QuestList, Quest>();
        public TaskOptionData data;

        public void JumpToQuest(QuestList questName, Quest currentQuest, int questIndex)
        {
            while (!data.shouldEventStop)
            {
                if (currentQuest == null || questName != currentQuest.questName)
                {
                    Quest a = quests.Where(quest => quest.Key == questName).Take(1).ElementAt(0).Value;
                    if (questIndex != -1)
                    {
                        data = a.JumpToQuestIndex(questIndex);
                    }
                    else
                    {
                        data = a.GoToNextTask();
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

/*          
*/