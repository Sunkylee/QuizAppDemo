using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuizAppDemo.DataAccess.Model;
using QuizAppDemo.DataAccess.PageViewModel;
using QuizAppDemo.DataAccess.Repository.IRepository;
using QuizAppDemo.DataAccess.Utility;

namespace QuizAppDemo
{
    public class QuizModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<Constants> _max;
        public QuizModel(IUnitOfWork unitOfWork, IOptions<Constants> max )
        {
            _unitOfWork = unitOfWork;
            _max = max;
        }

        [BindProperty]
        public QuestionViewModel Quiz { get; set; }


        public void OnGet(int userId, int quizId, int count)
        {

            Quiz = new QuestionViewModel();
           
            switch (count)
            {
                //choice of switch statement to open for extention
                case 0:

                     Quiz.Question = _unitOfWork.Question.GetAll()
                                   .Where(q => q.QuizId == quizId).OrderBy(x => Guid.NewGuid())
                                   .Take(1).FirstOrDefault();

                     break;

                default:
                     int[] attemptedQuestions = _unitOfWork.UserProgress.GetAll()
                                                .Where(x => x.UserId == userId && x.QuizId == quizId)
                                                .Select(x => x.QuestionId).ToArray();

                     Quiz.Question = _unitOfWork.Question.GetAll()
                                                .Where(q => !attemptedQuestions.Any(e => e == q.Id)
                                                 && q.QuizId == quizId).OrderBy(x => Guid.NewGuid())
                                                 .Take(1).FirstOrDefault();
                     break;
            }

            //Object rendered to view
            Quiz.Selector.count = count;
            Quiz.Selector.quizId = quizId;
            Quiz.Selector.userId = userId;
            Quiz.Selector.questionId = Quiz.Question.Id;
            Quiz.Choices.AddRange(_unitOfWork.Choices.GetAll()
                                .Where(x => x.QuestionId == Quiz.Question.Id)
                                .OrderBy(x => Guid.NewGuid()).ToList());

        }

        public IActionResult OnPost()
        {
            var obj = new ModelConstructor(Quiz.Selector);

            // Insert into UserProgress
            _unitOfWork.UserProgress.Add(obj.Progress());

            // Insert or update  activities  
            var PreviousActivity = _unitOfWork.UserActivities.GetAll()
                                      .Where(x => x.UserId == Quiz.Selector.userId && x.QuizId == Quiz.Selector.quizId)
                                      .FirstOrDefault();

            if (PreviousActivity != null)
            {
                PreviousActivity.Count = Quiz.Selector.count;

                _unitOfWork.UserActivities.Update(PreviousActivity);
            }
            else
            {
              
                _unitOfWork.UserActivities.Add(obj.Activity());
            }

            _unitOfWork.Save();

            if (Quiz.Selector.count.Equals(_max.Value.MaximumNumber))
            {
                // Display Result
                return RedirectToPage("Result", new
                {
                    userId = Quiz.Selector.userId,
                    quizId = Quiz.Selector.quizId
                });

            }

            Quiz.Selector.count = Quiz.Selector.count + 1;

            return RedirectToPage(new
            {
                Quiz.Selector.userId,
                Quiz.Selector.quizId,
                Quiz.Selector.count
            });
        }

    }
}