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
        //Funkcja spajająca Id
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
        //Funkcja tworząca z Grafu macierz odległości
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

        // funkcja implementująca algorytm dijkstry kozystającego z macierzy odległości
        void IDijkstra.Run(int startVertex, List<float> WageList)
        {
            int size = Graph.Nodes.Count;

            CreateAdjacencyMatrix(size, WageList);

            startVertex = NodeIDs.First(x=>x.Value==startVertex).Key;

            int nVertices = AdjacencyMatrix.GetLength(0);

            // najkrótsza ścieżka ze źródla do wierzchołka i znajduje się w shortestDistances[i]
            float[] shortestDistances = new float[nVertices];

            // added[i] będzie prawdziwe jeżeli krawędź i będzie zawarta w drzewie najkrótszej drogi
            // lub najkrótsza odległość ze źródła do i będzie obliczona.
            bool[] added = new bool[nVertices];

            for (int vertexIndex = 0; vertexIndex < nVertices;
                                                vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            //Odległość wierzchołka od samego siebie zawsze wynosi 0
            shortestDistances[startVertex] = 0;

            // tablica rodziców w dzrewie najkrótsze ścieżki
            int[] parents = new int[nVertices];

            //startowa krawędź nie posiada rodzica
            parents[startVertex] = NO_PARENT;

            // znalezienie najkrótszej ścieżki dla wszystkich rodziców
            for (int i = 1; i < nVertices; i++)
            {

                // nearestVertex, jest równa -1 w pierwsze iteracji 
                // Wybierana zostaje nakrótsza wartośc wagi krawędzi ze zbioru dostępnych krawędzi
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

                //Zaznacz najbliższą krawędź jako obecnie przetwarzaną
                added[nearestVertex] = true;

                //Aktualizacja obecnej najkrótszej odległości
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
        //Funkcja zapisująca wynik
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
                         AlghoritmResult[vertexIndex].TargetNodeId = NodeIDs[vertexIndex];
                         AlghoritmResult[vertexIndex].Value = distances[vertexIndex];
                    WritePath(AlghoritmResult[vertexIndex].Path,vertexIndex, parents);
                }
            }
        }

        //Funkcja zapisująca odwiedzone Miasta
        private void WritePath(List<int> Path,int currentVertex, int[] parents)
        {

            // Base case : Odwiedzono wierzchołek źródła
            if (currentVertex == NO_PARENT)
            {
                return;
            }
            WritePath(Path,parents[currentVertex], parents);
            Path.Add(NodeIDs[currentVertex]);
            
        }
    }
}
