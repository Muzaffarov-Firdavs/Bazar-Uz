using BazarUz.Domain.Commons;
using BazarUz.Domain.Enums;

namespace BazarUz.Domain.Entities
{
    public class Question : Auditable
    {
        public long UserId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public QuestionProgress Progress { get; set; }
    }
}
