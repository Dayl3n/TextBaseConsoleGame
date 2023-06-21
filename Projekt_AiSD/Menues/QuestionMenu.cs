using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_AiSD.Plot;

namespace Projekt_AiSD.Menues
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
