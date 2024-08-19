using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HeapTree
{
    internal class Heap<T> where T : IComparable<T>
    {

        T[] HeapTree = new T[10];
        int pointer = 0;

        public Heap()
        {
        }

        public void insert(T item)
        {
            
            if(pointer == HeapTree.Length - 1)
            {
                T[] temp = new T[HeapTree.Length + 1];
                for (int i = 0; i < HeapTree.Length - 1; i++)
                {
                    
                    temp[i] = HeapTree[i];
                    
                }
                HeapTree = temp;
            }

            HeapTree[pointer] = item;

            heapifyUp(pointer);

            pointer++;
        }



        public void heapifyUp(int index)
        {
            int parentIndx = (index - 1) / 2;///

            if (HeapTree[index].CompareTo(HeapTree[parentIndx]) < 0)
            {
                T temp = HeapTree[index];

                HeapTree[index] = HeapTree[parentIndx];
                HeapTree[parentIndx] = temp;
                heapifyUp(parentIndx);
            }

            else
            {
                return;
            }
        }

        
        public T pop()
        {
            T temp = HeapTree[0];

            HeapTree[0] = HeapTree[pointer-1];
            pointer--;

            HeapifyDown(0);

            return temp;
        }
        

        public void HeapifyDown(int HPIndex)
        {
            //you have to compare the left and right children, and then choose the one that is smaller, follow that path.

            T temp = HeapTree[HPIndex];

            if (HPIndex * 2 + 1 < pointer)
            {
                if (HeapTree[HPIndex].CompareTo(HeapTree[HPIndex * 2 + 1]) > 0 || HeapTree[HPIndex].CompareTo(HeapTree[HPIndex * 2 + 2]) > 0)
                {

                    //compare left and right
                    if (HeapTree[HPIndex * 2 + 1].CompareTo(HeapTree[HPIndex * 2 + 2]) < 0)
                    {
                        HeapTree[HPIndex] = HeapTree[HPIndex * 2 + 1];
                        HeapTree[HPIndex * 2 + 1] = temp;
                        HPIndex = HPIndex * 2 + 1;
                    }
                    else
                    {
                        HeapTree[HPIndex] = HeapTree[HPIndex * 2 + 2];
                        HeapTree[HPIndex * 2 + 2] = temp;
                        HPIndex = HPIndex * 2 + 2;
                    }
                }

                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            HeapifyDown(HPIndex);
        }



        public void PrintHeap()
        {
            for (int i = 0; i < pointer; i++)
            {
                Console.Write($"{HeapTree[i]}, ");
            }

            Console.WriteLine();
        }

        //left side: multiply 2 add 1
        //Right side: multiply by 2 add 2

        //Parent: (x-1)/2
    }
}
