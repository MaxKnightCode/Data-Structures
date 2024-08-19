using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorQue
{
    internal class AQue<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        public T[] Data;
        private int Head;
        private int Tail;
        public int Capacity;

        public AQue(int capacity)
        {

            Capacity = capacity;
            Data = new T[Capacity];
            Head = 0;
            Tail = 0;
            Count = 0;
        }

        public void Enque(T item)
        {
            Data[Tail] = item;

            if (Head != 0 && Tail == Data.Length - 1)
            {
                Tail = 0;
            }

            else
            {
                Tail++;
            }




            Count++;


            //resize
            if (Tail == Head && Count == Data.Length)
            {
                this.Resize(Data.Length * 2);
            }
            else if (Count == Data.Length)
            {
                this.Resize(Data.Length * 2);
            }
            
        }







        public T Deque()
        {
            int temp = Head;
            Head++;

            if (Tail != 0 && Head == Data.Length)
            {
                Head = 0;
            }

            Count--;
            return Data[temp];
        }




        public T Peek()
        {
            return Data[Head];
        }

        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public void Clear()
        {
            Head = 0;
            Tail = 0;
            Data = new T[Capacity];
            Count = 0;
        }

        private void Resize(int size)
        {
            T[] temp = new T[size];

            int ArrayIndex = Head;

            for (int i = 0; i <= Count; i++)
            {
                

                temp[i] = Data[ArrayIndex];

                if(ArrayIndex == Data.Length-1)
                {
                    ArrayIndex = 0;
                }
                else
                {
                    ArrayIndex++;
                }
            }

            Head = 0;
            Tail = Count;
            Data = temp;
        }



        public void Print()
        {

            if (Count == 0)
            {
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAA");
            }

            else { 
            for (int i = Head; i != Tail;) 
            {

                Console.Write($"{Data[i]}, ");



                if (i == Data.Length - 1)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }


            }
                Console.WriteLine();
            }
        }
    }

}
