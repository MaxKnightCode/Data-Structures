using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedDoublyLinkedList 
{
    internal class Nodes <T> where T: IComparable<T> 
    {
        public T Value;
        public Nodes<T> Next;
        public Nodes<T> Previous;


        public Nodes(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

    }
}
