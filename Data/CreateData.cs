using System.Collections.Generic;

namespace FormPlugin.Data
{
    public class CreateData
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
