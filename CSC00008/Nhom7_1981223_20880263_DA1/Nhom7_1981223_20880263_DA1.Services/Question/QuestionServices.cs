using System;
using Nhom7_1981223_20880263_DA1.Interfaces.FileIO;
using Nhom7_1981223_20880263_DA1.Interfaces.Question;
using Nhom7_1981223_20880263_DA1.Models.Entities;
using Nhom7_1981223_20880263_DA1.Services.FileIO;

namespace Nhom7_1981223_20880263_DA1.Services.Question
{
    public class QuestionServices : IQuestionServices
    {

        private readonly IFileIOServices _fileServices;

        private AdjacencyMatrix matrix;

        public QuestionServices()
        {
            _fileServices = new FileIOServices();
        }

        public void Run(string fileName, bool isUseDataQuestion = true)
        {
            this.GetMatrix(fileName, isUseDataQuestion);
            matrix.ShowMatrix();
            Console.WriteLine();
        }
        private void GetMatrix(string fileName, bool isFileName)
        {
            matrix = new AdjacencyMatrix((isFileName ? _fileServices.GetUrlFile(fileName) : fileName));
        }
        //private void GetMatrix(string fileName, bool isFileName)
        //{
        //    matrix_list = new AdjacencyList((isFileName ? _fileServices.GetUrlFile(fileName) : fileName));
        //}
        //private void GetTransposeMatrix(string fileName, bool isFileName)
        //{
        //    matrix_list_transpose = new AdjacencyList_GetTranspose((isFileName ? _fileServices.GetUrlFile(fileName) : fileName));
        //}
        //private void _GetMatrix(string fileName, bool isFileName)
        //{
        //    _matrix = new AdjacencyMatrix((isFileName ? _fileServices.GetUrlFile(fileName) : fileName));
        //}
    }
}
