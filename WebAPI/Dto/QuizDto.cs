using ApplicationCore.Models;

namespace WebAPI.Dto
{
    public class QuizDto
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public List<QuizItemDto> Items { get; set; }


        public static QuizDto of(Quiz quiz)
        {
            List<QuizItemDto> items = new List<QuizItemDto>();
            foreach (QuizItem item in quiz.Items)
            {
                items.Add(QuizItemDto.of(item));
            }
            return new QuizDto
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Items = items
            };
        }
    }
}
