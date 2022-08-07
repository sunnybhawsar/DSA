// Breadth First Search
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        IList<int> result = new List<int>();
        int totalNodes = 4;
        int[, ] vertex = {{0, 1}, {0, 3}, {1, 3}, {2, 3}};

        IDictionary<int, SortedSet<int>> adj = new Dictionary<int, SortedSet<int>>();
        BuildAdjacencyList(vertex, false, ref adj);

        // Keeping the track of nodes visted/unvisited
        IDictionary<int, bool> visited = new Dictionary<int, bool>();
        for(int node = 0; node < totalNodes; node++)
            visited.Add(node, false);

        // Breadth First Search for all nodes
        for(int node = 0; node < totalNodes; node++)
        {
            if(!visited[node])
                BFS(node, ref adj, ref visited, ref result);
        }

        Print(result);
    }

    #region BFS

    // O(n) 
    private static void BFS(int node, ref IDictionary<int, SortedSet<int>> adj, ref IDictionary<int, bool> visited, ref IList<int> result)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(node);
        visited[node] = true;

        while(q.Count > 0)
        {
            int front = q.Dequeue();
            result.Add(front);

            if(adj.ContainsKey(front))
            {
                foreach(var n in adj[front])
                {
                    if(!visited[n])
                    {
                        q.Enqueue(n);
                        visited[n] = true;
                    }
                }
            }
        }
    }

    #endregion BFS

    #region Adjacency List

    // Builds Adjacency list from 2D Array of edge pairs
    private static void BuildAdjacencyList(int[, ] vertex, bool isDirected, ref IDictionary<int, SortedSet<int>> adj)
    {
        for(int i = 0; i < vertex.GetLength(0); i++)
        {
            if(!adj.ContainsKey(vertex[i, 0]))
                adj.Add(vertex[i, 0], new SortedSet<int>() {vertex[i, 1]});
            else
                adj[vertex[i, 0]].Add(vertex[i, 1]);

            // For undirected graph
            if(!isDirected)
            {
                if(!adj.ContainsKey(vertex[i, 1]))
                    adj.Add(vertex[i, 1], new SortedSet<int>() {vertex[i, 0]});
                else
                    adj[vertex[i, 1]].Add(vertex[i, 0]);
            }
        }
    }

    private static void PrintAdjacencyList(IDictionary<int, SortedSet<int>> adj)
    {
        Console.Write("\nAdjacency List: ");
        
        foreach(var key in adj.Keys)
        {
            Console.Write("\n" + key + " --> ");
            foreach(var node in adj[key])
            {
                Console.Write(node + " ");
            }
        }
    }

    #endregion Adjacency List

    #region Print
    private static void Print(IList<int> result)
    {
        Console.WriteLine("BFS: ");
        foreach(var res in result)
            Console.Write(res + " ");
    }
    #endregion Print
}

// Sunny Bhawsar