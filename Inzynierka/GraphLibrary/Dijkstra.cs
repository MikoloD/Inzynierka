using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibrary
{
    public class Dijkstra : IDijkstra
    {

        private readonly int NO_PARENT = -1;
        private Dictionary<int, int> NodeIDs { get; set; }
        private float[,] AdjacencyMatrix { get; set; }
        public DijkstraResult[] AlghoritmResult { get; set; }
        public Graph Graph { get; set; }
        public int TargetNodeId { get; set; }

        public Dijkstra(Graph graph)
        {
            Graph = graph;
            int size = Graph.Nodes.Count;
            AlghoritmResult = new DijkstraResult[size];
            for (int i = 0; i < size; i++)
            {
                AlghoritmResult[i] = new DijkstraResult();
            }
        }
        private void CreateNodeDictionary(int size)
        {
            NodeIDs = new Dictionary<int, int>();
            for (int i = 0; i < size; i++)
            {
                NodeIDs.Add(i, Graph.Nodes[i].NodeId);
                if (TargetNodeId == Graph.Nodes[i].NodeId)
                    TargetNodeId = i;
            }
        }
        private void CreateAdjacencyMatrix(int size, List<float> WageList)
        {
            if (WageList != null)
            {
                for (int i = 0; i < Graph.Edges.Count; i++)
                {
                    Graph.Edges[i].Wage = WageList[i];
                }
            }
            AdjacencyMatrix = new float[size, size];
            CreateNodeDictionary(size);
            foreach (var item in Graph.Edges)
            {
                int x = NodeIDs.First(x => x.Value == item.SourceNodeId).Key;
                int y = NodeIDs.First(x => x.Value == item.TargetNodeId).Key;
                AdjacencyMatrix[x, y] = item.Wage;
                AdjacencyMatrix[y, x] = item.Wage;
            }
        }

        // Function that implements Dijkstra's
        // single source shortest path
        // algorithm for a graph represented
        // using adjacency matrix
        // representation
        void IDijkstra.Run(int startVertex, List<float> WageList)
        {
            int size = Graph.Nodes.Count;

            CreateAdjacencyMatrix(size, WageList);

            startVertex = NodeIDs.First(x=>x.Value==startVertex).Key;

            int nVertices = AdjacencyMatrix.GetLength(0);

            // shortestDistances[i] will hold the
            // shortest distance from src to i
            float[] shortestDistances = new float[nVertices];

            // added[i] will true if vertex i is
            // included / in shortest path tree
            // or shortest distance from src to
            // i is finalized
            bool[] added = new bool[nVertices];

            // Initialize all distances as
            // INFINITE and added[] as false
            for (int vertexIndex = 0; vertexIndex < nVertices;
                                                vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            // Distance of source vertex from
            // itself is always 0
            shortestDistances[startVertex] = 0;

            // Parent array to store shortest
            // path tree
            int[] parents = new int[nVertices];

            // The starting vertex does not
            // have a parent
            parents[startVertex] = NO_PARENT;

            // Find shortest path for all
            // vertices
            for (int i = 1; i < nVertices; i++)
            {

                // Pick the minimum distance vertex
                // from the set of vertices not yet
                // processed. nearestVertex is
                // always equal to startNode in
                // first iteration.
                int nearestVertex = -1;
                float shortestDistance = float.MaxValue;
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    if (!added[vertexIndex] &&
                        shortestDistances[vertexIndex] <
                        shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }

                // Mark the picked vertex as
                // processed
                added[nearestVertex] = true;

                // Update dist value of the
                // adjacent vertices of the
                // picked vertex.
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    float edgeDistance = AdjacencyMatrix[nearestVertex, vertexIndex];

                    if (edgeDistance > 0
                        && ((shortestDistance + edgeDistance) <
                            shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance +
                                                        edgeDistance;
                    }
                }
            }

            WriteSolution(startVertex, shortestDistances, parents);
        }
        // A utility function to print
        // the constructed distances
        // array and shortest paths
        private void WriteSolution(int startVertex,
            float[] distances,
            int[] parents)
        {
            int nVertices = distances.Length;
            
            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                if (vertexIndex != startVertex)
                {
                         AlghoritmResult[vertexIndex].SourceNodeId = NodeIDs[startVertex];
                         AlghoritmResult[vertexIndex].TargetSorceId = NodeIDs[vertexIndex];
                         AlghoritmResult[vertexIndex].Value = distances[vertexIndex];
                    WritePath(AlghoritmResult[vertexIndex].Path,vertexIndex, parents);
                }
            }
        }

        // Function to print shortest path
        // from source to currentVertex
        // using parents array
        private void WritePath(List<int> Path,int currentVertex, int[] parents)
        {

            // Base case : Source node has
            // been processed
            if (currentVertex == NO_PARENT)
            {
                return;
            }
            WritePath(Path,parents[currentVertex], parents);
            Path.Add(NodeIDs[currentVertex]);
            
        }
    }
}
