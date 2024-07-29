using Exam.Entities;
using Exam.Entities.Exam;

namespace Exam
{
    public class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new(10, "Programming");
            byte examType;
            int questionsNumber, examDuration;
            do
                Console.WriteLine("Please choose your exam type: (1 for final exam | 2 for practical exam)");
            while (!byte.TryParse(Console.ReadLine(), out examType)
                    || (examType != 1 || examType != 2));

            if (examType == 1)
                subject.Exam = new FinalExam();
            else
                subject.Exam = new PracticalExam();

            do
                Console.Write("Enter Question numbers: ");
            while (!int.TryParse(Console.ReadLine(), out questionsNumber));


            do
                Console.Write("Enter Exam duration (in min): ");
            while (!int.TryParse(Console.ReadLine(), out examDuration));

            subject.Exam.QuestionNumbers = questionsNumber;
            subject.Exam.ExamTime = examDuration;
            Console.Clear();
            //Create exam questions
            subject.Exam.CreateQuestions();
            string userDecision;
            do
            {

                Console.Write("Do you want to start the exam now?? (Yes Y | No N)");
                userDecision = Console.ReadLine().ToUpper();
            }
            while (userDecision != "Y" && userDecision != "N");

            if (userDecision == "N")
                return;

        }
    }
}