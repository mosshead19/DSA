using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] table = lcs("dian", "dia");
            displayDP(table);


        }

        static void Main(string[] args)
        {
            int[,] table = lcs("dian", "dia");
            displayDP(table);
        }

        public static void displayDP(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] lcs(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;

            int[,] table = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                    }
                }
            }

            return table;
        }

        public static int fib(int n)
        {
            int[] fibb = new int[n + 1];
            fibb[0] = 0;
            fibb[1] = 1;

            for (int i = 2; i < n; i++)
            {
                fibb[i] = fibb[i - 1] + fibb[i - 2];
            }
            return fibb[n];

        }
    }

  
}
