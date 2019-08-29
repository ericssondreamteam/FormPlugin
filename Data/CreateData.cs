using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormPlugin.Data
{
    class CreateData
    {
        List<string> questions;
        public CreateData()
        {
            questions = new List<string>();
        }
        public void addQuestion(string question)
        {
            questions.Add(question);
        }

        public List<string> getAllQuestions()
        {
            return questions;
        }

    }
}
