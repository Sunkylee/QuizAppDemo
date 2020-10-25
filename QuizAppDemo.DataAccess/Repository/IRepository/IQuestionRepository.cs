using QuizAppDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository.IRepository
{
   public interface IQuestionRepository : IRepository<Question>
   {
        void Update(Question question);
    }
}
