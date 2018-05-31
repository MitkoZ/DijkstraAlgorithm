using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_sAlgorithm
{
    internal static class Dijkstra_sWrapper
    {
        internal static Stack<string> Dijkstra(string sourcePoint, string targetPoint, Graph graph)
        {
            List<string> verticesStringList = graph.GetAllVertices();
            Dictionary<string, Vertex> verticesDictionary = new Dictionary<string, Vertex>();
            InitializeVerticesDictionary(sourcePoint, verticesStringList, verticesDictionary);

            while (verticesDictionary.Values.ToList().Any(x => x.IsProcessed == false && x.ShortestDistanceFromTarget != int.MaxValue))
            {
                KeyValuePair<string, Vertex> keyValuePair = verticesDictionary.Where(x => x.Value.IsProcessed == false).ToList().Min();
                string vertexKey = keyValuePair.Key;
                Vertex currentVertex = keyValuePair.Value;
                List<string> neighbourVertices = graph.GetNeighbourVerticesSorted(keyValuePair.Key);
                foreach (string neighbourVertexString in neighbourVertices)
                {
                    Vertex neighbourVertex = verticesDictionary[neighbourVertexString];
                    int newDistanceFromStartVertex = currentVertex.ShortestDistanceFromTarget + graph.GetEdgeWeight(keyValuePair.Key, neighbourVertexString);
                    if (newDistanceFromStartVertex < neighbourVertex.ShortestDistanceFromTarget)
                    {
                        verticesDictionary[neighbourVertexString].ShortestDistanceFromTarget = newDistanceFromStartVertex;
                        verticesDictionary[neighbourVertexString].PreviousVertex = keyValuePair.Key;
                    }
                }
                verticesDictionary[vertexKey].IsProcessed = true;
            }

            return FormShortestPath(targetPoint, verticesDictionary);

        }

        private static Stack<string> FormShortestPath(string targetPoint, Dictionary<string, Vertex> verticesDictionary)
        {
            Stack<string> traverseStack = new Stack<string>();
            KeyValuePair<string, Vertex> vertex = verticesDictionary.Where(x => x.Key == targetPoint).FirstOrDefault(); // the end node
            while (vertex.Value?.PreviousVertex != null) //it hasn't been reached by the chosen node
            {
                traverseStack.Push(vertex.Value.PreviousVertex + " Goes To " + vertex.Key); //the end edge
                vertex = verticesDictionary.Where(x => x.Key == vertex.Value.PreviousVertex).FirstOrDefault();
            }
            return traverseStack;
        }



        private static void InitializeVerticesDictionary(string sourcePoint, List<string> verticesStringList, Dictionary<string, Vertex> verticesDictionary)
        {
            foreach (string vertexString in verticesStringList)
            {
                Vertex vertex = new Vertex
                {
                    ShortestDistanceFromTarget = int.MaxValue
                };

                if (vertexString == sourcePoint)
                {
                    vertex.ShortestDistanceFromTarget = 0;
                }

                verticesDictionary.Add(vertexString, vertex);
            }
        }

    }
}
