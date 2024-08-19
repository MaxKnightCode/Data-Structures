using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalAssGraph
{
    internal class Graph<T> where T : IEquatable<T>
    {
        public List<Vertex<T>> Vertices;

        public int VertexCount => Vertices.Count;

        public Vertex<T> Goal;


        public Graph(Vertex<T> goal)
        {
            Vertices = new List<Vertex<T>>();
            Goal = goal;
        }

        public Vertex<T> Search(T Value)
        {

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].Value.Equals(Value))
                {
                    return Vertices[i];
                }
            }

            return null;

        }



        public bool AddVertex(Vertex<T> vertexToAdd)
        {
            Vertex<T> V = Search(vertexToAdd.Value);

            if (vertexToAdd != null && vertexToAdd.NeighborCount == 0 && V == null)
            {
                Vertices.Add(vertexToAdd);
                return true;
            }
            return false;
        }



        public bool AddEdge(Vertex<T> a, Vertex<T> b, float Distance = 1)
        {


            //Check if both of the vertices are null, check if they both exist in the list, and check that the same edge does not already exist.
            //If none of these are true, create the edge where a is the starting point and b is the ending point.

            Edge<T> temp = new Edge<T>(a, b, Distance);

            if (Vertices.Contains(a) && Vertices.Contains(b) && a.Neighbors.Contains(temp) == false)
            {
                a.Neighbors.Add(temp);
                return true;
            }

            return false;
        }

        //frontier/fringe: the possible nodes/vertexes you can visit next / Collection of vertices that we have not yet explored but can reach from the previous states from before
        //delegate: a function in the form of a passable data type, ie, function is basically a data type and a delegate is that function stored
        //Syntax: public delegate
        //BETTER SYNTAX: Func<int input,int output> myFunction = blahblahblah
        //when you use delegate, it defines all the syntax afterwards


        //ignore these two below
        public bool RemoveVertex(Vertex<T> v)
        {
            Vertex<T> V = Search(v.Value);

            if (V != null)
            {
                V.Neighbors.Clear();
                Vertices.Remove(v);
                return true;
            }
            return false;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            for (int i = 0; i < a.NeighborCount; i++)//check if a connects to be at all
            {
                if (a.Neighbors[i].Start.Value.Equals(a.Value) && a.Neighbors[i].End.Value.Equals(b.Value))
                {
                    a.Neighbors.RemoveAt(i);
                    return true;
                }
            }


            return false;
        }


        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {

            for (int i = 0; i < a.NeighborCount; i++)//check if a connects to be at all
            {
                if (a.Neighbors[i].Start.Value.Equals(a.Value) && a.Neighbors[i].End.Value.Equals(b.Value))
                {
                    return a.Neighbors[i];
                }
            }


            return null;

        }

        /*not necessary
        public float GetVertexCost(VertexWrapper<T> Pointer)
        {
            float result = 0;

            do
            {
                result += GetEdge(Pointer.Previous, Pointer).Distance;
                Pointer = Pointer.Previous;
            } while (Pointer.Previous != null);

            return result;
        }
        */


        //just the next vertex

        //all the weights are negative 1
        /*
        public VertexWrapper<T> DepthFirstSearch(PriorityQueue<VertexWrapper<T>, float> Fronteir)
        {
            //remove last items from frontier list
            VertexWrapper<T> temp = Fronteir[^1];

            

            Fronteir.RemoveAt(Fronteir.Count - 1);
            return temp;
        }

        //consider all weights as 1
        public VertexWrapper<T> BreadthFirstSearch(PriorityQueue<VertexWrapper<T>, float> Fronteir)
        {
            //remove first items from fronteir list


            VertexWrapper<T> temp = Fronteir[0];
            Fronteir.RemoveAt(0);

            return temp;

        }
        */




        //Uniform Search: make the step, and then choose the lowest prospect next

        public VertexWrapper<T> UniformSearch(PriorityQueue<VertexWrapper<T>, float> Fronteir, List<VertexWrapper<T>> FronteirsToAdd, List<Vertex<T>> Visited)
        {
            for (int i = 0; i < FronteirsToAdd.Count; i++)
            {
                if (Visited.Contains(FronteirsToAdd[i].Vertex) == false)
                {
                    Fronteir.Enqueue(FronteirsToAdd[i], FronteirsToAdd[i].Cost);
                }
            }

            return Fronteir.Dequeue();
        }


        public VertexWrapper<T> JoStar(PriorityQueue<VertexWrapper<T>, float> Fronteir, List<VertexWrapper<T>> FronteirsToAdd, List<Vertex<T>> Visited)
        {
            //look at all the fronteirs, add the heuristics to each one, 

            for (int i = 0; i < FronteirsToAdd.Count; i++)
            {
                if (Visited.Contains(FronteirsToAdd[i].Vertex) == false)
                {
                    Fronteir.Enqueue(FronteirsToAdd[i], FronteirsToAdd[i].Cost + HeurisiticCalc(FronteirsToAdd[i], NoFunction));
                }
            }

            return Fronteir.Dequeue();
        }

        private float NoFunction(Vertex<T> vertex1, Vertex<T> vertex2)
        {
            throw new NotImplementedException();
        }

        public float HeurisiticCalc(VertexWrapper<T> startingPoint, Func<Vertex<T>, Vertex<T>, float> HeuristicType)
        {
            Vertex<T> temp = new Vertex<T>((startingPoint.Vertex.Value));
            return HeuristicType(startingPoint.Vertex, Goal);
        }
        


        /*
        public static float Manhattan(Vertex<T> node, Vertex<T> goal)
        {
            int D = 1;
            int dx = Math.Abs(node.Value.X - goal.Value.X);
            int dy = Math.Abs(node.Value.Y - goal.Value.Y);
            return D * (dx + dy);
        }
        */

        //delegate List<Vertex<T>> SearchType(Vertex<T> StartingPoint);


        public List<Edge<T>> BellmanFordTraversal(Vertex<T> StartingPoint,
            Func<PriorityQueue<VertexWrapper<T>, float>, List<VertexWrapper<T>>, List<Vertex<T>>, VertexWrapper<T>> SearchChoice)
        {
            List<VertexWrapper<T>> WrappedVerticies = new();

            for(int i = 0; i < Vertices.Count; i ++)
            { 
                WrappedVerticies[i] = new VertexWrapper<T>(Vertices[i], null, float.PositiveInfinity);
                WrappedVerticies[i].BllMnFounder = null;
            }

            VertexWrapper<T> Pointer = new VertexWrapper<T>(StartingPoint);
            Pointer.Cost = 0;






        }



        


        public List<Edge<T>> GraphTraversal(Vertex<T> StartingPoint,
            Func<PriorityQueue<VertexWrapper<T>, float>, List<VertexWrapper<T>>, List<Vertex<T>>, VertexWrapper<T>> SearchChoice)
        {
            int IterationCount = 0;


            VertexWrapper<T> Pointer = new VertexWrapper<T>(StartingPoint);

            PriorityQueue<VertexWrapper<T>, float> Fronteir = new();

            List<Edge<T>> Result = new();
            List<Vertex<T>> Visited = new()
            {
                Pointer.Vertex
            };


            while (Pointer.Vertex.Value.Equals(Goal.Value) != true)
            {

                List<VertexWrapper<T>> FronteirsToAdd = Pointer.FronteirWrapReturn(Pointer, GetEdge);



                Pointer = SearchChoice(Fronteir, FronteirsToAdd, Visited);//BFS, DFS, or Uniform

                //Manhattan(StartingPoint, Goal);


                Visited.Add(Pointer.Vertex);

                IterationCount++;
            }

            Stack<Edge<T>> Placeholder = new();

            do
            {
                Placeholder.Push(GetEdge(Pointer.Previous.Vertex, Pointer.Vertex));
                Pointer = Pointer.Previous;
            } while (Pointer.Previous != null);

            int f = Placeholder.Count;

            for (int i = 0; i < f; i++)
            {
                Result.Add(Placeholder.Pop());
            }

            return Result;


        }


    }
}
