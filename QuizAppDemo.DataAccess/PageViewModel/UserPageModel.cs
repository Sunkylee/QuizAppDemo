using QuizAppDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.PageViewModel
{
   public class UserPageModel
    {

        public UserPageModel()
        {
            Quizzes = new List<Quiz>();

            Activities = new List<UserActivities>();
        }
        public int UserId { get; set; }
        public List<Quiz> Quizzes { get; set; }
        public List<UserActivities> Activities { get; set; }

   }
}
