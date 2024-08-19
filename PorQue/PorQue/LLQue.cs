using PorQue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorQue
{
    internal class LLQue<T> where T : IComparable<T>
    {

        public int Count => Data.Count;
        public ConnectedCountables<T> Data;

        public LLQue()
        {
            Data = new ConnectedCountables<T>();
        }


        public void Enque(T item)
        {
            Data.AddLast(item);
        }

        public T Deque()
        {
            T temo = Data.Head.Value;

            Data.RemoveFirst();
            return temo;
        }

        public T Peegarde()
        {
            return Data.Head.Value;
        }

        public bool IsEmpty()
        {
            if(Count == 0 ) return true;
            return false;
        }

        public void Clear()
        {
            Data.Clear();
        }


        public void Print()
        {
            Data.Print();
        }
    }
}
