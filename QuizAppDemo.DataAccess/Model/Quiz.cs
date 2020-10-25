using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizAppDemo.DataAccess.Model
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
