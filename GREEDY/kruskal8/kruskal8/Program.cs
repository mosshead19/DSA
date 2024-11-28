using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kruskal8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of vertices: ");
            int V = int.Parse(Console.ReadLine());

            dsuf = new List<Node>();
            for(int i = 0; i < V; i++)
            {
                dsuf.Add(new Node());
            }

            List<Edge> edgelist = new List<Edge>();
            Console.Write("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the edges in format  (src, dst, wt))")
            for(int i =0; i < E; i++)
            {
                Console.Write($"Edge {i + 1}: ");
                var input = Console.ReadLine().Split(' ');
                int fromV = int.Parse(input[0]);
                int toV = int.Parse(input[1]);
                int wt = int.Parse(input[2]);

                edgelist.Add(new Edge { source = fromV, destination=toV, weight = wt });

            }

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


        static int findparent(int v)
        {
            if (dsuf[v].parent == -1)
            {
                return v;
            }

            else
            {
                return dsuf[v].parent = findparent(dsuf[v].parent);
            }
        }

        static void union(int fromV, int toV)
        {
            if (dsuf[fromV].rank > dsuf[toV].rank)
            {

                dsuf[toV].parent = fromV;
            }

            else if (dsuf[toV].parent > dsuf[fromV].parent) 
            {
                dsuf[fromV].parent = toV;
            }
            else
            {
                dsuf[fromV].parent = toV;
                dsuf[toV].rank++;
            }
        }


        static  void kruskal8(List<Edge> edgeList, int V, int E)
        {

            edgeList.Sort();
            int i = 0, j = 0;

          while(i<V-1 && j<E)
            {
                int fromV = findparent(edgeList[i].source);
                int toV = findparent(edgeList[i].destination);

                if(fromV != toV)
                {
                    union(fromV, toV);
                    mst.Add(edgeList[i]);
                    i++;
                }
                j++;
            }

          


        }

        static void printMST(List<Edge> mst)
        {
            int cost = 0;
            foreach(var edge in mst)
            {
                Console.WriteLine($"{edge.source}-->{edge.destination} wt : {edge.weight}");
                cost += edge.weight;
            }
            Console.WriteLine($"mst cost: {cost}");
        }



       
    }
}
