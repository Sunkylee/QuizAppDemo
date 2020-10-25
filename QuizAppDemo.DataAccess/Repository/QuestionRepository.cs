using QuizAppDemo.DataAccess.DataBase;
using QuizAppDemo.DataAccess.Model;
using QuizAppDemo.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly ApplicationDbContext _db;
        public QuestionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Question question)
        {
            _db.Update(question);
        }
    }
}
