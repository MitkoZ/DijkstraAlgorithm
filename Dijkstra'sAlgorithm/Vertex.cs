using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_sAlgorithm
{
    internal class Vertex
    {
        public int ShortestDistanceFromTarget { get; set; }
        public string PreviousVertex { get; set; }
        public bool IsVisited { get; set; }
    }
}
