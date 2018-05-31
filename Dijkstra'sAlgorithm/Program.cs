using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_sAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = Graph.LoadGraphFromTxtFile("Graph.txt");
            string sourcePoint = "K";
            string targetPoint = "F";
            Stack<string> steps = Dijkstra_sWrapper.Dijkstra(sourcePoint, targetPoint, graph);
            PrintShortestPath(steps);
        }

        private static void PrintShortestPath(Stack<string> traverseStack)
        {
            if (traverseStack.Count == 0)
            {
                Console.WriteLine("There is not path!");
                return;
            }

            Console.WriteLine("Shortest path:");
            foreach (string step in traverseStack)
            {
                Console.WriteLine(step);
            }
        }

    }
}
