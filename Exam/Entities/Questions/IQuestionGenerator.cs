namespace Exam.Entities.Questions
{
    public interface IQuestionGenerator
    {
        public Question GenerateQuestion(int questionSerial);
    }
}
