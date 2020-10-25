using QuizAppDemo.DataAccess.DataBase;
using QuizAppDemo.DataAccess.Model;
using QuizAppDemo.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private readonly ApplicationDbContext _db;
        public QuizRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Quiz quiz)
        {
            _db.Update(quiz);
        }
    }
}
