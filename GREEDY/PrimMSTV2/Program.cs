using System;

namespace PrimMSTV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = {
                { 0, 2, 0, 6, 0 },
                { 2, 0, 3, 8, 5 },
                { 0, 3, 0, 0, 7 },
                { 6, 8, 0, 0, 9 },
                { 0, 5, 7, 9, 0 }
            };

            findMST(graph);
            Console.ReadLine(); // Pause to view output
        }

        static int selectMinVertex(int[] value, bool[] setMST, int v)
        {
            int minimum = int.MaxValue;
            int vertex = -1;

            for (int i = 0; i < v; i++)
            {
                if (!setMST[i] && value[i] < minimum)
                {
                    minimum = value[i];
                    vertex = i;
                }
            }
            return vertex;
        }

        static void findMST(int[,] graph)
        {
            if (graph == null || graph.GetLength(0) != graph.GetLength(1))
            {
                Console.WriteLine("Invalid graph input. Ensure it's a non-empty square matrix.");
                return;
            }

            int v = graph.GetLength(0);
            int[] parent = new int[v];
            bool[] setMST = new bool[v];
            int[] value = new int[v];

            for (int i = 0; i < v; i++)
            {
                setMST[i] = false;
                value[i] = int.MaxValue;
            }

            parent[0] = -1;
            value[0] = 0;

            for (int i = 0; i < v - 1; i++)
            {
                // Step 1: Select the minimum vertex
                int U = selectMinVertex(value, setMST, v);

                // Step 2: Mark U as included in MST
                setMST[U] = true;

                // Step 3: Relax edges of U's adjacent vertices
                for (int j = 0; j < v; j++)
                {
                    if (graph[U, j] != 0 && !setMST[j] && graph[U, j] < value[j])
                    {
                        value[j] = graph[U, j];
                        parent[j] = U;
                    }
                }
            }

            // Print MST and total weight
            int totalWeight = 0;
            for (int i = 1; i < v; ++i)
            {
                Console.WriteLine($"U->V: {parent[i]}->{i}  wt = {graph[parent[i], i]}");
                totalWeight += graph[parent[i], i];
            }
            Console.WriteLine($"Total Weight of MST: {totalWeight}");
        }
    }
}
