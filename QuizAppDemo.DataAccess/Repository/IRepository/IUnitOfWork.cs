using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserActivitiesRepository UserActivities { get; }

        IQuizRepository Quiz { get; }
        IQuestionRepository Question { get; }

        IUserProgressRepository UserProgress {get;}
        IChoiceRepository Choices { get; }
        void Save();

    }
}
