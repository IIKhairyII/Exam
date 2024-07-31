using Exam.Entities.Dtos;
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

        public override void ShowExam(ICollection<StudentAnswer> studentAnswers)
        {
            if (studentAnswers is null || Questions is null)
            {
                Console.WriteLine("Error occured in retriving questions and answers!!");
                return;
            }
            for (int i = 0; i < Questions?.Count; i++)
            {
                if (i > 0)
                    Console.WriteLine();
                Console.WriteLine($"{Questions[i].Header}: {Questions[i].Body}");
                Console.WriteLine($"Correct Answer => {Questions[i].AnswerList?[Questions[i].RightAnswerId - 1].AnswerText}");
            }
        }
    }
}
