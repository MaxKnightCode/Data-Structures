using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedDoublyLinkedList
{
    internal class SDLL<T> where T : IComparable<T>
    {
        Nodes<T> Head;
        public int Size;

        public SDLL() 
        {
            Head = new Nodes<T>(default);
            Head.Next = Head;
            Head.Previous = Head;
            Size = 0;
        }

        public void Insert(T InsertValue)
        {
            Nodes<T> Pointer = Head;

            while (Pointer.Next != Head) // while Value inserting > pointer
            {
                if (InsertValue.CompareTo(Pointer.Next.Value) < 0)
                {
                    break; // so Pointer is the Node BEFORE the spot to add
                }

                Pointer = Pointer.Next;

            }

            InsertHelper(InsertValue, Pointer);

            Size++;
        }

        private void InsertHelper(T InsertValue, Nodes<T> Pointer)
        {
            Nodes<T> temp = new Nodes<T>(InsertValue);
            temp.Previous = Pointer;
            temp.Next = Pointer.Next;

            Pointer.Next.Previous = temp;
            Pointer.Next = temp;
        }


        public void Remove(T RemoveValue)
        {
            Nodes<T> Pointer = Head;

            while(Pointer.Next != Head)
            {
                Pointer = Pointer.Next;

                if (Pointer.Value.Equals(RemoveValue))
                {
                    break;
                }
            }

            RemoveHelper(Pointer);

            Size--;
        }

        private void RemoveHelper(Nodes<T> Pointer)
        {
            Nodes<T> prev = Pointer.Previous;
            Nodes<T> next = Pointer.Next;

            prev.Next = next;
            next.Previous = prev;
        }


        public void Print()
        {
            Nodes<T> Pointer = Head.Next;

            for(int i = 0; i < Size; i++)
            {
                Console.Write($"{Pointer.Value}, ");
                Pointer = Pointer.Next;
            }
        }
        

    }
}
