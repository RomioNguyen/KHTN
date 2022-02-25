using Nhom7_1981223_20880263_BT2.Models.Entities;
using System;
using System.Collections.Generic;

namespace Nhom7_1981223_20880263_BT2.Algorithms
{
    public class DFS
    {
        private AdjacencyMatrix _matrix;
        private List<int> listVisted;
        private List<int[]> listComponents;
        private bool[] visited;
        private int[] parent;
        public DFS(AdjacencyMatrix matrix)
        {
            _matrix = matrix;
        }

        public void FindDFSFromVertex(int vertex)
        {
            if (!visited[vertex])
            {
                visited[vertex] = true;
                listVisted.Add(vertex);
                for (int i = 0; i < _matrix.n; i++)
                {
                    if (_matrix.a[vertex, i] == 1 && !visited[i])
                    {
                        parent[i] = vertex;
                        if (vertex == _matrix.goal)
                        {
                            break;
                        }
                        FindDFSFromVertex(i);
                    }
                }
            }
        }
        public void FindPathComponents()
        {
            visited = new bool[_matrix.n];
            listComponents = new List<int[]>();
            int count = 0;
            for (int i = 0; i < _matrix.n; i++)
            {
                if (!visited[i])
                {
                    listVisted = new List<int>();
                    FindDFSFromVertex(i);
                    listComponents.Add(listVisted.ToArray());
                    ++count;
                }
            }
            Console.WriteLine($"So thanh phan lien thong: {count}");
            for (int i = 0; i < listComponents.Count; i++)
            {
                Console.WriteLine($"Thanh phan lien thong thu {(i+1)}: { String.Join(" ", listComponents[i])}");
            }

        }
        public void FindTheWayFromStartToGoal()
        {
            parent = new int[_matrix.n];
            listVisted = new List<int>(_matrix.n);
            visited = new bool[_matrix.n];
            for (int i = 0; i < _matrix.n; i++) parent[i] = -1;
            FindDFSFromVertex(_matrix.start);

            if (listVisted.Find(x => x == _matrix.goal) != 0)
            {
                Console.WriteLine("Danh sach cac dinh da duyet theo thu tu:");
                for (int i = 0; i < listVisted.Count; i++)
                {
                    Console.Write($"{listVisted[i]} ");
                }
                Console.WriteLine();
                int cur = _matrix.goal;
                Console.WriteLine("Duong di in kieu nguoc:");
                while (cur != _matrix.start)
                {
                    Console.Write(cur.ToString() + " <- ");
                    cur = parent[cur];
                }
                Console.WriteLine(cur.ToString());
            }
            else
            {
                Console.WriteLine("Khong co duong di.");
            }

        }
    }
}
