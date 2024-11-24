using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace kruskalv3
{
    internal class Program
    {
        class Node
        {
            public int parent { get; set; } = -1;
            public int rank { get; set; } = 0;
        }

        class Edge: IComparable<Edge>
        {
            public int source { get; set; }
            public int detination { get; set; }
            public int weight { get; set; }

            public int CompareTo(Edge other)
            {
                return weight.CompareTo(other.weight);
            }

        }
        static List<Node> dsuf = new List<Node>();
        static List<Edge> mst = new List<Edge>();

        static int Find(int v)
        {
            if (dsuf[v].parent == -1)
            {
                return v;
            }
            else
            {
                return dsuf[v].parent = Find(dsuf[v].parent);
            }

        }

        static void union(int fromV, int toV)
        {
            if (dsuf[fromV].rank > dsuf[toV].rank)
            {
                dsuf[toV].parent = fromV;
            }
            else if (dsuf[toV].rank > dsuf[fromV].rank)
            {
                dsuf[fromV].parent = toV;
            }

            else
            {
                dsuf[fromV].parent = toV;
                dsuf[toV].rank++;
            }
        }


        static void kruskal(List<Edge> edgeList,int V, int E)
        {
            //STEP 1. sort edges by weight
            edgeList.Sort();
            //Ede
            int i = 0, j = 0;
            while(i<V-1 && j < E)
            {
                int fromV = Find(edgeList[j].source);
                int toV = Find(edgeList[j].detination);

                if (fromV != toV)
                {
                    union(fromV, toV);
                    mst.Add(edgeList[j]);
                    i++;
                }
                j++;
            }
        }

        static void printMST(List<Edge> mst)
        {
            int mstCOST = 0;
            foreach(var edge in mst)
            {
             
                Console.WriteLine($"src: {edge.source} dst: {edge.detination} wt: {edge.weight}");
                mstCOST += edge.weight;
               
            }
            Console.WriteLine($"total cost: {mstCOST}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of vertices: ");
            int V = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());


            dsuf = new List<Node>();

        for(int i = 0; i < V; i++)
            {
                dsuf.Add(new Node());
            }



            List<Edge> edgeList = new List<Edge>();
            Console.WriteLine("Enter edges: ");
            for(int i = 0; i < E; i++)
            {
                Console.Write($"Edge {i+1} (src,dst,wt) : ");
                var input = Console.ReadLine().Split(' ');
                int fromV = int.Parse(input[0]);
                int toV = int.Parse(input[1]);
                int wt = int.Parse(input[2]);

                edgeList.Add(new Edge { source = fromV, detination = toV, weight =wt });

            }

            kruskal(edgeList, V, E);
            printMST(mst);


            Console.ReadKey();


        }
    }
}
