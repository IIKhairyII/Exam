using Exam.Entities.Dtos;
using Exam.Entities.Questions;

namespace Exam.Entities.Exam
{
    public class FinalExam : Exam
    {
        public override void CreateQuestions()
        {
            if (Questions is null)
                Questions = new List<Question>();

            int count = default;
            while (count < this.QuestionNumbers)
            {
                byte questionType = default;
                Question question;
                do
                    Console.WriteLine("Please choose your question type: (1 for MCQ | 2 for TOF)");
                while (!(byte.TryParse(Console.ReadLine(), out questionType) ||
                (questionType != 1 && questionType != 2)));

                if (questionType == 1)
                    question = new MCQ();
                else
                    question = new TOF();


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
                StudentAnswer studentAnswer = studentAnswers?.FirstOrDefault(sa => sa.QuestionIndex == i);
                if (i > 0)
                    Console.WriteLine();

                Console.WriteLine($"{Questions[i].Header}: {Questions[i].Body}");
                if (studentAnswer is not null)
                    Console.WriteLine($"Your Answer => {Questions[i].AnswerList?[studentAnswer.AnswerId - 1].AnswerText}");
                else
                    Console.WriteLine($"Your Answer => No answer was provided for this question!!");
                Console.WriteLine($"Correct Answer => {Questions[i].AnswerList?[Questions[i].RightAnswerId - 1].AnswerText}");
            }
            Console.WriteLine("\n<=========================== Result Summary ==========================>");
            Console.WriteLine($"Your Grade is {studentAnswers?.Sum(x => x.Mark)} out of {Questions?.Sum(x => x.Mark)}");
        }
    }
}
