using BT1_1981223_20880263.Sevices;
using BT1_1981223_20880263.Sevices.File;
using System;

namespace BT1_1981223_20880263
{
    public class Program
    {
        private readonly string KEY_QUESTIONS_1 = "Question1";
        private readonly string KEY_QUESTIONS_2 = "Question2";
        private readonly IQuestionServices _questionServices;
        private readonly IFileServices _fileServices;
        public Program()
        {
            _questionServices = new QuestionServices();
            _fileServices = new FileServices();
        }
        static void Main(string[] args)
        {
            Program _pro = new Program();
            RunQuestion(_pro, _pro.KEY_QUESTIONS_1, 1);
            RunQuestion(_pro, _pro.KEY_QUESTIONS_2, 2);
        }

        private static void RunQuestion(Program pro, string keyQuestion, int typeQuestion = 1)
        {
            Console.WriteLine("_________________________________________");
            Console.WriteLine($"__________***** Cau hoi {typeQuestion} *****__________");
            var arrKey = pro._fileServices.GetArrayUrl(keyQuestion);
            if (arrKey.Length > 0)
            {
                var i = 0;
                foreach (string fileName in arrKey)
                {
                    if(arrKey.Length > 1)
                    {
                        i++;
                        Console.WriteLine("_________________________________________");
                        Console.WriteLine($"**Do thi {i}");
                    }
                    if(typeQuestion == 1)
                    {
                        pro._questionServices.RunQuestion1(fileName);
                    }
                    if (typeQuestion == 2)
                    {
                        pro._questionServices.RunQuestion2(fileName);
                    }

                }
            }
        }
    }
}
