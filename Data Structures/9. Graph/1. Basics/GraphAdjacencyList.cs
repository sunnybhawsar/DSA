using System;
using System.Collections.Generic;

public class Graph
{
    private readonly IDictionary<int, SortedSet<int>> adj;
    private bool isDirected;

    public Graph(int totalNodes, bool isDirected)
    {
        this.adj = new Dictionary<int, SortedSet<int>>(totalNodes);
        this.isDirected = isDirected;
    }

    // Adds the edge to adjacency list
    public void AddEdge(int n1, int n2)
    {
        if(!adj.ContainsKey(n1))
            adj.Add(n1, new SortedSet<int>() {n2});
        else
            adj[n1].Add(n2);

        if(isDirected)
        {
            if(!adj.ContainsKey(n2))
                adj.Add(n2, new SortedSet<int>() {n1});
            else
                adj[n2].Add(n1);
        }
    }

    // Prints the adjacency list
    public void Print()
    {
        foreach(var key in adj.Keys)
        {
            Console.Write("\n"+ key + " --> ");
            foreach(var node in adj[key])
                Console.Write(node + " ");
        }
    }
}

public class Program
{
    // Driver
    public static void Main(string[] args)
    {
        int totalNodes = 4, totalEdges = 4;

        Graph graph = new Graph(totalNodes, false);

        // Input from console
        for(int i = 0; i < totalEdges; i++)
        {
            int n1 = Convert.ToInt32(Console.ReadLine());
            int n2 = Convert.ToInt32(Console.ReadLine());

            graph.AddEdge(n1, n2);
        }

        Console.WriteLine("\nAdjacency List: ");
        graph.Print();
    }
}

// Sunny Bhawsar