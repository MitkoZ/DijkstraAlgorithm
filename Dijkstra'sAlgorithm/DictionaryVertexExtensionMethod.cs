using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_sAlgorithm
{
    internal static class DictionaryVertexExtensionMethod
    {
        internal static KeyValuePair<string, Vertex> Min(this List<KeyValuePair<string, Vertex>> dictionary) //gets the vertex with the minimum ShortestDistanceFromTarget in the form of a key value pair
        {
            return dictionary.Where(x => x.Value.ShortestDistanceFromStartPoint == dictionary.ToList().Min(c => c.Value.ShortestDistanceFromStartPoint)).FirstOrDefault();
        }
    }
}
