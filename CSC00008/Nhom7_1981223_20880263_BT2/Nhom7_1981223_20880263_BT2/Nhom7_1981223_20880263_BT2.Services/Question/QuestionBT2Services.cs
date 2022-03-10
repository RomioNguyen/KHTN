using Nhom7_1981223_20880263_BT2.Algorithms;
using Nhom7_1981223_20880263_BT2.Interfaces.FileIO;
using Nhom7_1981223_20880263_BT2.Interfaces.Question;
using Nhom7_1981223_20880263_BT2.Models.Entities;
using Nhom7_1981223_20880263_BT2.Services.FileIO;
using System;

namespace Nhom7_1981223_20880263_BT2.Services.Question
{
    public class QuestionBT2Services : IQuestionBT2Services
    {
        private readonly IFileIOServices _fileServices;

        private AdjacencyMatrix matrix;

        public QuestionBT2Services()
        {
            _fileServices = new FileIOServices();
        }

        public void Run(string fileName, bool isUseDataQuestion = true)
        {
            this.GetMatrix(fileName, isUseDataQuestion);
            matrix.ShowMatrix();
            Console.WriteLine();
            Console.WriteLine("++ BFS Algorithm ++");
            (new BFS(matrix)).FindTheWayFromStartToGoal();
            Console.WriteLine();
            Console.WriteLine("++ DFS Algorithm ++");
            var dfs = new DFS(matrix);
            dfs.FindTheWayFromStartToGoal();
            Console.WriteLine();
            dfs.FindPathComponents();
        }

        private void GetMatrix(string fileName, bool isFileName)
        {
            matrix = new AdjacencyMatrix((isFileName ? _fileServices.GetUrlFile(fileName) : fileName));
        }
    }
}
