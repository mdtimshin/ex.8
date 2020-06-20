using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace ex._8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("graf_matrix.txt");
                for(int i = 0; i<lines.Length; i++)
                {
                    if (lines[0].Length != lines[i].Length)
                    {
                        Console.WriteLine("Матрица не квадратная. Завершение работы программы");
                        Environment.Exit(1);
                    }
                }
                int[,] matrix = new int[lines.Length, lines.Length];
                if (lines.Length == 0)
                {
                    Console.WriteLine("Файл graf_matrix.txt пуст. Завершение работы программы");
                    Environment.Exit(1);
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] s = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < lines.Length; k++)
                    {
                        matrix[i, k] = int.Parse(s[k]);
                    }
                }
                List<string> blocks = new List<string>();
                List<int> tochkiSochl = new List<int>();
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines.Length; j++)
                    {
                        if ((matrix[i, j] == 1) && (!tochkiSochl.Contains(j)))
                        {
                            tochkiSochl.Add(j);
                        }
                    }
                    for (int j = 0; j < tochkiSochl.Count - 1; j++)
                    {
                        for (int k = j + 1; k < tochkiSochl.Count; k++)
                        {
                            if (matrix[j, k] == 0 && i != k)
                            {
                                if (!blocks.Contains("V" + i + "V" + k) && !blocks.Contains("V" + k + "V" + i))
                                    blocks.Add("V" + i + "V" + k);
                            }
                        }
                    }
                }
                Console.WriteLine("Блоки в графе:");
                foreach (string s in blocks)
                {
                    Console.WriteLine(s);
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("В матрице присутствуют литеры");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Файл graf_matrix.txt не найден. Завершение работы программы");
            }
            Console.ReadLine();
            
        }
    }
}
