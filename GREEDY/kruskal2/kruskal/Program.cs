using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kruskal
{
    internal class Program
    {

        //INITIALIZE CLASS NODE
        class Node
        {
            public int Parent { get; set; } = -1;
            public int Rank { get; set; } = 0;
        }

        class Edge : IComparable<Edge>
        {
            public int Src { get; set; }
            public int Dst { get; set; }
            public int Wt { get; set; }

            public int CompareTo(Edge other)
            {
                return Wt.CompareTo(other.Wt);
            }
        }

        static List<Node> dsuf = new List<Node>();//parent array ALL -1 (disjoint set union find)
        static List<Edge> mst = new List<Edge>();

        // FIND operation with path compression
        static int Find(int v)
        {
            if (dsuf[v].Parent == -1)// if the parent is-1 then the  parent is found
                return v;
            //otherwise recursively find the parent
            return dsuf[v].Parent = Find(dsuf[v].Parent);
        }

        // UNION operation with union by rank
        static void Union(int fromP, int toP)
        {

            // the node with the higher rank is the node that will be set as the parent node
            if (dsuf[fromP].Rank > dsuf[toP].Rank)//
                dsuf[toP].Parent = fromP;
            else if (dsuf[fromP].Rank < dsuf[toP].Rank)
                dsuf[fromP].Parent = toP;


            else
            {
                dsuf[fromP].Parent = toP;
                dsuf[toP].Rank++;
            }
        }

        // Kruskal's Algorithm
        static void Kruskals(List<Edge> edgeList, int V, int E)
        {
            // Sort edges by weight
            edgeList.Sort();

            int i = 0, j = 0;
            while (i < V - 1 && j < E)//can form mst or not
            {
                int fromP = Find(edgeList[j].Src);//
                int toP = Find(edgeList[j].Dst);
                //if src and dst are diff then the path can be joined otherwise cycle will be created
                if (fromP != toP)
                {
                    Union(fromP, toP);
                    mst.Add(edgeList[j]);
                    i++;
                }

                j++;
            }
        }

        // Display the formed MST and its cost
        static void PrintMST(List<Edge> mst)
        {
            int totalCost = 0;
            Console.WriteLine("MST formed is:");
            foreach (var edge in mst)
            {
                Console.WriteLine($"src: {edge.Src}  dst: {edge.Dst}  wt: {edge.Wt}");
                totalCost += edge.Wt;
            }
            Console.WriteLine($"Total cost of MST: {totalCost}");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number of edges: ");
            int E = int.Parse(Console.ReadLine());
            Console.Write("Enter number of vertices: ");
            int V = int.Parse(Console.ReadLine());






            //FILL THE DSUF WITH THE INITAL PARENT AND RANK VALUE
            dsuf = new List<Node>();
            for (int i = 0; i < V; i++)
            {
                dsuf.Add(new Node());
            }





            //
            List<Edge> edgeList = new List<Edge>();
            Console.WriteLine("Enter edges:");

            for (int i = 0; i < E; i++)
            {
                Console.Write($"Edge {i + 1} (src, dst, wt): ");
                var input = Console.ReadLine().Split(' ');
                int from = int.Parse(input[0]);
                int to = int.Parse(input[1]);
                int wt = int.Parse(input[2]);

                edgeList.Add(new Edge { Src = from, Dst = to, Wt = wt });
            }

            Kruskals(edgeList, V, E);
            PrintMST(mst);

            Console.ReadLine();
        }
    }
}
