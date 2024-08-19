using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    internal class Node<T> 
        where T : IComparable<T>
    {
        public T Value;
        public Node<T>[] Nexts;
        public int Height => Nexts.Length - 1;


        public Node(T value, int height)
        {
            Value = value;
            Nexts = new Node<T>[height + 1];
        }



    }
}
