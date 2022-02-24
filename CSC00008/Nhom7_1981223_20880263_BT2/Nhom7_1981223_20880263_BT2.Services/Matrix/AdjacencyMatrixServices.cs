using Nhom7_1981223_20880263_BT2.Interfaces.Matrix;
using Nhom7_1981223_20880263_BT2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom7_1981223_20880263_BT2.Services.Matrix
{
    public class AdjacencyMatrixServices : IAdjacencyMatrixServices
    {
        private readonly string TYPE_UNDIGRAPH = "vo huong";
        private readonly string TYPE_DIGRAPH = "co huong";
        public bool isSymmetry(AdjacencyMatrix matrix)
        {
            int i, j;
            bool rs = true;
            for (i = 0; i < matrix.n && rs; ++i)
            {
                for (j = i + 1; (j < matrix.n) && (matrix.a[i, j] == matrix.a[j, i]); ++j) ;
                if (j < matrix.n)
                    rs = false;
            }
            return rs;
        }

        public void runDigraphMatrix(AdjacencyMatrix matrix)
        {
            matrix.ShowMatrix();
            this.PrintTypeMatrix(false);
            this.PrintTotalVertices(matrix);
            int[] InDegree = new int[matrix.n];
            int[] OutDegree = new int[matrix.n];
            this.BFS_Algorithm(matrix);
        }

        public void runUnDigraphMatrix(AdjacencyMatrix matrix)
        {
            matrix.ShowMatrix();
            this.PrintTypeMatrix(true);
            this.PrintTotalVertices(matrix);
            int[] PeakDegree = new int[matrix.n];
            this.BFS_Algorithm(matrix);
        }


        // in ra loại ma trận
        private void PrintTypeMatrix(bool isDigraph = true)
        {
            Console.WriteLine(string.Format("Do thi {0}", (isDigraph ? TYPE_DIGRAPH : TYPE_UNDIGRAPH)));
        }
        // in ra số đỉnh
        private void PrintTotalVertices(AdjacencyMatrix matrix)
        {
            Console.WriteLine($"So dinh cua do thi: {matrix.n}");
        }
        private List<int> tim_dinh_ke(AdjacencyMatrix matrix, int vertex)
        {
            List<int> dinh_ke = new List<int>(matrix.n);
            for (int j = 0; j < matrix.n; j++)
            {
                if (matrix.a[vertex, j] == 1)
                {
                    dinh_ke.Add(j);
                }
            }
            return dinh_ke;
        }
        private void queue_BFS(AdjacencyMatrix matrix, bool[] visited, int[] parent, List<int> order_visit, int vertex)
        {

            Queue<int> queue = new Queue<int>();
            visited[vertex] = true;
            order_visit.Add(vertex);
            queue.Enqueue(vertex);
            while (queue.Count != 0)
            {
                int v = queue.Dequeue();
                if (v == matrix.goal)
                {
                    return;
                }
                foreach (int i in tim_dinh_ke(matrix, v))
                {
                    if (visited[i] == false)
                    {
                        parent[i] = v;
                        visited[i] = true;
                        order_visit.Add(i);
                        queue.Enqueue(i);
                    }
                }
            }
        }
        private void BFS_Algorithm(AdjacencyMatrix matrix)
        {
            bool[] visited = new bool[matrix.n];
            for (int i = 0; i < matrix.n; i++)
            {
                visited[i] = false;
            }
            int[] parent = new int[matrix.n];
            for (int i = 0; i < matrix.n; i++)
            {
                parent[i] = -1;
            }
            List<int> order_visit = new List<int>(matrix.n);
            queue_BFS(matrix, visited, parent, order_visit, matrix.start);
            Console.WriteLine("Danh sach cac dinh da duyet theo thu tu:");
            for (int i = 0; i < order_visit.Count; i++)
            {
                Console.Write($"{order_visit[i]} ");
            }
            Console.WriteLine();
            int cur = matrix.goal;
            Console.WriteLine("Duong di in kieu nguoc:");
            while (cur != matrix.start)
            {
                Console.Write(cur.ToString() + " <- ");
                cur = parent[cur];
            }
            Console.WriteLine(cur.ToString());

        }
    }
}
