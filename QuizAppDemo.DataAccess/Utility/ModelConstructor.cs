using QuizAppDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppDemo.DataAccess.Utility
{
    public  class ModelConstructor
    {
        public Selector _selector;
        public  ModelConstructor(Selector selector)
        {
            _selector = selector;
        }
        public  UserActivities Activity() {

            var resp = new UserActivities();

            resp.UserId = _selector.userId;
            resp.QuizId = _selector.quizId;
            resp.Count = _selector.count;
            resp.Status = _selector.count < 10 ? "In Progress" : "Completed";

            return resp;
        
        }

        public UserProgress Progress()
        {
            var resp = new UserProgress();

            resp.UserId = _selector.userId;
            resp.QuizId = _selector.quizId;
            resp.Score = _selector.score;
            resp.QuestionId = _selector.questionId; ;

            return resp;

        }


    }
}
