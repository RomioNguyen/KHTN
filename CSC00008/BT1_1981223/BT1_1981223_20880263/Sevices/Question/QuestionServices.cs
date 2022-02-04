﻿using BT1_1981223_20880263.Sevices.AdjacencyMatrix;
using BT1_1981223_20880263.Sevices.File;
using System;

namespace BT1_1981223_20880263.Sevices
{
    public class QuestionServices : IQuestionServices
    {

        private readonly IFileServices _fileServices;
        private readonly IAdjacencyMatrixServices _maxtrixServices;

        private Models.AdjacencyMatrix matrix;
        public QuestionServices()
        {
            _fileServices = new File.FileServices();
            _maxtrixServices = new AdjacencyMatrix.AdjacencyMatrixServices();
        }
        public void RunQuestion1(string fileName)
        {
            matrix = new Models.AdjacencyMatrix(_fileServices.GetUrlFile(fileName));
            if (_maxtrixServices.isSymmetry(matrix))
                _maxtrixServices.runDigraphMatrix(matrix);
            else
                _maxtrixServices.runUnDigraphMatrix(matrix);
        }

        public void RunQuestion2(string fileName)
        {
            matrix = new Models.AdjacencyMatrix(_fileServices.GetUrlFile(fileName));
            _maxtrixServices.runSimpleMatrix(matrix);
        }
    }
}