﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_sAlgorithm
{
    internal class Vertex
    {
        public int ShortestDistanceFromStartPoint { get; set; }
        public string PreviousVertex { get; set; }
        public bool IsProcessed { get; set; }
    }
}
