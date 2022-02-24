using Nhom7_1981223_20880263_BT2.Interfaces.FileIO;
using Nhom7_1981223_20880263_BT2.Interfaces.Question;
using Nhom7_1981223_20880263_BT2.Services.FileIO;
using Nhom7_1981223_20880263_BT2.Services.Question;
using System;

namespace Nhom7_1981223_20880263_BT2
{
    public class Program
    {
        private readonly string KEY_QUESTIONS = "Question";
        private readonly string URL_QUESTION = "";
        //private readonly string URL_QUESTION = "C:\\Users\\Admin\\study\\KHTN\\CSC00008\\BT1_1981223\\BT1_1981223_20880263\\AppData\\question1_digrapth.txt";

        private readonly IQuestionBT2Services _questionServices;
        private readonly IFileIOServices _fileServices;
        public Program()
        {
            _questionServices = new QuestionBT2Services();
            _fileServices = new FileIOServices();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start program BT2 Nhom 7: 1981223, 20880263!");
            Program _pro = new Program();
            RunQuestion(_pro, _pro.KEY_QUESTIONS);
        }
        private static void RunQuestion(Program pro, string keyQuestion, bool isFolderDataQuestion = true)
        {
            Console.WriteLine("_________________________________________");
            Console.WriteLine($"__________***** Cau hoi BT 2 *****__________");
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
                        StartRunQuestion(pro, fileName, isFolderDataQuestion);
                    }
                }
            }
            else
            {
                StartRunQuestion(pro, keyQuestion,  isFolderDataQuestion);
            }

        }

        private static void StartRunQuestion(Program pro, string fileName,  bool isFolderDataQuestion = true)
        {
            pro._questionServices.Run(fileName, isFolderDataQuestion);
        }
    }
}
