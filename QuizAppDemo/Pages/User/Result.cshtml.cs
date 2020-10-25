using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using QuizAppDemo.DataAccess.PageViewModel;
using QuizAppDemo.DataAccess.Repository.IRepository;
using QuizAppDemo.DataAccess.Utility;

namespace QuizAppDemo
{
    public class ResultModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<Constants> _max;
        public ResultModel(IUnitOfWork unitOfWork, IOptions<Constants> max)
        {
            _unitOfWork = unitOfWork;
            _max = max;
        }

        [BindProperty]
        public ResultViewModel ResultVM { get; set; }

        public void OnGet(int userId, int quizId)
        {
            ResultVM = new ResultViewModel()
            {
                
                CandidateScore = Convert.ToDouble(_unitOfWork.UserProgress.GetAll()
                           .Where(x => x.UserId == userId && x.QuizId == quizId)
                        .Select(x => x.Score).Sum()),

                TotalScore = _max.Value.TotalScore           
            };

        }   



    }
}