using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1_1981223.Sevices.AdjacencyMatrix
{
    public class AdjacencyMatrixServices : IAdjacencyMatrixServices
    {
        private readonly string TYPE_UNDIGRAPH = "vo huong";
        private readonly string TYPE_DIGRAPH = "co huong";
        public bool isSymmetry(Models.AdjacencyMatrix matrix)
        {
            int i, j;
            bool rs = true;
            for (i = 0; i < matrix.n && rs; ++i)
            {
                for (j = i + 1; (j < matrix.n) && (matrix.a[i, j] == matrix.a[j, i]); ++j) ;
                if (j < matrix.n)
                    rs = false;
            }
            return !rs;
        }

        public void runDigraphMatrix(Models.AdjacencyMatrix matrix)
        {
            matrix.ShowMatrix();
            this.PrintTypeMatrix(false);
            this.PrintTotalVertices(matrix);

            int[] InDegree = new int[matrix.n];
            int[] OutDegree = new int[matrix.n];
            this.CountPeakDegree(ref InDegree, ref OutDegree, matrix);
            this.PrintTotalEdge(InDegree, false);
            var parallelEdge = this.PrintTotalParallelEdge(matrix, false);
            this.PrintTotalLoopEdge(matrix);

            int[] PeakDegree = new int[matrix.n];
            for (int i = 0; i < matrix.n; ++i)
                PeakDegree[i] = InDegree[i] + InDegree[i];
            this.PrintTotalPendantVertex(PeakDegree);
            this.PrintTotalIsolatedVertex(PeakDegree);
            this.PrintDegreeInOutDegree(matrix, InDegree, OutDegree);
            this.PrintTypeBasicGraph(0, parallelEdge);
        }

        public void runUnDigraphMatrix(Models.AdjacencyMatrix matrix)
        {
            matrix.ShowMatrix();
            this.PrintTypeMatrix(true);
            this.PrintTotalVertices(matrix);
            int[] PeakDegree = new int[matrix.n];
            this.CountPeakDegree(ref PeakDegree, matrix);
            this.PrintTotalEdge(PeakDegree, true);
            var parallelEdge = this.PrintTotalParallelEdge(matrix, true);
            var loopEdge = this.PrintTotalLoopEdge(matrix);
            this.PrintTotalPendantVertex(PeakDegree);
            this.PrintTotalIsolatedVertex(PeakDegree);
            this.PrintDegreeEachVertex(matrix, PeakDegree);
            this.PrintTypeBasicGraph(loopEdge, parallelEdge);

        }


        #region private function
        // in ra loại ma trận
        private void PrintTypeMatrix(bool isDigraph = true)
        {
            Console.WriteLine(string.Format("Do thi {0}", (isDigraph ? TYPE_DIGRAPH : TYPE_UNDIGRAPH)));
        }
        // in ra số đỉnh
        private void PrintTotalVertices(Models.AdjacencyMatrix matrix)
        {
            Console.WriteLine($"So dinh cua do thi: {matrix.n}");
        }
        // in ra số cạnh
        private void PrintTotalEdge(int[] PeakDegree, bool isSymmetry = true)
        {
            Console.WriteLine($"So canh cua do thi: {CountEdge(PeakDegree, isSymmetry)}");
        }
        // in ra số cạnh bội
        private int PrintTotalParallelEdge(Models.AdjacencyMatrix matrix, bool isSymmetry = true)
        {

            var parallelEdge = this.CountParallelEdge(matrix, isSymmetry);
            Console.WriteLine($"So cap dinh xuat hien canh boi: {parallelEdge}");
            return parallelEdge;
        }
        // in ra số cạnh khuyên
        private int PrintTotalLoopEdge(Models.AdjacencyMatrix matrix)
        {
            var loopEdge = this.CountLoopEdge(matrix);
            Console.WriteLine($"So canh khuyen: {loopEdge}");
            return loopEdge;
        }
        // in ra số đỉnh treo
        private void PrintTotalPendantVertex(int[] PeakDegree)
        {
            Console.WriteLine($"So dinh treo: {this.CountPendantVertex(PeakDegree)}");
        }

        // in ra số đỉnh cô lập
        private void PrintTotalIsolatedVertex(int[] PeakDegree)
        {
            Console.WriteLine($"So dinh cô lap: {this.CountIsolatedVertex(PeakDegree)}");
        }

        // in ra bậc của từng đỉnh
        private void PrintDegreeEachVertex(Models.AdjacencyMatrix matrix, int[] PeakDegree)
        {
            Console.WriteLine("Bac cua tung dinh: ");
            for (int i = 0; i < matrix.n; ++i)
                Console.Write($"{i}({PeakDegree[i]}) ");
            Console.WriteLine();
        }
        // in ra bậc của đỉnh vào và đỉnh ra
        private void PrintDegreeInOutDegree(Models.AdjacencyMatrix matrix, int[] inDegree, int[] outDegree)
        {
            Console.WriteLine("(Bac vao - Bac ra) cua tung dinh: ");
            for (int i = 0; i < matrix.n; ++i)
                Console.Write($"{i}({inDegree[i]}-{outDegree[i]}) ");
            Console.WriteLine();
        }
        // in ra loại đồ thị cơ bản
        private void PrintTypeBasicGraph(int totalLoopEdge, int totalParallelEdge, bool isSymmetry = true)
        {
            if (totalLoopEdge > 0)
                Console.WriteLine("Gia do thi");
            else
            {
                if (totalParallelEdge > 0)
                    Console.WriteLine($"{(isSymmetry? "Da do thi co huong" : "Da do thi")}" );
                else
                    Console.WriteLine($"{(isSymmetry ? "Do thi co huong" : "Don do thi")}");
            }
        }
        // đếm số bậc đỉnh
        private void CountPeakDegree(ref int[] PeakDegree, Models.AdjacencyMatrix matrix)
        {
            for (int i = 0; i < matrix.n; ++i)
            {
                int count = 0;
                for (int j = 0; j < matrix.n; ++j)
                    if (matrix.a[i, j] != 0)
                    {
                        count += matrix.a[i, j];
                        if (i == j)
                            count += matrix.a[i, i];
                    }
                PeakDegree[i] = count;
            }
        }
        // đếm bậc vào, đếm bậc ra
        private void CountPeakDegree(ref int[] InDegree, ref int[] OutDegree, Models.AdjacencyMatrix matrix)
        {
            for (int i = 0; i < matrix.n; ++i)
            {
                int CountInDegree = 0, CountOutDegree = 0;
                for (int j = 0; j < matrix.n; ++j)
                {
                    if (matrix.a[i, j] != 0)
                        CountOutDegree += matrix.a[i, j];
                    if (matrix.a[j, i] != 0)
                        CountInDegree += matrix.a[j, i];
                }
                InDegree[i] = CountInDegree;
                OutDegree[i] = CountOutDegree;
            }
        }
        // đếm số cạnh
        private int CountEdge(int[] PeakDegree, bool isSymmetry = true)
        {
            int rs = 0;
            for (int i = 0; i < PeakDegree.Length; ++i)
                rs += PeakDegree[i];
            if (isSymmetry == true)
                return rs / 2;
            else
                return rs;
        }
        // đếm số cạnh bội
        private int CountParallelEdge(Models.AdjacencyMatrix matrix, bool isSymmetry = true)
        {
            int rs = 0;
            if (isSymmetry == true)
            {
                for (int i = 0; i < matrix.n; ++i)
                    for (int j = i; j < matrix.n; ++j)
                        if (matrix.a[i, j] > 1)
                            rs++;
            }
            else
            {
                for (int i = 0; i < matrix.n; ++i)
                    for (int j = 0; j < matrix.n; ++j)
                        if (matrix.a[i, j] > 1)
                            rs++;
            }
            return rs;
        }
        // đếm số cạnh khuyên
        private int CountLoopEdge(Models.AdjacencyMatrix matrix)
        {
            int rs = 0;
            for (int i = 0; i < matrix.n; ++i)
                rs += matrix.a[i, i];
            return rs;
        }
        // đếm số đỉnh treo
        private int CountPendantVertex(int[] PeakDegree)
        {
            int rs = 0;
            for (int i = 0; i < PeakDegree.Length; ++i)
                if (PeakDegree[i] == 1)
                    rs++;
            return rs;
        }

        // đếm số đỉnh cô lập
        private int CountIsolatedVertex(int[] PeakDegree)
        {
            int rs = 0;
            for (int i = 0; i < PeakDegree.Length; ++i)
                if (PeakDegree[i] == 0)
                    rs++;
            return rs;
        }
        #endregion
    }
}
