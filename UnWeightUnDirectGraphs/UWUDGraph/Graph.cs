using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWUDGraph
{
    internal class Graph<T> where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices;

        public int VertexCount => Vertices.Count;

        Vertex<T> Sentinal;


        public Graph()
        {
            Vertices = new List<Vertex<T>>();
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

            if (vertexToAdd != null && vertexToAdd.NeighborCount == 0 && V == null )
            {
                Vertices.Add(vertexToAdd);
                return true;
            }
            return false;
        }



        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            Vertex<T> A = Search(a.Value);
            Vertex<T> B = Search(b.Value);

            if (A != null && B != null)
            {
                A.Neighbors.Add(B);
                //B.Neighbors.Add(A);
                return true;
            }
            return false;
        }



        public bool RemoveVertex(Vertex<T> v)
        {
            Vertex<T> V = Search(v.Value);

            if (V != null)
            {
                V.Neighbors.Clear();
                Vertices.Remove(V);
                return true;
            }
            return false;
        }



        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            Vertex<T> A = Search(a.Value);
            Vertex<T> B = Search(b.Value);

            if (A != null && B != null)//exist
            {
                if (A.Neighbors.Contains(B) && B.Neighbors.Contains(A)) // neighbors!!
                {
                    A.Neighbors.Remove(B);
                    B.Neighbors.Remove(A);
                    return true;
                }
            }
            return false;

        }




    }
}
