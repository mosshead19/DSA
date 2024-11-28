using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kruskal9
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the number vertices: ");
            int V = int.Parse(Console.ReadLine());
            //THIS IS WHAT WILL BE THE NUMBER OF NODES

            dsuf = new List<Node>();
            for(int i = 0; i < V; i++)
            {
                dsuf.Add(new Node());
            }

            Console.WriteLine("Enter the number of edges: ");
            int E =int.Parse(Console.ReadLine());

            List<Edge> edgelist = new List<Edge>();

            Console.WriteLine("Enter the edges in format (source, destination, weight)");
            for (int i=0; i < E; i++)
            {
                Console.Write($"Edge {i + 1}: ");
                var input = Console.ReadLine().Split();
                int fromV = int.Parse(input[0]);
                int toV = int.Parse(input[1]);
                int weight = int.Parse(input[2]);

                edgelist.Add(new Edge { source = fromV, destination = toV, weight = weight });
            }

            kruskal(edgelist, V, E);
            printMST(mst);
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

        static List<Edge>  mst = new List<Edge>();
        static List<Node> dsuf = new List<Node>();   

        static int findparent(int v)
        {
            if (dsuf[v].parent == -1)
            {
                return v;
            }
            else
            {
                return dsuf[v].parent= findparent(dsuf[v].parent);
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
        //I slit a sheet 
        //a sheet I slit
        //and on that slitted sheet I sit

        static void kruskal(List<Edge> edgelist, int V, int E)
        {
            edgelist.Sort();

            int i=0, j=0;
            while(i<V-1 && j < E)
            {
                int fromV = findparent(edgelist[j].source);
                int toV = findparent(edgelist[j].destination);
                if (fromV != toV)
                {
                   union(fromV, toV);
                    mst.Add(edgelist[j]);
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
                Console.WriteLine($"{edge.source}-->{edge.destination}  wt: {edge.weight}");
                cost += edge.weight;
            }
            Console.WriteLine($"mst cost : {cost}");
        }
    }
}
