using Exam.Entities.Dtos;
using Exam.Entities.Questions;

namespace Exam.Entities.Exam
{
    public abstract class Exam
    {
        //In minutes
        public int ExamTime { get; set; }
        public int QuestionNumbers { get; set; }
        public List<Question> Questions { get; set; }
        public abstract void ShowExam(ICollection<StudentAnswer> studentAnswers);
        public abstract void CreateQuestions();
    }
}
