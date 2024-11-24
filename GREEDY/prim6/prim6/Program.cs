using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prim6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter num of vertices: ");
            int v = int.Parse(Console.ReadLine());

            int[,] graph = new int[v, v];

            Console.Write("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());

            for(int i = 0; i < E; i++)
            {
                Console.Write($"Edge {i+1}: ");
                var input = Console.ReadLine().Split();
                int start = int.Parse(input[0]);
                int end = int.Parse(input[1]);
                int wt = int.Parse(input[2]);

                graph[start, end] = wt;
                graph[end, start] = wt;

            }


            prim(graph);
            Console.ReadKey();


        }


        static int selectMinIndex(int[] vertexVal, bool[] setMST, int V)
        {
            int minimum = int.MaxValue;
            int vertex = -1;
            for(int i = 0; i < V; i++){

                if (!setMST[i] && vertexVal[i] < minimum)
                {
                    minimum = vertexVal[i];
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


            for(int i = 0; i < v; i++)
            {
                setMST[i] = false;
                vertexVal[i] = int.MaxValue;
            }

            parent[0] = -1;
            vertexVal[0] = 0;

            for(int i = 0; i < v ; i++)
            {

                int U = selectMinIndex(vertexVal, setMST, v);
                setMST[U] = true;

                for(int j = 0; j < v; j++)
                {
                    //relax
                    if (graph[U,j]!=0 && !setMST[j] && graph[U, j] < vertexVal[j])
                    {
                        vertexVal[j] = graph[U, j];
                        parent[j] = U;
                      
                    }
                }
            }


            int cost = 0;
            for(int i = 1; i < v; i++)
            {
                Console.WriteLine($"{parent[i]}--> {i} wt: {graph[parent[i],i]}");
                cost += graph[parent[i], i];
            }
            Console.WriteLine($"mst cost : {cost}");

        }
        
    }
}
