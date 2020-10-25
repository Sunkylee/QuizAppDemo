using System;
using System.Collections.Generic;
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
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<UserInfo> _userDetails;
        private readonly IOptions<Constants> _max;
        public IndexModel(IUnitOfWork unitOfWork,
            IOptions<UserInfo> userDetails,
            IOptions<Constants> max)
        {
            _unitOfWork = unitOfWork;
            _userDetails = userDetails;
            _max = max;
        }

        [BindProperty]
        public UserPageModel UserVM { get; set; }
        public void OnGet()
        {

            //Assume Login with UserId 
            int userId = _userDetails.Value.Id;


            UserVM = new UserPageModel()
            {
                UserId = userId,
                Activities = _unitOfWork.UserActivities.GetAll(x => x.UserId == userId).ToList(),
                Quizzes = _unitOfWork.Quiz.GetAll().ToList()
            };

        }

        public IActionResult OnPost(int quizId)
        {

            int count = _unitOfWork.UserActivities.GetAll().Where
                                   (x => x.UserId == UserVM.UserId && x.QuizId == quizId)
                                   .Select(x => x.Count).FirstOrDefault();

            if (count.Equals(_max.Value.MaximumNumber))
            {
                return RedirectToPage("/User/Result", new
                {
                    userId = UserVM.UserId,
                    quizId = quizId

                });

            }

            return RedirectToPage("/User/Quiz", new
            {
                userId = UserVM.UserId,
                quizId = quizId,
                count = count == 0 ? 1 : count
        });

        }
    }
}