using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuizAppDemo.DataAccess.Model
{
   public class Question
   {
        public int Id { get; set; }
        public string Text { get; set; }

        public int QuizId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }


   }
}
