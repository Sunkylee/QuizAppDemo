using QuizAppDemo.DataAccess.DataBase;
using QuizAppDemo.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository
{
    public class UnitOfWork  : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            UserActivities = new UserActivitiesRepository(_db);
            Quiz = new QuizRepository(_db);
            Question = new QuestionRepository(_db);
            Choices = new ChoiceRepository(_db);
            UserProgress = new UserProgressRepository(_db);
        }

        public IUserActivitiesRepository UserActivities { get; private set; }
        public IQuizRepository Quiz { get; private set; }
        public  IQuestionRepository Question { get; private set; }
        public IChoiceRepository Choices { get; private set; }
        public IUserProgressRepository UserProgress { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
