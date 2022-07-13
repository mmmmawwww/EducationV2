using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.WEB.Models
{
    public class TestViewModel
    {
        public string TestName { get; set; }
        public List<QuestionViewModel> TestQuestions { get; set; }

        public List<Answer> Answers { get; set; }
    }

    public class Answer
    {
        public int QuestionID { get; set; }
        public string answer { get; set; }
    }

    public class TestResultViewModel
    {
        public int Mark { get; set; }
        public List<string> WrongAnswers { get; set; }
    }
}