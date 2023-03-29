using ApplicationCore.Models;

namespace WebAPI.Dto
{
    public class QuizItemDto
    {
        int Id { get; set; }

        string Question { get; set; }

        List<QuizItemDto> Option { get; set; }
    }

    public static QuizItemDto of(QuizItem quiz)
    {
        return new QuizItemDto
        {
            Id = quiz.Id,
            Question = quiz.Question,
            Option = quiz.Option.Select(QuizItemDto.of).ToList()
        };
    }
}
