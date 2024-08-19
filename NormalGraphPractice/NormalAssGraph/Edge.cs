using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalAssGraph
{
    internal class Edge<T> where T: IEquatable<T>
    {
        public Vertex<T> Start { get; set; }
        public Vertex<T> End { get; set; }

        public float Distance;

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, float distance = 1)
        {
            Start = startingPoint;
            End = endingPoint;
            Distance = distance;
        }


    }
}
