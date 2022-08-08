// Depth First Search

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int totalNodes = 5;
        int[, ] vertex = {{0, 2}, {2, 1}, {2, 4}, {1, 3}, {3,4}};
        IList<int> result = new List<int>();

        // Preparing Adjacency List
        IDictionary<int, SortedSet<int>> adj;
        BuildAdjacencyList(false, ref vertex, out adj);
        
        // Preparing visited dictionary
        IDictionary<int, bool> visited = new Dictionary<int, bool>();
        for(int i = 0; i < totalNodes; i++)
            visited.Add(i, false);

        for(int node = 0; node < totalNodes; node++)
        {
            if(!visited[node])
                DFS(node, ref adj, ref visited, ref result);
        }

        Print(result);
    }

    // DFS - Recursive
    // Time: O(n), Space: O(n)
    private static void DFS(int node, ref IDictionary<int, SortedSet<int>> adj, 
        ref IDictionary<int, bool> visited, ref IList<int> result)
    {
        result.Add(node);
        visited[node] = true;

        if(adj.ContainsKey(node))
        {
            foreach(var n in adj[node])
            {
                if(!visited[n])
                    DFS(n, ref adj, ref visited, ref result);
            }
        }
    }

    // Adjacency List
    private static void BuildAdjacencyList(bool isDirected, ref int[, ] vertex, out IDictionary<int, SortedSet<int>> adj)
    {
        adj = new Dictionary<int, SortedSet<int>>();

        for(int i = 0; i < vertex.GetLength(0); i++)
        {
            if(!adj.ContainsKey(vertex[i, 0]))
                adj.Add(vertex[i, 0], new SortedSet<int>() {vertex[i, 1]});
            else
                adj[vertex[i, 0]].Add(vertex[i, 1]);

            if(!isDirected)
            {
                if(!adj.ContainsKey(vertex[i, 1]))
                    adj.Add(vertex[i, 1], new SortedSet<int>() {vertex[i, 0]});
                else
                    adj[vertex[i, 1]].Add(vertex[i, 0]);
            }
        }
    }

    // Print Result
    private static void Print(IList<int> result)
    {
        Console.WriteLine("DFS: ");
        foreach(var res in result)
            Console.Write(res + " ");
    }
}

// Sunny Bhawsar