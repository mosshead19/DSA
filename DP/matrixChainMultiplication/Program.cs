using System;

class MatrixChainMultiplication
{
    public static (int, string) MatrixChainOrder(int[] p)
    {
        int n = p.Length - 1;
        int[,] M = new int[n + 1, n + 1];
        int[,] S = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++)
            M[i, i] = 0;

        for (int diff = 1; diff < n; diff++)
        {
            for (int i = 1; i <= n - diff; i++)
            {
                int j = i + diff;
                M[i, j] = int.MaxValue;

                for (int k = i; k < j; k++)
                {
                    int cost = M[i, k] + M[k + 1, j] + p[i - 1] * p[k] * p[j];
                    if (cost < M[i, j])
                    {
                        M[i, j] = cost;
                        S[i, j] = k;
                    }
                }
            }
        }

        string order = GetOptimalOrder(S, 1, n);
        return (M[1, n], order);
    }

    private static string GetOptimalOrder(int[,] S, int i, int j)
    {
        if (i == j)
            return $"A{i}";

        int k = S[i, j];
        if (k == 0)  // Added check for uninitialized split point
            throw new InvalidOperationException("Split point not initialized correctly.");

        return $"({GetOptimalOrder(S, i, k)} * {GetOptimalOrder(S, k + 1, j)})";
    }

    public static void Main()
    {
        int[] dimensions = { 40, 20, 30, 10, 30 };
        var result = MatrixChainOrder(dimensions);

        Console.WriteLine("Minimum number of multiplications is " + result.Item1);
        Console.WriteLine("Optimal order is " + result.Item2);


        Console.ReadKey();
    }
}
