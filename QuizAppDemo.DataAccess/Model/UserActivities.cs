using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuizAppDemo.DataAccess.Model
{
    public class UserActivities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserInfo User { get; set; }
        [Required]
        public int QuizId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        [Required]
        public string Status { get; set; }
        [Required]
        public int Count { get; set; }


    }
}
