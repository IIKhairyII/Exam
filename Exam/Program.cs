using Exam.Entities;
using Exam.Entities.Dtos;
using Exam.Entities.Exam;
using System.Timers;

namespace Exam
{
    public class Program
    {
        private static void OnTimedEvent(Object source, ElapsedEventArgs e, Subject subject, List<StudentAnswer> studentAnswers)
        {
            Console.WriteLine();
            Console.WriteLine("Time's up! The exam is finished.");
            subject?.Exam.ShowExam(studentAnswers);
            Console.WriteLine("Thank You <3");
            Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            Subject subject = new(10, "Programming");
            byte examType;
            int questionsNumber, examDuration;
            do
                Console.WriteLine("Please choose your exam type: (1 for final exam | 2 for practical exam)");
            while (!byte.TryParse(Console.ReadLine(), out examType)
                    || (examType != 1 && examType != 2));

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
                userDecision = Console.ReadLine()?.Trim().ToUpper();
            }
            while ((userDecision != "Y" && userDecision != "N") || string.IsNullOrEmpty(userDecision));

            if (userDecision == "N")
                return;
            Console.Clear();
            //create timer
            System.Timers.Timer timer = new(subject.Exam.ExamTime * 60 * 1000);
            timer.AutoReset = false;
            timer.Enabled = true;

            List<StudentAnswer> studentAnswers = new();
            timer.Elapsed += (sender, e) =>
            {
                OnTimedEvent(sender, e, subject, studentAnswers);
            };
            for (int i = 0; i < subject?.Exam?.Questions?.Count; i++)
            {
                var question = subject?.Exam?.Questions[i];
                Console.WriteLine($"{question?.Header}: {question?.Body}");
                foreach (Answer answer in question?.AnswerList)
                {
                    Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
                }
                int answerInput;
                do
                    Console.Write("Your answer id = ");
                while (!int.TryParse(Console.ReadLine(), out answerInput)
                || !question.AnswerList.Select(x => x.AnswerId).Contains(answerInput));

                if (answerInput == question.RightAnswerId)
                    studentAnswers.Add(new() { QuestionIndex = i, AnswerId = answerInput, Mark = question.Mark });
                else
                    studentAnswers.Add(new() { QuestionIndex = i, AnswerId = answerInput, Mark = 0 });
            }
            Console.Clear();
            subject?.Exam.ShowExam(studentAnswers);
            Console.WriteLine("Thank You <3");
        }
    }
}