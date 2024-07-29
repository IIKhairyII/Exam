namespace Exam.Entities.Questions
{
    //كان ممكن اخلي الكلاس ده abstract احسن من اني اعمل interface
    //لكن قولت اني اجرب و أطبق اغلب اللي اتشرح
    public class Question : IQuestionGenerator
    {
        public string? Header { get; set; }
        public string? Body { get; set; }
        public float Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public int RightAnswerId { get; set; }

        public virtual Question GenerateQuestion(int questionSerial)
        {
            throw new NotImplementedException();
        }
    }
}
