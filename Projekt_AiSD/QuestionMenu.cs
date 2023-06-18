using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_AiSD
{
    internal class QuestionMenu : Menu
    {
        public QuestionMenu(string text, Dictionary<string, TaskOptionData> question) 
        {
            prompt = text;
            choicesListQuest = question;
        }
    }
}
