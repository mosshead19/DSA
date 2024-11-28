using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prim7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of vertices: ");
            int V = int.Parse(Console.ReadLine());

            int[,] graph = new int[V, V];

            Console.WriteLine("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the edges in format (source, destination, weight)");
            for (int i = 0; i < E; i++)
            {
                Console.Write($"edge {i+1}: ");
                var input = Console.ReadLine().Split();
                int start = int.Parse(input[0]);
                int end = int.Parse(input[1]);
                int weight = int.Parse(input[2]);

                graph[start, end] = weight;
                graph[end,start] = weight;
            }

            prim(graph);

            Console.ReadKey();
        }

        //parent
        //bool mst list
        //nodeVALUE
        static int selectMinIndex(int[] nodeLValueList,bool[] setMST, int v)
        {
            int minIndex = int.MaxValue;
            int vertex = -1;
            for(int i = 0; i < v; i++)
            {
                if (!setMST[i] && nodeLValueList[i] < minIndex)
                {
                    minIndex = nodeLValueList[i];
                    vertex = i;
                }
                
            }
            return vertex;
        }

       
        static void prim(int[,]graph)
        {
            int v = graph.GetLength(0);

            int[] parent = new int[v];
            int[] nodeValueList = new int[v];
            bool[] setMST = new bool[v];    


            for(int i = 0; i < v; i++)
            {
                setMST[i] = false;
                nodeValueList[i] = int.MaxValue;
            }

            parent[0] = -1;
            nodeValueList[0] = 0;


            for(int i=0; i < v-1; i++)
            {
                int U = selectMinIndex(nodeValueList, setMST, v);
                setMST[U] = true;

                for(int j=0; j<v; j++)
                {
                    if (graph[U,j]!=0 && !setMST[j] && graph[U, j] < nodeValueList[j])
                    {
                        nodeValueList[j] = graph[U,j];
                        parent[j] = U;
                    }
                }
            }

            int cost = 0;
            for (int i = 1; i < v; i++)
            {
                Console.WriteLine($"{parent[i]}-->{i} wt: {graph[parent[i], i]}");
                cost += graph[parent[i], i];
            }
            Console.WriteLine($"mst cost : {cost}");


        }
    }
}
