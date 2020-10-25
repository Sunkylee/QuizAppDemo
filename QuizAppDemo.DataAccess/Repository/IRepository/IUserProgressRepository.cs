using QuizAppDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository.IRepository
{
   public interface IUserProgressRepository : IRepository<UserProgress>
   {
        void Update(UserProgress userProgress);
    }
}
