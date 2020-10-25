using QuizAppDemo.DataAccess.DataBase;
using QuizAppDemo.DataAccess.Model;
using QuizAppDemo.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository
{
    public class ChoiceRepository : Repository<Choices>, IChoiceRepository
    {
        private readonly ApplicationDbContext _db;
        public ChoiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Choices choices)
        {
            _db.Update(choices);
        }
    }
}
