using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    enum ChildType
    {
        Root = 0,
        LeftChild = 0,
        RightChild = 1
    }
    internal class Nodes<T> where T: IComparable<T>
    {
        public Nodes<T> Left
        {
            get => Kids[0];
            set => Kids[0] = value;
        }
        public Nodes<T> Right
        {
            get => Kids[1];
            set => Kids[1] = value;
        }

        public Nodes<T>[] Kids { get; } = new Nodes<T>[2];

        public T Value;

        public ChildType ChildType;

        public Nodes(T value, Nodes<T> left, Nodes<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
            ChildType = ChildType.Root;
        }


    }
}
