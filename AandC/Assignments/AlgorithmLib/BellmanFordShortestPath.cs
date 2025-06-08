/* CSE 381 - Bellman Ford
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S5.
*
*  Instructions: Implement the ShortestPath function per the instructions
*  in the comments.  Run all tests in BellmanFordTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class BellmanFordShortestPath
{
    /* Find the Shortest Path in a graph using the Bellman Ford Algorithm
    *  with the ability to detect a negative cycle.
    *
    *  Inputs:
    *     g - The Graph (using the Graph class provided)
    *     startVertex - The vertex ID to calculate shortest path from
    *  Outputs:
    *     (Distance List, Predecessor List)
    *     NOTE: The above two output lists should contain Graph.INF as needed
    *
    *  Note: If a negative cycle exists, then the function must return
    *  a tuple of two empty lists. 
    */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        // get number of vertices
        int n = g.Size();
        // set all distances to infinity
        List<int> distance = Enumerable.Repeat(Graph.INF, n).ToList();
        // set all predecessors to infinity
        List<int> pred = Enumerable.Repeat(Graph.INF, n).ToList();
        // distance to start vertex is 0
        distance[startVertex] = 0;  

        // relax all edges v-1 times
        for (int i = 0; i < n - 1; i++)
        {
            for (int u = 0; u < n; u++)
            {
                // go through all edges from u
                foreach (var edge in g.Edges(u))
                {
                    int v = edge.DestId;
                    int weight = edge.Weight;

                    // update if shorter path found
                    if (distance[u] != Graph.INF && distance[u] + weight < distance[v])
                    {
                        distance[v] = distance[u] + weight;
                        pred[v] = u;
                    }
                }
            }
        }

        // check for negative weight cycles
        for (int u = 0; u < n; u++)
        {
            foreach (var edge in g.Edges(u))
            {
                int v = edge.DestId;
                int weight = edge.Weight;

                // if shorter path found, cycle exists
                if (distance[u] != Graph.INF && distance[u] + weight < distance[v])
                {
                    // return empty if cycle
                    return (new List<int>(), new List<int>());  
                }
            }
        }

        return (distance, pred);  // return final distances and predecessors
    }
}
