using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace prim4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the number of vertices: ");
            int V= int.Parse(Console.ReadLine());

            // use the mumber of vertices as dimension for the graph

            int[,] graph = new int[V,V];


            Console.Write("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());

            Console.Write("Enter edges following format (start, end, weight)");
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


            findMST(graph);
            Console.ReadKey();

        }

        static int selectMinIndex(int[] vValue, bool[] setMST, int v)
        {
            int minimum = int.MaxValue;
            int vertex = -1;
            for( int i = 0; i < v; i++)
            {
                if (!setMST[i]&& vValue[i] < minimum)
                {
                    minimum = vValue[i];
                    vertex = i;

                }


            }

            return vertex;
        }

        static void findMST(int[,] graph)
        {
            //requirements
            int v = graph.GetLength(0);

            int[] parent = new int[v];
            int[] vValue = new int[v];
            bool[] setMST = new bool[v];


            for(int i = 0; i < v; i++)
            {
                vValue[i] = int.MaxValue;
                setMST[i] = false;
            }

            parent[0] = -1;
            vValue[0] = 0;

            //START ALGO

            for(int i = 0; i < v - 1; i++)
            {
                ///select
                int U = selectMinIndex(vValue, setMST, v);


                //setmst to true
                setMST[U] = true;

                //relax
               for(int j = 0; j < v; j++)
                {
                    if (graph[U,j]!=0 && !setMST[j] && graph[U, j] < vValue[j])
                    {
                        vValue[j] = graph[U, j];
                        parent[j] = U;

                    }
                }
            }

            int cost = 0;
            for(int i = 1; i < v; i++)
            {
                Console.WriteLine($"{parent[i]}-->{i} {graph[parent[i],i]}");
                cost += graph[parent[i], i];
            }

            Console.WriteLine($"mst weight: {cost}");


        }



    }
}
