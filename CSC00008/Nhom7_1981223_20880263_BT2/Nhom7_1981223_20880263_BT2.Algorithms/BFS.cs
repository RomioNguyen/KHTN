using Nhom7_1981223_20880263_BT2.Models.Entities;
using System;
using System.Collections.Generic;

namespace Nhom7_1981223_20880263_BT2.Algorithms
{
    public class BFS
    {
        private Queue<int> queueForBFS;
        private int[] parent;
        private bool[] visited;
        private AdjacencyMatrix _matrix;
        private List<int> listVisted;
        public BFS(AdjacencyMatrix matrix)
        {
            _matrix = matrix;
            queueForBFS = new Queue<int>();
            visited = new bool[matrix.n];
            parent = new int[matrix.n];
        
            InputBFS();
        }

        private void InputBFS()
        {
            for (int i = 0; i < _matrix.n; i++)
            {
                visited[i] = false;
            }
            for (int i = 0; i < _matrix.n; i++)
            {
                parent[i] = -1;
            }
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
        private void FindBFSFromVertex(int vStart)
        {
          
            visited[vStart] = true;
            listVisted.Add(vStart);
            queueForBFS.Enqueue(vStart);
            while (queueForBFS.Count != 0)
            {
                int v = queueForBFS.Dequeue();
                if (v == _matrix.goal)
                {
                    return;
                }
                foreach (int i in tim_dinh_ke(_matrix, v))
                {
                    if (visited[i] == false)
                    {
                        parent[i] = v;
                        visited[i] = true;
                        listVisted.Add(i);
                        queueForBFS.Enqueue(i);
                    }
                }
            }
        }
        public void FindTheWayFromStartToGoal()
        {
            listVisted = new List<int>(_matrix.n);
            FindBFSFromVertex(_matrix.start);
            if(listVisted.Find(x => x == _matrix.goal) != 0)
            {
                Console.WriteLine("Danh sach cac dinh da duyet theo thu tu:");
                for (int i = 0; i < listVisted.Count; i++)
                {
                    Console.Write($"{listVisted[i]} ");
                    if(listVisted[i] == _matrix.goal)
                    {
                        break;
                    }
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
