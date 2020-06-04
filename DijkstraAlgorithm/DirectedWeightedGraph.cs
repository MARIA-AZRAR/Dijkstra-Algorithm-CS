using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class DirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 10;

        int n = 0;   //Total no of vertices given by user
        //int e = 0 ;  // help adding values in adj
        int[,] adj;  //a 2D graph to store the relation
        vertex[] vertexList;

        private readonly int TEMPORARY = 1;
        private readonly int PERMANENT = 2;
        private readonly int NIL = -1;
        private readonly int INFINITY = 99999;

        public DirectedWeightedGraph()
        {
            adj = new int[MAX_VERTICES,MAX_VERTICES];
            vertexList = new vertex[MAX_VERTICES];   //a new list is created
        }
        private void Dijkstra(int s)  //s is the index of source vertex
        {
            int v, c;  //c represent current vertex v is used in for loop as destination

            for(v = 0; v < n; v++)
            {
                vertexList[v].status = TEMPORARY;
                vertexList[v].pathLength = INFINITY;  //all vertices value are initially set
                vertexList[v].predecessor = NIL;
            }

            vertexList[s].pathLength = 0;

            while (true)
            {
                c = TempVertexMinPL();  //function will return the temp vertex with minimum path length

                if (c == NIL) //if only a vertex is left with infinity pathlength or no vertex left then return
                    return;

                vertexList[c].status = PERMANENT;   //make the current vertex with shortest pathlegth status permanent

                for(v = 0; v < n; v++)  //now loop is going to check the all adjecent vertices and calculate their pathlength 
                {
                    if(isAdjacent(c,v) && vertexList[v].status == TEMPORARY) //is vertex is adjecent and also temporay
                    {
                        if(vertexList[c].pathLength + adj[c, v] < vertexList[v].pathLength) //and if vertex pathlength is grater then the calculations then we will chenge it so it's new pathlength is will less
                        {
                            vertexList[v].predecessor = c;  //setting current vertex as parent of child(adjacent) vertices
                            vertexList[v].pathLength = vertexList[c].pathLength + adj[c, v];
                        }
                    }
                }
            }

        }

        private int TempVertexMinPL()
        {
            int min = INFINITY;   //first of all minimum is set to ifinity
            int shortestIndex = NIL;  //to store the index of minimum
            for(int v = 0; v < n; v++)
            {
                if(vertexList[v].status==TEMPORARY && vertexList[v].pathLength<min)
                {
                    min = vertexList[v].pathLength;
                    shortestIndex = v;  //giving x the index of shortest path vertex 
                }
            }
            return shortestIndex;
        }

        public void FindPaths(int source) //here source is the name which could be string as well as int
        {
            int s = GetIndex(source);

            Dijkstra(s);
            Console.WriteLine("Source Vertex : " + source + "\n");

            for(int v = 0; v < n; v++)
            {
                Console.WriteLine("Destination Vertex : " + vertexList[v].name);
                if (vertexList[v].pathLength == INFINITY)
                    Console.WriteLine("There is no path from " + source + "to vertex " + v + "\n");
                else
                    FindPath(s, v);
            }
        }

        private void FindPath(int s,int v)  //Everything is setUp by Dijkstra it just gives output
        {
            int u;  //u is used to store predecssor
            int[] path = new int[n]; //array to store the path
            int sd = 0; //shortestDistance
            int count = 0; //no of steps

            while(v!= s)
            {
                count++;
                path[count] = v;
                u = vertexList[v].predecessor;
                sd += adj[u, v];
                v = u; //going backwards from destination to source
            }

            count++;
            path[count] = s; //adding the last one (source)

            Console.Write("Shortest Path is : ");
            for (int i = count; i >= 1; i--)
                Console.Write(vertexList[path[i]].name + " "); //give us the name of the path
            Console.WriteLine("\n Shortest Distance is : " + sd + "\n");
        } 

        private Boolean isAdjacent(int c, int v) //checks if vertices are connected or not
        {
            if (adj[c, v] == 0)
                return false;
            else
                return true;
        }

        private int GetIndex(int source)  //convert Name into index from vertexList
        {
            for(int v = 0; v < n; v++)
            {
                if(vertexList[v].name==source) //if index is found then it is set otherwise it is set to -1
                {
                    return v;   //WHILE IMPLEMETING THIS CODE IN APP TAKE CARE IN CASE AN INVALID NAME OF SOURCE IS GIVEN TO YOU
                }
            }
            throw new System.InvalidOperationException("Invalid Syntax");
        }

        public void InsertVertex(int name)
        {
            vertexList[n] = new vertex(name);
            n++;
        }

        public void InsertEdge(int v1, int v2 , int weight)
        {
            adj[GetIndex(v1), GetIndex(v2)] = weight;
        }

        public void print()
        {
            for(int i = 0; i < n; ++i)
            {
                for(int j = 0; j < n; ++j)
                {
                    Console.Write(adj[i, j] + "  ");
                }
                Console.WriteLine();
            }

            for(int i = 0; i < n; ++i)
            {
                vertexList[i].print();
                Console.WriteLine();
            }
        }

    }
}
