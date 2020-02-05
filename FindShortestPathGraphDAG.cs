using System;
using System.Collections.Generic;

/*
    English:
       The weighted directed acyclic graph G is described with the help of a neighborhood list (note (u,r) means that on the edge to the neighbor u has a weight r):
            Adj[a]=(b,3);
            Adj[b]=(c,2);
            Adj[c]=(d,4);
            Adj[d]= (e,3);
            Adj[e]=∅;
            Adj[f]=(d,5), (e,2);
            Adj[g]=(b,3), (c,6), (f,4);
            Adj[h]=(a,4), (b,2), (g,5).
        Calculate the order of topological sorting at the vertices of graph G and use this order to calculate the shortest paths from vertex a.
*/


namespace FindShortestPathGraphDAG
{
    class AdjListNode
    {
        public int vertex;
        public int weight;

        public AdjListNode(int v, int w)
        {
            vertex = v;
            weight = w;
        }
    };


    // Class to represent a graph using adjacency list representation

    class Graph
    {
        private const int maxValue = int.MaxValue;
        public int _V; // No. of vertices'
        public List<List<AdjListNode>> adj;

        public Graph(int V)

        {
            _V = V;

            adj = new List<List<AdjListNode>>();
            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<AdjListNode>());
            }
        }

        // function to add an edge to graph

        public void addEdge(int u, int v, int weight)

        {

            AdjListNode node = new AdjListNode(v, weight);
            adj[u].Add(node); // Add v to u's list

        }

        // A function used by shortestPath

        public void topologicalSortUtil(int v, bool[] visited, Stack<int> stack)

        {

            // Mark the current node as visited

            visited[v] = true;
            // Recur for all the vertices adjacent to this vertex
            foreach (var i in adj[v])
            {
                AdjListNode node = i;
                if (!visited[node.vertex])
                    topologicalSortUtil(node.vertex, visited, stack);
            }

            stack.Push(v);

        }


        // Finds shortest paths from given source vertex

        public void shortestPath(int s)

        {

            Stack<int> stack = new Stack<int>();

            int[] dist = new int[_V];



            // Mark all the vertices as not visited

            bool[] visited = new bool[_V];

            for (int i = 0; i < _V; i++)
                visited[i] = false;



            // Call the recursive helper function to store Topological Sort

            // starting from all vertices one by one

            for (int i = 0; i < _V; i++)
                if (visited[i] == false)
                    topologicalSortUtil(i, visited, stack);


            // Initialize distances to all vertices as infinite and distance

            // to source as 0

            for (int i = 0; i < _V; i++)
                dist[i] = int.MaxValue;
            dist[s] = 0;



            // Process vertices in topological order

            while (stack.Count != 0)
            {

                // Get the next vertex from topological order

                int u = stack.Peek();
                stack.Pop();

                // Update distances of all adjacent vertices

                if (dist[u] != int.MaxValue)
                    foreach (var i in adj[u])
                        if (dist[i.vertex] > dist[u] + i.weight)
                            dist[i.vertex] = dist[u] + i.weight;
            }



            // Print the calculated shortest distances

            for (int i = 0; i < _V; i++)
            {
                if (dist[i] == maxValue)
                    Console.WriteLine("To " + edges[i] + " : INF ");
                else
                    Console.WriteLine("To " + edges[i] + " : " + dist[i] + " ");
            }

        }
        public enum Vertex { a , b, c, d, e, f, g, h }
        public static readonly IList<char> edges = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' }.AsReadOnly();

        public static void Main(string[] args)
        {
            int a = (int)Vertex.a,
                b = (int)Vertex.b,
                c = (int)Vertex.c,
                d = (int)Vertex.d,
                e = (int)Vertex.e,
                f = (int)Vertex.f,
                g = (int)Vertex.g,
                h = (int)Vertex.h;

            Graph G = new Graph(8);

            G.addEdge(a, b, 3); // Adj[a] = (b, 3)
            G.addEdge(b, c, 2); // Adj[b] = (c, 2)
            G.addEdge(c, d, 4); // Adj[c] = (d, 4)
            G.addEdge(d, e, 3); // Adj[d] = (e, 3)
            G.addEdge(f, d, 5); // Adj[f] = (d, 5)
            G.addEdge(f, e, 2); // Adj[f] = (e, 2)
            G.addEdge(g, b, 3); // Adj[g] = (b, 3)
            G.addEdge(g, c, 6); // Adj[g] = (c, 6)
            G.addEdge(g, f, 4); // Adj[g] = (f, 4)
            G.addEdge(h, a, 4); // Adj[h] = (a, 4)
            G.addEdge(h, b, 2); // Adj[h] = (b, 2)
            G.addEdge(h, g, 5); // Adj[h] = (g, 5)

            int s = 0;

            Console.WriteLine("Following are shortest distances from source/vertex " + edges[0] + ":");

            G.shortestPath(s);
            Console.ReadKey();
        }

    };
}
