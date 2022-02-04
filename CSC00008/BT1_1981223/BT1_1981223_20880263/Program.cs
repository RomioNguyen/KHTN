using BT1_1981223_20880263.Sevices;
using BT1_1981223_20880263.Sevices.File;
using System;

namespace BT1_1981223_20880263
{
    public class Program
    {
        private readonly string KEY_QUESTIONS_1 = "Question1";
        private readonly string KEY_QUESTIONS_2 = "Question2";
        private readonly string URL_QUESTION_1 = "C:\\Users\\Admin\\study\\KHTN\\CSC00008\\BT1_1981223\\BT1_1981223_20880263\\DataQuestion\\question1_digrapth.txt";
        private readonly string URL_QUESTION_2 = "C:\\Users\\Admin\\study\\KHTN\\CSC00008\\BT1_1981223\\BT1_1981223_20880263\\DataQuestion\\question2_adjacencymatrix.txt";

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
            // run question in location DataQuestion
            RunQuestion(_pro, _pro.KEY_QUESTIONS_1, 1);
            RunQuestion(_pro, _pro.KEY_QUESTIONS_2, 2);
            // run question by url
            if (_pro.URL_QUESTION_1 != "")
            {
                RunQuestion(_pro, _pro.URL_QUESTION_1, 1, false);
            }
            if (_pro.URL_QUESTION_2 != "")
            {
                RunQuestion(_pro, _pro.URL_QUESTION_2, 2, false);
            }
        }

        private static void RunQuestion(Program pro, string keyQuestion, int typeQuestion = 1, bool isFolderDataQuestion = true)
        {
            Console.WriteLine("_________________________________________");
            Console.WriteLine($"__________***** Cau hoi {typeQuestion} *****__________");
            if (isFolderDataQuestion)
            {
                var arrKey = pro._fileServices.GetArrayUrl(keyQuestion);
                if (arrKey.Length > 0)
                {
                    var i = 0;
                    foreach (string fileName in arrKey)
                    {
                        if (arrKey.Length > 1)
                        {
                            i++;
                            Console.WriteLine("_________________________________________");
                            Console.WriteLine($"**Do thi {i}");
                        }
                        StartRunQuestion(pro, fileName, typeQuestion, isFolderDataQuestion);
                    }
                }
            }
            else
            {
                StartRunQuestion(pro, keyQuestion, typeQuestion, isFolderDataQuestion);
            }

        }

        private static void StartRunQuestion(Program pro, string fileName, int typeQuestion = 1, bool isFolderDataQuestion = true)
        {
            if (typeQuestion == 1)
            {
                pro._questionServices.RunQuestion1(fileName, isFolderDataQuestion);
            }
            if (typeQuestion == 2)
            {
                pro._questionServices.RunQuestion2(fileName, isFolderDataQuestion);
            }


        }
    }
}
