﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KRUSKAL8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the number of vertices: ");
            int V = int.Parse(Console.ReadLine());

            //this will create = dsuf ={node[0]: parent=-1, rank =0, node[1]: parent=-1,rank=0...}
            dsuf = new List<Node>();
            for(int i = 0; i < V; i++)
            {
                dsuf.Add(new Node());

            }


            List<Edge> edgelist = new List<Edge>();
            Console.WriteLine("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the edges following format (src, destination, weight)");
            for (int i =0; i < E; i++)
            {
                Console.Write($"Edge{i+1}: ");
                var input = Console.ReadLine().Split();
                int fromV = int.Parse(input[0]);
                int toV = int.Parse(input[1]);
                int wt = int.Parse(input[2]);

                edgelist.Add(new Edge { source=fromV, destination=toV, weight=wt });


            }

            kruskal(edgelist,V,E);
            prinMST(mst);
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


        static List<Node> dsuf = new List<Node>();
        static List<Edge> mst = new List<Edge>();


        static int findParent(int v)
        {
            if (dsuf[v].parent== -1)
            {
                return v;
            }

            else
            {
                return dsuf[v].parent = findParent(dsuf[v].parent);
            }
        }


        static void union(int fromV, int toV)
        {
            if (dsuf[fromV].rank > dsuf[toV].rank)
            {
                dsuf[toV].parent = fromV;
            } else if (dsuf[toV].rank> dsuf[fromV].rank)
            {
                dsuf[fromV].parent= toV;
            }
            else
            {
                dsuf[fromV].parent = toV;
                dsuf[toV].rank++;
            }
        }


        static void kruskal(List<Edge> edges, int V, int E)
        {
            edges.Sort();

            int i = 0, j = 0;
            while(i<V-1 &&  j<E)
            {
                int fromV = findParent(edges[j].source);
                int toV = findParent(edges[j].destination);

                if (fromV != toV)
                {
                    union(fromV, toV);
                    mst.Add(edges[j]);
                    i++;
                }
                j++;
            }

        }


        static void prinMST(List<Edge> mst)
        {
            int cost = 0;
            foreach(var edge in mst)
            {
                Console.WriteLine($"{edge.source}-->{edge.destination} wt: {edge.weight}");
                cost += edge.weight;

            }
            Console.WriteLine($"MST COST: {cost}");
        }

    }
}
