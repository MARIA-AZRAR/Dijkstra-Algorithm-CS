using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class vertex
    {
        public int name;  //name of vertex 
        public int status;   //status temp = 1 permanent = 2
        public int predecessor;  //parent
        public int pathLength;  //shortest length

        public vertex(int name)
        {
            this.name = name;   //Constructor
        }

        public void print()
        {
            Console.WriteLine(this.name);
            Console.WriteLine(this.status);
            Console.WriteLine(this.predecessor);
            Console.WriteLine(this.pathLength);
        }
    }

}
