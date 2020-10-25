using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuizAppDemo.DataAccess.Model
{
   public class Choices
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public double PointValue { get; set; }
    }
}
