using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_sAlgorithm
{
    internal class Graph
    {
        private class Edge
        {
            public string StartNode { get; set; }
            public string EndNode { get; set; }
            public int Weight { get; set; }
        }

        internal static Graph LoadGraphFromTxtFile(string fileName)
        {
            StreamReader streamReader = new StreamReader("../../" + fileName);
            Graph graph = new Graph();
            while (!streamReader.EndOfStream)
            {
                Edge edge = new Edge();
                string nodeToNodePathAndWeightString = streamReader.ReadLine();
                string[] nodeToNodePathAndWeightArray = nodeToNodePathAndWeightString.Split(' ');
                edge.StartNode = nodeToNodePathAndWeightArray[0];
                edge.EndNode = nodeToNodePathAndWeightArray[1];
                edge.Weight = Int32.Parse(nodeToNodePathAndWeightArray[2]);
                graph.AddEdge(edge);
            }
            return graph;
        }

        private List<Edge> graphEdges;

        internal List<string> GetNeighbourVerticesSorted(string parentVertex)
        {
            return graphEdges.Where(x => x.StartNode == parentVertex).OrderBy(x => x.Weight).Select(x => x.EndNode).ToList();
        }

        internal int GetEdgeWeight(string startNode, string endNode)
        {
            return graphEdges.FirstOrDefault(x => x.StartNode == startNode && x.EndNode == endNode).Weight;
        }

        internal Graph()
        {
            graphEdges = new List<Edge>();
        }

        private void AddEdge(Edge edge)
        {
            graphEdges.Add(edge);
        }

        internal List<string> GetAllVertices()
        {
            List<string> vertices = new List<string>();
            vertices.AddRange(graphEdges.Select(x => x.StartNode));
            vertices.AddRange(graphEdges.Select(x => x.EndNode));
            return vertices.Distinct().ToList();
        }

    }
}
