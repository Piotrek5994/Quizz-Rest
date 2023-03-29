using ApplicationCore.Models;

namespace WebAPI.Dto
{
    public class QuizItemDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }

        public static QuizItemDto of(QuizItem quiz)
        {
            List<string> options = new List<string>();
            options.Add(quiz.CorrectAnswer);
            options.AddRange(quiz.IncorrectAnswers);

            return new QuizItemDto
            {
                Id = quiz.Id,
                Question = quiz.Question,
                Options = options
            };
        }
    }
}
