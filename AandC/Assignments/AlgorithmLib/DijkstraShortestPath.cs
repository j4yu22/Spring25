/* CSE 381 - Dijkstra Shortest Path
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S5.
*
*  Instructions: Implement the ShortestPath function per the instructions
*  in the comments.  Run all tests in DijkstraShortestPathTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class DijkstraShortestPath
{

    /* Find the shortest path from a starting vertex to all
     * vertices in a graph using Dijkstra.  Use a PQueue object
     * (code already provided for you) in your implementation for the 
     * priority queue.
     *
     *  Inputs:
     *     g - Graph
     *     startVertex - Starting vertex ID
     *  Outputs:
     *     (distance list, predecessor list)
     *     NOTE: The above two output lists should contain Graph.INF as needed
     */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        int n = g.Size();  // number of vertices in the graph

        // initialize distances with infinity
        List<int> distance = Enumerable.Repeat(Graph.INF, n).ToList();
        distance[startVertex] = 0;  // distance to start vertex is 0

        // initialize predecessors as undefined
        List<int> pred = Enumerable.Repeat(Graph.INF, n).ToList();

        // use a priority queue to always expand the closest unvisited node
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(startVertex, 0);

        while (pq.Count > 0)
        {
            int u = pq.Dequeue();  // get vertex with smallest distance

            // visit all neighbors of u
            foreach (Edge edge in g.Edges(u))
            {
                int v = edge.DestId;
                int weight = edge.Weight;

                // relax edge if shorter path is found
                if (distance[u] != Graph.INF && distance[u] + weight < distance[v])
                {
                    distance[v] = distance[u] + weight;
                    pred[v] = u;
                    pq.Enqueue(v, distance[v]);
                }
            }
        }

        // return distance and predecessor lists
        return (distance, pred);
    }

}