using BT1_1981223_20880263.Sevices;
using System;

namespace BT1_1981223_20880263
{
    public class Program
    {
        private readonly string[] QUESTION_1 = { "question1_digrapth", "question1_undigrapth" };
        private readonly string QUESTION_2 = "question2_adjacencymatrix";
        private readonly IQuestionServices questionServices;
        public Program()
        {
            questionServices = new QuestionServices();
        }
        static void Main(string[] args)
        {
            Program _pro = new Program();
            Console.WriteLine("_________________________________________");
            Console.WriteLine("__________***** Cau hoi 1 *****__________");
            var i = 0;
            foreach (string _question1 in _pro.QUESTION_1)
            {
                i++;
                Console.WriteLine("_________________________________________");
                Console.WriteLine($"**Do thi {i}");
                _pro.questionServices.RunQuestion1(_question1);

            }
            Console.WriteLine("_________________________________________");
            Console.WriteLine("__________***** Cau hoi 2 *****__________");
            Console.WriteLine("_________________________________________");
            _pro.questionServices.RunQuestion2(_pro.QUESTION_2);
        }
    }
}
