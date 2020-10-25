using QuizAppDemo.DataAccess.Model;
using QuizAppDemo.DataAccess.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.PageViewModel
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Question = new Question();
            Selector = new Selector();
            Choices = new List<Choices>();
        }

        public Selector  Selector { get; set; }
        public Question Question {get; set;}

        public List<Choices> Choices { get; set; }
    }
}
