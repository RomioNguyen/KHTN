using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom7_1981223_20880263_BT2.Models.Entities
{
    public class AdjacencyMatrix
    {
        public int n;
        public int[,] a;
        public int start;
        public int goal;
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
            string[] start_goal = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.start = Int32.Parse(start_goal[0]);
            this.goal = Int32.Parse(start_goal[1]);
            a = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                string[] tokens = lines[i + 2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; ++j)
                    a[i, j] = Int32.Parse(tokens[j]);
            }
            return true;
        }
        public void ShowMatrix()
        {
            Console.WriteLine($"So dinh: {n}");
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine($"Duong di: {start} -> {goal}");
        }
    }
}
