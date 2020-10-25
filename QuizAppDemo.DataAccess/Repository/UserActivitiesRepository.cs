using QuizAppDemo.DataAccess.DataBase;
using QuizAppDemo.DataAccess.Model;
using QuizAppDemo.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository
{
    public class UserActivitiesRepository : Repository<UserActivities>, IUserActivitiesRepository
    {
        private readonly ApplicationDbContext _db;
        public UserActivitiesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(UserActivities userActivities)
        {
            _db.Update(userActivities);
        }
    }
}
