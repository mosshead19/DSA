using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of matrices: ");
            int numMatrices = int.Parse(Console.ReadLine()); // Number of matrices.

            int[] dimensions = new int[numMatrices + 1]; // Dimensions array size = numMatrices + 1.

            Console.WriteLine("Enter the dimensions: ");
            for (int i = 0; i <= numMatrices; i++) // Input dimensions.
            {
                Console.Write($"Dimension {i + 1}: ");
                dimensions[i] = int.Parse(Console.ReadLine());
            }

            var result = MatrixChainOrder(dimensions);

            Console.WriteLine("\nMinimum number of multiplications is: " + result.Item1);
            Console.WriteLine("Optimal order is: " + result.Item2);

            Console.ReadKey(); // Fixed placement of Console.ReadKey.
        }

        static (int, string) MatrixChainOrder(int[] p)
        {
            int n = p.Length - 1;
            int[,] m = new int[n + 1, n + 1];
            int[,] s = new int[n + 1, n + 1];

            for (int i = 1; i <= n; i++)
            {
                m[i, i] = 0;
            }

            for (int diff = 1; diff < n; diff++)
            {
                for (int i = 1; i <= n - diff; i++)
                {
                    int j = i + diff;
                    m[i, j] = int.MaxValue;
                    for (int k = i; k < j; k++)
                    {
                        int mcost = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                        if (mcost < m[i, j])
                        {
                            m[i, j] = mcost;
                            s[i, j] = k;
                        }
                    }
                }
            }

            string order = GetOptimalOrder(s, 1, n);
            return (m[1, n], order);
        }

        static string GetOptimalOrder(int[,] s, int i, int j)
        {
            if (i == j)
            {
                return $"A{i}"; // Base case: single matrix is represented as "Ai".
            }

            int k = s[i, j]; // Retrieve the split point for the optimal solution.
            return $"({GetOptimalOrder(s, i, k)} * {GetOptimalOrder(s, k + 1, j)})"; // Recursive call to construct the order.
        }
    }
}
