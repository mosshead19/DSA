using System;
using System.Collections.Generic;

namespace Kruska6
{
    internal class Program
    {
        static List<Node> nodes = new List<Node>();
        static List<Edge> mst = new List<Edge>();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of vertices: ");
            int V = int.Parse(Console.ReadLine());

            // Initialize nodes
            for (int i = 0; i < V; i++)
            {
                nodes.Add(new Node());
            }

            Console.WriteLine("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());

            List<Edge> edges = new List<Edge>();
            Console.WriteLine("Enter the edges in format (source destination weight):");
            for (int i = 0; i < E; i++)
            {
                Console.Write($"Edge {i + 1}: ");
                var input = Console.ReadLine().Split();
                int fromV = int.Parse(input[0]) - 1; // Convert to zero-based indexing
                int toV = int.Parse(input[1]) - 1;   // Convert to zero-based indexing
                int wt = int.Parse(input[2]);

                edges.Add(new Edge { source = fromV, destination = toV, weight = wt });
            }

            Kruskal(edges, V);
            PrintMST(mst);
            Console.ReadKey();
        }

        class Node
        {
            public int parent { get; set; } = -1;
            public int rank { get; set; } = 0;
        }

        class Edge : IComparable<Edge>
        {
            public int source { get; set; }
            public int destination { get; set; }
            public int weight { get; set; }

            public int CompareTo(Edge other)
            {
                return weight.CompareTo(other.weight);
            }
        }

        static int FindParent(int v)
        {
            if (nodes[v].parent == -1)
                return v;
            return nodes[v].parent = FindParent(nodes[v].parent); // Path compression
        }

        static void Union(int fromV, int toV)
        {
            if (nodes[fromV].rank > nodes[toV].rank)
            {
                nodes[toV].parent = fromV;
            }
            else if (nodes[fromV].rank < nodes[toV].rank)
            {
                nodes[fromV].parent = toV;
            }
            else
            {
                nodes[fromV].parent = toV;
                nodes[toV].rank++;
            }
        }

        static void Kruskal(List<Edge> edges, int V)
        {
            edges.Sort(); // Sort edges by weight

            int i = 0, j = 0;

            while (i < V - 1 && j < edges.Count)
            {
                int fromV = FindParent(edges[j].source);
                int toV = FindParent(edges[j].destination);

                if (fromV != toV)
                {
                    Union(fromV, toV);
                    mst.Add(edges[j]);
                    i++;
                }
                j++;
            }
        }

        static void PrintMST(List<Edge> mst)
        {
            int cost = 0;
            Console.WriteLine("\nEdges in the MST:");
            foreach (var edge in mst)
            {
                Console.WriteLine($"{edge.source + 1} --> {edge.destination + 1}, Weight: {edge.weight}"); // Convert back to 1-based indexing
                cost += edge.weight;
            }
            Console.WriteLine($"Total MST Cost: {cost}");
        }
    }
}
