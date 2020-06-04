using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedWeightedGraph g = new DirectedWeightedGraph();

            g.InsertVertex(10);
            g.InsertVertex(11);
            g.InsertVertex(12);
            g.InsertVertex(13);
            g.InsertVertex(14);
            g.InsertVertex(15);
            g.InsertVertex(16);
            g.InsertVertex(17);
            g.InsertVertex(18);


            g.InsertEdge(10, 13, 2);
            g.InsertEdge(10, 11, 5);
            g.InsertEdge(10, 14, 8);
            g.InsertEdge(11, 14, 2);
            g.InsertEdge(12, 11, 3);
            g.InsertEdge(12, 15, 4);
            g.InsertEdge(13, 14, 7);
            g.InsertEdge(13, 16, 8);
            g.InsertEdge(14, 15, 9);
            g.InsertEdge(14, 17, 4);
            g.InsertEdge(15, 11, 6);
            g.InsertEdge(16, 17, 9);
            g.InsertEdge(17, 13, 5);
            g.InsertEdge(17, 15, 3);
            g.InsertEdge(17, 18, 5);
            g.InsertEdge(18, 15, 3);


            g.print();

            g.FindPaths(10);

            Console.ReadLine();
        }
    }
}
