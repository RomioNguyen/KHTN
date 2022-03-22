using System;
using Nhom7_1981223_20880263_DA1.Interfaces.FileIO;
using Nhom7_1981223_20880263_DA1.Services.FileIO;

namespace Nhom7_1981223_20880263_DA1
{
   public class Program
    {
        private readonly string KEY_QUESTIONS = "Question";
        private readonly string URL_QUESTION = "";
        //private readonly string URL_QUESTION = "C:\\Users\\Admin\\study\\KHTN\\CSC00008\\Nhom7_1981223_20880263_BT2\\Nhom7_1981223_20880263_BT2\\AppData";
        private readonly IFileIOServices _fileServices;
        public Program()
        {
            _fileServices = new FileIOServices();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start program DA1 Nhom 7: 1981223, 20880263!");
            Program _pro = new Program();
            if (_pro.URL_QUESTION == "")
                RunQuestion(_pro, _pro.KEY_QUESTIONS);
            else
                RunQuestion(_pro, _pro.URL_QUESTION, false);
        }

        private static void RunQuestion(Program pro, string keyQuestion, bool isFolderDataQuestion = true)
        {
            var i = 0;
            Console.WriteLine("_________________________________________");
            Console.WriteLine($"__________***** Cau hoi DA 1 *****__________");
            if (isFolderDataQuestion)
            {
                var arrKey = pro._fileServices.GetArrayUrl(keyQuestion);
                if (arrKey.Length > 0)
                {

                    foreach (string fileName in arrKey)
                    {
                        if (arrKey.Length > 1)
                        {
                            i++;
                            Console.WriteLine("_________________________________________");
                            Console.WriteLine($"**Vi du {i}");
                        }
                        StartRunQuestion(pro, fileName, isFolderDataQuestion);
                    }
                }
            }
            else
            {
                var arrPaths = pro._fileServices.GetArrayUrlFileFromPath(keyQuestion);
                foreach (string path in arrPaths)
                {
                    i++;
                    Console.WriteLine("_________________________________________");
                    Console.WriteLine($"**Vi du {i}");
                    StartRunQuestion(pro, path, isFolderDataQuestion);
                }
            }

        }

        private static void StartRunQuestion(Program pro, string fileName, bool isFolderDataQuestion = true)
        {

            //pro._questionServices.Run(fileName, isFolderDataQuestion);
            Console.WriteLine("asdasdasda");
        }
    }
}
