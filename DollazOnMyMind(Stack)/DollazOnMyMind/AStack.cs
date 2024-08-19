using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollazOnMyMind072523
{
    internal class AStack<T> where T: IComparable<T>
    {
        public int Count { get; private set; }
        private T[] Data;

        public int top { get; private set; }

        private int Capacity;

        public AStack(int capacity)
        {
            Capacity = capacity;
            top = 0;
            Count = 0;
            Data = new T[Capacity];
        }

        public void Push(T item)
        {
            if (top == Data.Length)
            {
                T[] temp = new T[Data.Length * 2];
                for (int i = 0; i < Data.Length; i++)
                {
                    temp[i] = Data[i];
                }

                Data = temp;
            }

            else
            {
                Data[top] = item;
                Count++;
                top++;
            }

        }

        public T Pop()
        {
            if (Count == 0)
            {
                return default;
                //this will return the nothing value depending on the T
            }

            else
            {
                T tempReturn = Data[top-1];
                top--;
                Count--;
                return tempReturn;
            }
        }

        public T Peek()
        {
            if (Count==0)
            {
                return default;
            }
            else
            {
                return Data[top-1];
            }
        }



        public void Clear()
        {
            top = 0;
            Data = new T[Capacity];
        }

        public bool IsEmpty()
        {
            if (Count ==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void Print()
        {
            if (!this.IsEmpty())
            {
                for (int i = top - 1; i > 0; i--)
                {
                    Console.Write($"{Data[i]}, ");


                }

                Console.Write($"{Data[0]}");

                Console.WriteLine();
            }
        }

    }
}
