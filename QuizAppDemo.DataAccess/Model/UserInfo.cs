using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizAppDemo.DataAccess.Model
{
   public class UserInfo
   {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
      
    }
}
