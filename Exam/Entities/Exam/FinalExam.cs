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
                (questionType != 1 || questionType != 2)));

                if (questionType == 1)
                    question = new MCQ();
                else
                    question = new TOF();


                Questions.Add(question.GenerateQuestion(count+1));
                count++;
            }
        }

        public override void ShowExam()
        {
            throw new NotImplementedException();
        }
    }
}
