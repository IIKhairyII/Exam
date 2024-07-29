using Exam.Entities.Questions;

namespace Exam.Entities.Exam
{
    public class PracticalExam : Exam
    {
        public override void CreateQuestions()
        {

            if (Questions is null)
                Questions = new List<Question>();

            int count = default;
            while (count < this.QuestionNumbers)
            {
                Question question;
                question = new MCQ();
                Questions.Add(question.GenerateQuestion(count + 1));
                count++;
            }
        }

        public override void ShowExam()
        {
            throw new NotImplementedException();
        }
    }
}
