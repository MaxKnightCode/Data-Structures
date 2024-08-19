using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    internal class Hoare<T> where T : IComparable<T>
    {
        public Hoare()
        {
        }

        public void HoareSoart(T[] input, int start, int end)
        {
            if (end - start < 1)
            {
                return;
            }

            T pivt = input[start];

            int Left = start;
            int Right = end;

            while (Left < Right)
            {
                while (pivt.CompareTo(input[Left]) > 0 && Left < input.Length-1)
                {
                    Left+= 1;
                }

                while (pivt.CompareTo(input[Right]) <= 0 && Right > 0)
                {
                    Right-= 1;
                }

                if (Left < Right)
                {
                    T temp = input[Left];
                    input[Left] = input[Right];
                    input[Right] = temp;
                }            }

            if(Left == Right && Left == start)
            {
                Left++;
            }

            //left
            HoareSoart(input, start, Right);

            if (Left != start)
            {
                //right
                HoareSoart(input, Left, end);
            }
        }
    }
}
