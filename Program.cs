using System;
using System.Collections.Generic;
using System.IO;

namespace ex._8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("graf_matrix.txt");
            int[,] matrix = new int[lines.Length, lines.Length];
            for(int i=0; i<lines.Length; i++)
            {
                string[] s = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for(int k=0; k<lines.Length; k++)
                {
                    matrix[i, k] = int.Parse(s[k]);
                }
            }
            List<string> blocks = new List<string>();
            List<int> tochkiSochl = new List<int>();
            for(int i=0; i<lines.Length; i++)
            {
                for(int j=0; j<lines.Length; j++)
                {
                    if ((matrix[i, j] == 1)&&(!tochkiSochl.Contains(j)))
                    {
                        tochkiSochl.Add(j);
                    }
                }
                for(int j=0; j<tochkiSochl.Count-1; j++)
                {
                    for(int k=j+1; k<tochkiSochl.Count; k++)
                    {
                        if (matrix[j, k] == 0)
                        {
                            blocks.Add("V" + i + "V" + k);
                        }
                    }
                }
                //blocks.Clear();
            }
            foreach(string s in blocks)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
