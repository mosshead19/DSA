using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixChainOrderAndParen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] p = { 5, 4, 6, 2, 7 };
            matrixMinCost(p);

            Console.ReadKey();
        }

        static void matrixMinCost(int[] P)
        {
            int n = P.Length;
            int[,] m = new int[n,n];
            int[,] s = new int[n,n];

            for(int diff = 1;diff<n-1;diff++)
            {
                for(int i = 1; i < n - diff; i++)
                {
                    int j = i+diff;
                    m[i, j] = int.MaxValue;

                    for(int k = i; k <= j - 1; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + P[i - 1] * P[k] * P[j];
                        if (q < m[i, j])
                        {
                            m[i, j] = q;
                            s[i,j] = k;
                        }
                    }

                
                }
            }
            Console.WriteLine("Minimum cost: " + m[1, n - 1]);


        }

    }
}
