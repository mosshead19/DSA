using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace kruskal5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vertices

            Console.WriteLine("Enter the number of vertices: ");
            int V = int.Parse(Console.ReadLine());


            List<Node> verticesNode = new List<Node>();

            for(int i =0;i< V; i++)
            {
                verticesNode.Add(new Node());
            }


            List<Edge> edges= new List<Edge>();
            Console.WriteLine("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter edges following format (source, destination, weight)");
            for (int i =0;i< E; i++)
            {
                Console.Write ($"Edge {i+1}: ");
                var input = Console.ReadLine().Split(' ');
                int fromV = int.Parse(input[0]);
                int toV  = int.Parse(input[1]);
                int wt = int.Parse(input[2]);

               edges.Add(new Edge { source = fromV, destination = toV, weight = wt });
            }

            kruskal(edges,V,E);
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

        static List<Node> dsuf = new List<Node>();
        static List<Edge> mst = new List<Edge>();


        static int find(int i)
        {
            if (dsuf[i].parent == -1)
            {
                return i;
            }

            else
            {
                return dsuf[i].parent= find(dsuf[i].parent);
            }
        }


        //for union requirements are that the node with the higher rank gets to be the parent
        
       
        static void Union(int fromV, int toV)
        {
            if (dsuf[fromV].rank > dsuf[toV].rank) {
                dsuf[toV].parent= fromV;
            
            }
            else if (dsuf[toV].rank> dsuf[fromV].rank)
            {
                dsuf[fromV].parent = toV;
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
            while (i<V-1 && j < E)
            {
                int fromV = find(edges[j].source);
                int toV = find(edges[j].destination);
                if(fromV!=toV)
                {
                    Union(fromV, toV);
                    mst.Add(edges[j]);
                    i++;
                }
                j++;

            }


        }

        static void printMST(List<Edge> mst)
        {
            foreach(var edge in mst)
            {
                Console.WriteLine($"src: {edge.source} destination: {edge.destination} weight : {edge.weight}");
            }
        }

    }


    
}
