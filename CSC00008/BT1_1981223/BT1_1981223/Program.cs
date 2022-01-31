using BT1_1981223.Sevices;
using System;

namespace BT1_1981223
{
    public class Program
    {
        private readonly string[] QUESTION_1 = { "question1_digrapth", "question1_undigrapth" };
        private readonly IQuestionServices questionServices;
        public Program()
        {
            questionServices = new QuestionServices();
        }
        static void Main(string[] args)
        {
            Program _pro = new Program();
            foreach (string _question1 in _pro.QUESTION_1)
            {
                _pro.questionServices.RunQuestion1(_question1);
                Console.WriteLine("_________________________________________________________");
            }
           
        }
    }
}
