using Nhom7_1981223_20880263_BT2.Interfaces.Algorithms;
using Nhom7_1981223_20880263_BT2.Interfaces.FileIO;
using Nhom7_1981223_20880263_BT2.Interfaces.Matrix;
using Nhom7_1981223_20880263_BT2.Interfaces.Question;
using Nhom7_1981223_20880263_BT2.Models.Entities;
using Nhom7_1981223_20880263_BT2.Services.Algorithms;
using Nhom7_1981223_20880263_BT2.Services.FileIO;
using Nhom7_1981223_20880263_BT2.Services.Matrix;

namespace Nhom7_1981223_20880263_BT2.Services.Question
{
    public class QuestionBT2Services : IQuestionBT2Services
    {
        private readonly IFileIOServices _fileServices;
        private readonly IAdjacencyMatrixServices _maxtrixServices;
        private readonly IMatrixAlgorithmsServices _matrixAlgorithmsServices;

        private AdjacencyMatrix matrix;

        public QuestionBT2Services()
        {
            _fileServices = new FileIOServices();
            _maxtrixServices = new AdjacencyMatrixServices();
            _matrixAlgorithmsServices = new MatrixAlgorithmsServices();
        }

        public void Run(string fileName, bool isUseDataQuestion = true)
        {
            this.GetMatrix(fileName, isUseDataQuestion);
            if (_maxtrixServices.isSymmetry(matrix))
                _maxtrixServices.runDigraphMatrix(matrix);
            else
                _maxtrixServices.runUnDigraphMatrix(matrix);
            _matrixAlgorithmsServices.Xuat(matrix);
        }

        private void GetMatrix(string fileName, bool isFileName)
        {
            if (isFileName)
                matrix = new AdjacencyMatrix(_fileServices.GetUrlFile(fileName));
            else
                matrix = new AdjacencyMatrix(fileName);
        }
    }
}
