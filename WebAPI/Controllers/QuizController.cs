using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

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
        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            var quiz = _service.FindQuizById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(QuizDto.of(quiz));

        }

        [HttpGet]
        public IEnumerable<QuizDto> FindAll(int id)
        {
            var AllQuizes = _service.FindAllQuizzes(id);
            List<QuizDto> quizDtos = new List<QuizDto>();
            foreach (var item in AllQuizes)
            {
                quizDtos.Add(QuizDto.of(item));
            }
            return quizDtos;
        }

        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public void SaveAnswer([FromBody] QuizItemAswerDto dto, int quizId, int itemId)
        {
            _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);
        }

        [HttpGet]
        [Route("{quizId}/{userId}")]
        public int TODO(int userId, int quizId)
        {
            return _service.CountCorrectAnswersForQuizFilledByUser(userId, quizId);
        }
    }
}
