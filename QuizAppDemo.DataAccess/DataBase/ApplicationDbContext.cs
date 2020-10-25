using Microsoft.EntityFrameworkCore;
using QuizAppDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserInfo> User { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<UserActivities> UserActivities { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }
        public DbSet<Choices> Choices { get; set; }

    }
}
