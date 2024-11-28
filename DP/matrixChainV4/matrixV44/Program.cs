using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixV44
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter the number of matrices: ");
                int numMatrices = int.Parse(Console.ReadLine());

                int[] dimensions = new int[numMatrices + 1];

                for (int i = 0; i <= numMatrices; i++)
                {
                    Console.Write($"dimension {i + 1}: ");
                    dimensions[i] = int.Parse(Console.ReadLine());
                }

                var result = matrixChain(dimensions);

                Console.WriteLine($"minimum multiplication cost is {result.Item1}");
                Console.WriteLine($"optimal order is : {result.Item2}");
            }

            Console.ReadKey(); // Fixed placement of Console.ReadKey.
        }

      static (int, string) matrixChain(int[] dimensions)
        {
            int n = dimensions.Length-1;
            int[,] m = new int[n+1, n+1];
            int[,] s = new int[n+1, n+1];

            for(int i = 0; i <= n; i++)
            {
                m[i, i] = 0;
            }


            for(int diff =1;diff<n; diff++)
            {
                for(int i=1;i<=n-diff;i++)
                {

                    int j = i+diff;
                    m[i, j] = int.MaxValue;
                    for(int k = i; k < j; k++)
                    {
                        int costOfm= m[i, k] + m[k + 1, j] + dimensions[i-1] * dimensions[k]* dimensions[j];
                        if (costOfm < m[i, j])
                        {
                            m[i,j]= costOfm;
                            s[i, j] = k;
                        }
                    }

                }
            }

            string order = getOptimalOrder(s, 1, n);
            return (m[1, n], order);


        }

        static string getOptimalOrder(int[,] s, int i, int j)
        {
            if (i == j)
            {
                return $"A{i}";
            }

            else
            {
                int k = s[i,j];
                return $"({getOptimalOrder(s, i, k)}*{getOptimalOrder(s, k + 1, j)})";
            }
        }



    }
}
