using System;
using System.Collections;
using System.Collections.Generic;

namespace FindShortestPathGraphDAG
{
    class AdjListNode
    {
        public int v;
        public int weight;
        public AdjListNode(int _v, int w)
        {
            v = _v;
            weight = w;
        }
    };


    class Graph
    {
        readonly List<char> edges = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        public int _V; // No. of vertices'
        public List<List<AdjListNode>> adj;

        public Graph(int V)
        {
            _V = V;
            adj = new List<List<AdjListNode>>(V);
            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<AdjListNode>());
            }

        }

        public void addEdge(int u, int v, int weight)

        {

            AdjListNode node = new AdjListNode(v, weight);
            adj[u].Add(node); // Add v to u's list

        }

        public void topologicalSortUtil(int v, bool[] visited, Stack<int> stack)

        {
            visited[v] = true;

            foreach (var i in adj[v])
            {
                AdjListNode node = i;
                if (!visited[node.v])
                    topologicalSortUtil(node.v, visited, stack);
            }

            stack.Push(v);

        }


        public void shortestPath(int s)
        {

            Stack<int> stack = new Stack<int>();
            int[] dist = new int[_V];
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            for (int i = 0; i < _V; i++)
            {
                if (visited[i] == false)
                    topologicalSortUtil(i, visited, stack);
            }


            for (int i = 0; i < _V; i++)
            { dist[i] = int.MaxValue; }

            dist[s] = 0;

            while (stack.Count != 0)
            {

                int u = stack.Peek();

                stack.Pop();

                if (dist[u] != int.MaxValue)

                {
                    for (int i = 0; i < adj[u].Count; i++)
                    {
                        if (dist[adj[u][i].v] > dist[u] + adj[u][i].weight)
                        { 
							dist[adj[u][i].v] = dist[u] + adj[u][i].weight; 
						}
                    }
                }

            }



            for (int i = 0; i < _V; i++)
            {
                if (dist[i] == Int32.MaxValue) { Console.WriteLine("To " + edges[i] + " : INF "); } 
				else { Console.WriteLine("To " + edges[i] + " : " + dist[i] + " "); }
            }

        }
        public static void Main(string[] args)
        {
            Graph g = new Graph(8);
            g.addEdge(0, 1, 3); // Adj[a] = (b, 3);
            g.addEdge(1, 2, 2); // Adj[b] = (c, 2)
            g.addEdge(2, 3, 4); // Adj[c] = (d, 4);
            g.addEdge(3, 4, 3); //Adj[d] = (e, 3);
            //g.addEdge(4, null, null); // Adj[e] =∅;
            g.addEdge(5, 3, 5); // Adj[f] = (d, 5), (e, 2);
            g.addEdge(5, 4, 2);
            g.addEdge(6, 1, 3); //  Adj[g] = (b, 3), (c, 6), (f, 4); 
            g.addEdge(6, 2, 6);
            g.addEdge(6, 5, 4);
            g.addEdge(7, 0, 4); // Adj[h] = (a, 4), (b, 2), (g, 5).
            g.addEdge(7, 1, 2);
            g.addEdge(7, 6, 5);


            int s = 0;

            Console.WriteLine("Following are shortest distances from source " + g.edges[0]);

            g.shortestPath(s);
            Console.ReadKey();
        }

    };
}
