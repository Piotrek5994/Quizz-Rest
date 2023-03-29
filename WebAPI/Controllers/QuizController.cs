using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("/api/v1/quizzes")]
    public class QuizController : Controller
    {
        private readonly IQuizUserService _service;

        public QuizController(IQuizUserService service)
        {
            _service = service;
        }
    }
}
