using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prim3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the number of vertices: ");
            int v = int.Parse(Console.ReadLine());
            //use vertices to create the graph

            int[,] graph = new int[v, v];


            //fill the graph
            Console.Write("Enter the number of edges: ");
            int E = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the edges: (start,end, weight)");
            for(int i = 0; i < E; i++)
            {
                Console.Write($"Edge {i+1}: ");
                var input = Console.ReadLine().Split(' ');
                int start = int.Parse(input[0]);
                int end = int.Parse(input[1]);
                int wt = int.Parse(input[2]);
                graph[start, end] = wt;
                graph[end, start] = wt;




            }


            Console.WriteLine("MST: ");
            findMST(graph);
            Console.ReadKey();




        }


        static int SelectMinVertex(int[] value, bool[] setMST, int V)
        {
            int minimum = int.MaxValue;
            int vertex = -1;

            for(int i = 0; i < V;i++)
            {
                if (!setMST[i] && value[i] < minimum)
                {
                    minimum = value[i];
                    vertex = i;
                }
            }

            return vertex;
        }


        static void findMST(int[,] graph)
        {
           //STEP 1: SETTING UP REQUIREMENTS
           //MST bool
           //parent int
           //nodeList int
            //get the length of the graph
            int v = graph.GetLength(0);

            //SET setMST for every node to false
            //and nodeList initially to int.Maax val
            bool[] setMST = new bool[v];
            int[] nodeList = new int[v];

            for (int i = 0; i < v; i++)
            {
                setMST[i] = false;
                nodeList[i] = int.MaxValue;

            }

            //initialize
            int[] parent = new int[v];
            parent[0] = -1;
            nodeList[0] = 0;

            //STEP2 START THE ALGO

            for(int i = 0; i < v; i++)
            {
                //SELECT minimum node that is not in the setmst and has min value
                int U = SelectMinVertex(nodeList, setMST, v);

                //SET selected to setMST[selected] true;
                setMST[U] = true;
                //RELAX Adjacent vertices

                for(int j = 0; j < v; j++)// used less than v instead of v-1
                    //because we wanna relax all reachable edges
                {

                    //condition for relaxation
                    //1. there is connection between U,j
                    //2. the graph[U,J] OR the node distance is less than the value of the node it is connected to
                    //3. the j is not yet included in the mst
                    if (!setMST[j] && graph[U,j]!=0 && graph[U, j] < 
                        
                        nodeList[j])
                    {
                        nodeList[j] = graph[U, j];
                        parent[j] = U;

                    }
                }


            }

            int totalWeight = 0;
            for (int i = 1; i < v;i++)
            {
                Console.WriteLine($"{parent[i]}-->{i} wt = {graph[parent[i],i]}");
                totalWeight += graph[parent[i], i];
            }

            Console.WriteLine($"mst cost: {totalWeight}");

        }

    }
}
