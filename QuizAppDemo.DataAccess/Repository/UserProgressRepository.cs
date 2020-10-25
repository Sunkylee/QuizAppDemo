using QuizAppDemo.DataAccess.DataBase;
using QuizAppDemo.DataAccess.Model;
using QuizAppDemo.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository
{
    public class UserProgressRepository : Repository<UserProgress>, IUserProgressRepository
    {
        private readonly ApplicationDbContext _db;
        public UserProgressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(UserProgress userProgress)
        {
            _db.Update(userProgress);
        }
    }
}
