using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollazOnMyMind072523
{
    internal class Node<T>
{

    public Node<T> Next;
    public T Value;

    public Node(Node<T> next, T value)
    {
        Next = next;
        Value = value;
    }
}
}
