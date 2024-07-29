using Exam.Entities.Exam;
using Exam.Enums;

namespace Exam.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Exam.Exam Exam { get; set; }
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        public void CreateExam(ExamType examType)
        {
            if (examType == ExamType.Final)
                this.Exam = new FinalExam();
            else
                this.Exam = new PracticalExam();
        }
    }
}
