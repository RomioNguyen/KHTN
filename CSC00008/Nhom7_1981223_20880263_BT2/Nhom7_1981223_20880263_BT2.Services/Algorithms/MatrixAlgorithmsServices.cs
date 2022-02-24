using Nhom7_1981223_20880263_BT2.Interfaces.Algorithms;
using Nhom7_1981223_20880263_BT2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom7_1981223_20880263_BT2.Services.Algorithms
{
    public class MatrixAlgorithmsServices: IMatrixAlgorithmsServices
    {
        Stack<int> S = new Stack<int>();
        bool[] tham;
        private void NhapDFS(int dinh, AdjacencyMatrix matrix)
        {
            tham[dinh] = true;
            for (int i = 0; i < matrix.n; i++)
            {
                if (matrix.a[dinh, i] == 1 && !tham[i])
                    NhapDFS(i, matrix);
            }
            S.Push(dinh);
        }
        private void DaoNguoc(AdjacencyMatrix matrix)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.n; j++)
                {
                    if (matrix.a[i, j] == 1)
                    {
                        matrix.a[i, j] = 0;
                        matrix.a[j, i] = 2;
                    }
                }
            }
        }
        private void XuatDFS(int dinh, AdjacencyMatrix matrix)
        {
            tham[dinh] = true;
            Console.Write(dinh + " ");
            for (int v = 0; v < matrix.n; v++)
            {
                if (matrix.a[dinh, v] == 2 && !tham[v])
                    XuatDFS(v, matrix);
            }
        }
        public void Xuat(AdjacencyMatrix _matrix)
        {
            AdjacencyMatrix matrix = _matrix;
            tham = new bool[matrix.n];
            for (int dinh = 0; dinh < matrix.n; dinh++)
            {
                if (!tham[dinh])
                    NhapDFS(dinh, matrix);
            }
            DaoNguoc(matrix);
            tham = new bool[matrix.n];
            int i = 1;
            while (S.Count > 0)
            {
                int dinh = S.Pop();
                if (!tham[dinh])
                {
                    Console.Write($"Thanh phan lien thong manh {i}: ");
                    XuatDFS(dinh, matrix);
                    i++;
                    Console.WriteLine();
                }
            }
        }
    }
}
