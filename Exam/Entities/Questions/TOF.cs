namespace Exam.Entities.Questions
{
    public class TOF : Question, IQuestionGenerator
    {
        public override Question GenerateQuestion(int questionSerial)
        {
            int mark, id;
            Console.WriteLine("TOF: Please enter question's body");
            this.Body = Console.ReadLine();
            this.Header = $"Question {questionSerial}";

            do
                Console.WriteLine("TOF: Please enter question's mark");
            while (!int.TryParse(Console.ReadLine(), out mark));
            this.Mark = mark;

            this.AnswerList = new[]
            {
                new Answer()
                {
                    AnswerId= 1,
                    AnswerText = "True"
                },
                new Answer()
                {
                    AnswerId = 2,
                    AnswerText = "False"
                },
            };

            do
                Console.WriteLine("What is the right answer id? (1 for true | 2 for false)");
            while (!int.TryParse(Console.ReadLine(), out id));
            RightAnswerId = id;

            return this;
        }
    }
}
