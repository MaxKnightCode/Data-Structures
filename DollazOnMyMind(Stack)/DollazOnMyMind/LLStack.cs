using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollazOnMyMind072523
{
    internal class LLStack<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        private ConnectedCountables<T> Data;

        public LLStack()
        {
            Data = new ConnectedCountables<T>();
            Count = 0;

        }

        public void Push(T item)
        {
            Data.AddFirst(item);
            Count++;
        }

        public T Pop()
        {
            T wowie = Data.Head.Value;

            Data.RemoveFirst();

            Count--;
            return wowie;
        }


        public T Peek()
        {
            return Data.Head.Value;
        }


        public bool IsEmpty()
        {
            if(Count==0) return false;
            else return true;
        }

        public void Clear()
        {
            Data.Clear();
            Count = 0;
        }


        public void Print()
        {
            Data.Print();
        }

    }
}
