using System;

namespace PrimMSTV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of vertices: ");
            int vertices = int.Parse(Console.ReadLine());

            int[,] graph = new int[vertices, vertices];

            Console.Write("Enter the number of edges: ");
            int edges = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter edges in the format: start end weight");
            Console.WriteLine("NOTE! this program assumes that starting vertex is 1,\nif ur starting vertex  is 1 please decrement your input vertices by 1");
            for (int i = 0; i < edges; i++)
            {
                Console.Write($"Edge {i + 1}: ");
                string[] input = Console.ReadLine().Split();
                int start = int.Parse(input[0]);
                int end = int.Parse(input[1]);
                int weight = int.Parse(input[2]);
                graph[start, end] = weight;
                graph[end, start] = weight; // For undirected graph
            }

            Console.WriteLine("\nMinimum Spanning Tree:");
            FindMST(graph);
            Console.ReadLine(); // Pause to view output
        }

        static int SelectMinVertex(int[] value, bool[] setMST, int v)
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

        static void FindMST(int[,] graph)
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
                int U = SelectMinVertex(value, setMST, v);
                setMST[U] = true;

                for (int j = 0; j < v; j++)
                {
                    if (graph[U, j] != 0 && !setMST[j] && graph[U, j] < value[j])
                    {
                        value[j] = graph[U, j];
                        parent[j] = U;
                    }
                }
            }

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
