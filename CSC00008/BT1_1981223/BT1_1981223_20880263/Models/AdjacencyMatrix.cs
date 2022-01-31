using System;
using System.IO;

namespace BT1_1981223_20880263.Models
{
    public class AdjacencyMatrix
    {
        public int n;
        public int[,] a;
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
            a = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; ++j)
                    a[i, j] = Int32.Parse(tokens[j]);
            }
            return true;
        }
        public void ShowMatrix()
        {
            Console.WriteLine(n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }

    }
}
