# Finder-Shortest-Path-Graph-DAG

## English:
_The weighted directed acyclic graph G is described with the help of a neighborhood list (note (u,r) means that on the edge to the neighbor u has a weight r):_
   
            Adj[a]=(b,3);
            Adj[b]=(c,2);
            Adj[c]=(d,4);
            Adj[d]= (e,3);
            Adj[e]=∅;
            Adj[f]=(d,5), (e,2);
            Adj[g]=(b,3), (c,6), (f,4);
            Adj[h]=(a,4), (b,2), (g,5).
            
_Calculate the order of topological sorting at the vertices of graph G and use this order to calculate the shortest paths from vertex a._

Code transcribed to C# from [source](https://www.sanfoundry.com/cpp-program-implement-shortest-path-algorithm-dag-using-topological-sorting/)
