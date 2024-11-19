using System;
using System.Collections.Generic;

namespace kruskal
{
    internal class Program
    {
        class Edge : IComparable<Edge>
        {
            public int Source { get; set; }
            public int Destination { get; set; }
            public int Weight { get; set; }

            public Edge(int source, int destination, int weight)
            {
                Source = source;
                Destination = destination;
                Weight = weight;
            }

            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other.Weight);
            }
        }

        class KruskalAlgorithm
        {
            private int[] parent;
            private int[] rank;

            public KruskalAlgorithm(int vertices)
            {
                parent = new int[vertices];
                rank = new int[vertices];
                for (int i = 0; i < vertices; i++)
                {
                    parent[i] = i;
                    rank[i] = 0;
                }
            }

            private int Find(int vertex)
            {
                if (parent[vertex] != vertex)
                {
                    parent[vertex] = Find(parent[vertex]); // Path compression
                }
                return parent[vertex];
            }

            private void Union(int u, int v)
            {
                int rootU = Find(u);
                int rootV = Find(v);

                if (rootU != rootV)
                {
                    // Union by rank to keep the tree flat
                    if (rank[rootU] > rank[rootV])
                    {
                        parent[rootV] = rootU;
                    }
                    else if (rank[rootU] < rank[rootV])
                    {
                        parent[rootU] = rootV;
                    }
                    else
                    {
                        parent[rootV] = rootU;
                        rank[rootU]++;
                    }
                }
            }

            public List<Edge> Kruskal(int vertices, List<Edge> edges, out int totalWeight)
            {
                edges.Sort(); // Sort edges by weight
                List<Edge> mst = new List<Edge>();
                totalWeight = 0;

                foreach (var edge in edges)
                {
                    int rootSource = Find(edge.Source);
                    int rootDestination = Find(edge.Destination);

                    // If adding this edge doesn't form a cycle
                    if (rootSource != rootDestination)
                    {
                        mst.Add(edge);
                        totalWeight += edge.Weight; // Add edge weight to total
                        Union(rootSource, rootDestination);
                    }
                }

                return mst;
            }
        }

        static void Main(string[] args)
        {
            int vertices = 6; // Number of vertices
            List<Edge> edges = new List<Edge>
            {
                new Edge(0, 1, 4),
                new Edge(0, 2, 4),
                new Edge(1, 2, 2),
                new Edge(1, 3, 5),
                new Edge(2, 3, 8),
                new Edge(3, 4, 6),
                new Edge(4, 5, 9),
                new Edge(3, 5, 7)
            };

            KruskalAlgorithm kruskal = new KruskalAlgorithm(vertices);
            int totalWeight;
            List<Edge> mst = kruskal.Kruskal(vertices, edges, out totalWeight);

            Console.WriteLine("Edges in the Minimum Spanning Tree:");
            foreach (var edge in mst)
            {
                Console.WriteLine($"Source: {edge.Source}, Destination: {edge.Destination}, Weight: {edge.Weight}");
            }

            Console.WriteLine($"Total weight of MST: {totalWeight}");

            Console.ReadKey();
        }
    }
}
