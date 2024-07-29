using Exam.Entities.Questions;

namespace Exam.Entities.Exam
{
    public abstract class Exam
    {
        //In minutes
        public int ExamTime { get; set; }
        public int QuestionNumbers { get; set; }
        public List<Question> Questions { get; set; }
        public abstract void ShowExam();
        public abstract void CreateQuestions();
    }
}
