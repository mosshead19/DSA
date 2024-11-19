using System;

class MST
{
    static int V = 6; // Number of vertices

    static int SelectMinVertex(int[] value, bool[] setMST)
    {
        int minimum = int.MaxValue;
        int vertex = -1;

        for (int i = 0; i < V; ++i)
        {
            if (!setMST[i] && value[i] < minimum)
            {
                vertex = i;
                minimum = value[i];
            }
        }
        return vertex;
    }

    static void FindMST(int[,] graph)
    {
        int[] parent = new int[V]; // Stores MST
        //NODE
        int[] value = new int[V]; // Used for edge relaxation(node)
        bool[] setMST = new bool[V]; // TRUE -> Vertex is included in MST

        // Initialize arrays
        for (int i = 0; i < V; i++)
        {
            value[i] = int.MaxValue;
            setMST[i] = false;
        }

        // Start from vertex 0
        parent[0] = -1; // Start node has no parent
        value[0] = 0; // Start node has value=0 to get picked first

        // Form MST with (V-1) edges
        for (int i = 0; i < V - 1; ++i)
        {
            // Select best Vertex by applying greedy method
            int U = SelectMinVertex(value, setMST);
            setMST[U] = true; // Include new Vertex in MST

            // Relax adjacent vertices (not yet included in MST)
            for (int j = 0; j < V; ++j)
            {
                /* 3 constraints to relax:
                     1. Edge is present from U to j.
                     2. Vertex j is not included in MST.
                     3. Edge weight is smaller than current edge weight.
                */

 
                if (graph[U, j] != 0 && !setMST[j] && graph[U, j] < value[j])
                {
                    value[j] = graph[U, j];
                    parent[j] = U;
                }
            }
        }

        // Print MST
        for (int i = 1; i < V; ++i)
            Console.WriteLine($"U->V: {parent[i]}->{i}  wt = {graph[parent[i], i]}");
    }

    static void Main(string[] args)
    {
        int[,] graph = {
            { 0, 4, 6, 0, 0, 0 },
            { 4, 0, 6, 3, 4, 0 },
            { 6, 6, 0, 1, 8, 0 },
            { 0, 3, 1, 0, 2, 3 },
            { 0, 4, 8, 2, 0, 7 },
            { 0, 0, 0, 3, 7, 0 }
        };

        FindMST(graph);
        Console.ReadKey();
    }
}
