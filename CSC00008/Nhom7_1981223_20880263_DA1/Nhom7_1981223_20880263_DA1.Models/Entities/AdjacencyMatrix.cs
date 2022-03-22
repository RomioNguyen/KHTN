using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nhom7_1981223_20880263_DA1.Models.Entities
{
    public class AdjacencyMatrix
    {

        public int n;
        public List<List<int>> adjList;

        public AdjacencyMatrix()
        { }
        public AdjacencyMatrix(string filename)
        {
            if (this.ReadFile(filename) == false)
                Console.WriteLine("Cant read matrix from file txt");
        }
        public bool ReadFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Not found youre file. Please check again");
                return false;
            }
            string[] lines = File.ReadAllLines(filename);
            n = Int32.Parse(lines[0]);
            adjList = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                adjList.Add(new List<int>());
            }
            for (int i = 0; i < n; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j < tokens.Length; ++j)
                {
                    adjList[Int32.Parse(tokens[j])].Add(i);
                }
            }
            return true;
        }
        public void ShowMatrix()
        {
            Console.WriteLine($"So dinh: {n}");
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < adjList[i].Count; ++j)
                    Console.Write(adjList[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}
