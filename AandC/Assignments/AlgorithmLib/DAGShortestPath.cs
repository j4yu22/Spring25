/* CSE 381 - DAG Shortest Path
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S5.
*
*  Instructions: Implement the Sort and Search functions per the instructions
*  in the comments.  Run all tests in DAGShortestPathTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class DAGShortestPath
{
    /* Topologically sort all vertices in a graph and return the sorted
     * list of vertex ID's.  Use a Stack object (available in C#).
     *
     *  Inputs:
     *     g - Graph
     *  Outputs:
     *     Return a sorted list of vertex ID's
     */
    public static List<int> Sort(Graph g)
    {
        int size = g.Size(); // verticies in graph
        bool[] visited = new bool[size]; // track visited verticies
        Stack<int> stack = new(); // store topological order

        void DFS(int v) // DFS helper to visit nodes
        {
            visited[v] = true;
            foreach (var edge in g.Edges(v)) // visit neighbors of current index
            {
                if (!visited[edge.DestId])
                    DFS(edge.DestId);
            }
            stack.Push(v); // after visiting neighbors, push to stack
        }

        for (int i = 0; i < size; i++) // call DFS for all unvisited vertices
        {
            if (!visited[i])
                DFS(i);
        }

        return stack.ToList(); // return reverse post order
    }

    /* Find the shortest path from a starting vertex to all
     * vertices in a DAG.  This function will need to
     * call the Sort function to obtain the topologically
     * sorted list of vertices from the graph.
     *
     *  Inputs:
     *     g - Directed Acyclic Graph
     *     startVertex - Starting vertex ID
     *  Outputs:
     *     (distance list, predecessor list) 
     *     NOTE: The above two output lists should contain Graph.INF as needed
     */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        int size = g.Size(); // number of vertices
        List<int> dist = Enumerable.Repeat(Graph.INF, size).ToList(); // distance from start to each vertex
        List<int> pred = Enumerable.Repeat(Graph.INF, size).ToList(); // predecessor list for shortest paths

        dist[startVertex] = 0; // distance to start is 0

        var topoOrder = Sort(g); // get vertices in topological order

        foreach (int u in topoOrder) // relax edges
        {
            if (dist[u] != Graph.INF) // make sure known distance before processing
            {
                foreach (var edge in g.Edges(u))
                {
                    int v = edge.DestId;
                    int weight = edge.Weight;

                    if (dist[u] + weight < dist[v]) // relax edge is shorter path
                    {
                        dist[v] = dist[u] + weight;
                        pred[v] = u;
                    }
                }
            }
        }

        return (dist, pred); // return distance and predecessor lists
    }
}