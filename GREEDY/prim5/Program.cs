using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prim5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the number of vertices: ");
            int V = int.Parse(Console.ReadLine());

            int[,] graph = new int[V,V];

            Console.Write("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter the edges in format (start: end:  weight:)");
            for (int i = 0; i < E; i++)
            {
                Console.Write($"Edge {i + 1}: ");

                var input = Console.ReadLine().Split();
                int start = int.Parse(input[0]);
                int end = int.Parse(input[1]);
                int wt = int.Parse(input[2]);
                graph[start,end] = wt;
                graph[end,start] = wt;

            }

            prim(graph);



            Console.ReadKey();


        }

        static int selectMinVertex(int[] vertextVal, bool[] setMST,int v) 
        {
        int minimum = int.MaxValue;
            int vertex = -1;


            for(int i = 0;i<v;i++)
            {
                if (!setMST[i] && vertextVal[i] < minimum)
                {
                    minimum = vertextVal[i];
                    vertex = i;
                }

            }
        return vertex;
        
        }


        static void prim(int[,] graph)
        {
            int v = graph.GetLength(0);

            int[] parent = new int[v];
            int[] vertexVal = new int[v];
            bool[] setMST = new bool[v];   


            //INITIALIZE THE setMST TO ALL FALSE
            // and the vertex val as infinity (int.maxVAL)


            for(int i = 0;i<v; i++)
            {
                setMST[i] = false;
                vertexVal[i] = int.MaxValue;
            }

            parent[0] = -1;
            vertexVal[0] = 0;


            for(int i = 0; i < v-1; i++)
            {
                int U = selectMinVertex(vertexVal, setMST, v);
                setMST[U] = true;

                //relax adjacent edges
                for(int j = 0; j < v; j++)
                {
                    if (!setMST[j] && graph[U,j]< vertexVal[j] && graph[U,j] != 0)
                    {
                        vertexVal[j] = graph[U,j];
                        parent[j] = U;
                    }
                }

            }


            int cost = 0;
           for(int i =1;i<v; i++) 
            {
                Console.WriteLine($"{parent[i]}-->{i} wt: {graph[parent[i],i]}");
                cost += graph[parent[i], i];
            }
            Console.WriteLine($"mst cost {cost}");

        }

        
    }
}
