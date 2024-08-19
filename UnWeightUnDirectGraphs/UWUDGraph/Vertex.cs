using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWUDGraph
{
    internal class Vertex<T> where T : IComparable<T>
    {
        public T Value;
        public List<Vertex<T>> Neighbors { get; set; }
        public int NeighborCount => Neighbors.Count;

        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
        }

    }
}
