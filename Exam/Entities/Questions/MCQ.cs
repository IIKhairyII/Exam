namespace Exam.Entities.Questions
{
    public class MCQ : Question
    {
        public override Question GenerateQuestion(int questionSerial)
        {
            int mark, id;
            Console.WriteLine("MCQ: Please enter question's body");
            this.Body = Console.ReadLine();
            this.Header = $"Question {questionSerial}";
            do
                Console.WriteLine("MCQ: Please enter question's mark");
            while (!int.TryParse(Console.ReadLine(), out mark));
            this.Mark = mark;

            Console.WriteLine("MCQ: Please enter question's choices");
            //make 4 choices
            this.AnswerList = new Answer[4];
            for (int i = 0; i < AnswerList?.Length; i++)
            {
                Console.Write((i + 1) + " - ");
                AnswerList[i] = new()
                {
                    AnswerId = i + 1,
                    AnswerText = Console.ReadLine(),
                };
            }

            do
                Console.WriteLine("What is the right answer id?");
            while ((!int.TryParse(Console.ReadLine(), out id)) || id > AnswerList?.Length);
            RightAnswerId = id;

            return this;
        }
    }
}
