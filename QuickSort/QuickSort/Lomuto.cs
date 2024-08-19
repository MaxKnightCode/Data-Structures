using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort 
{
    internal class Lomuto <T> where T : IComparable<T>
    {
        public Lomuto()
        {
        }

        T temp;

        public void Lomutoo(T[] input, int start, int end)
        {
            if (end - start < 1)
            {
                return;
            }

            int wall = start-1;

            for (int i = start; i <= end; i++)
            {
                if (input[i].CompareTo(input[end]) < 0)
                {
                    temp = input[wall + 1];
                    input[wall + 1] = input[i];
                    input[i] = temp;
                    wall++;
                }
            }

            temp = input[wall+1];
            input[wall+1] = input[end];
            input[end] = temp;
            wall++;

            //left
            Lomutoo(input, start, wall-1);

            //right
            Lomutoo(input, wall + 1, end);
        }
    }
}
