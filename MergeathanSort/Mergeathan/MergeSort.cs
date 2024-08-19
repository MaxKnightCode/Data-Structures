using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Mergeathan
{
    internal class MergeSort<T> where T : IComparable<T>
    {
        public MergeSort()
        {

        }

        public T[] Sort(T[] input)
        {
            if (input.Length < 2)
            {
                return input;
            }

            /*
            //test
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i] + ", ");
            }
            Console.WriteLine();
            */
            

            int midpt = (input.Length) / 2;

            T[] leftArray = new T[midpt];
            T[] rightArray = new T[input.Length - midpt];

            for(int i = 0; i <  midpt; i++) 
            {
                leftArray[i] = input[i];
            }
            int x = 0;
            for(int i = midpt; i < input.Length; i ++)
            {
                rightArray[x] = input[i];
                x++;
            }


            T[] leftResult = Sort(leftArray);

            T[] rightResult = Sort(rightArray);


            return Merge(leftResult, rightResult);



        }

        
        public T[] Merge(T[] left, T[] right)
        {

            T[] output = new T[left.Length + right.Length];

            int leftCount = 0;
            int rightCount = 0;

            int outputCount = 0;

            int RanOut = 0;

            //left compared to the right is greater , 1
            // left compared to right is less, -1

            while (outputCount <= output.Length && RanOut == 0)
            {
                if (left[leftCount].CompareTo(right[rightCount]) < 0)
                {
                    output[outputCount] = left[leftCount];

                    outputCount++;
                    leftCount++;

                    if (leftCount >= left.Length)
                    {
                        RanOut = -1;
                    }
                }

                else if (left[leftCount].CompareTo(right[rightCount]) > 0)
                {
                    output[outputCount] = right[rightCount];

                    outputCount++;
                    rightCount++;

                    if (rightCount >= right.Length)
                    {
                        RanOut = 1;
                    }
                }
            }


            if (RanOut == 1)
            {
                while (outputCount < output.Length)
                {
                    output[outputCount] = left[leftCount];

                    outputCount++;
                    leftCount++;
                }
            }
            else if(RanOut == -1)
            {
                while (outputCount < output.Length)
                {
                    output[outputCount] = right[rightCount];

                    outputCount++;
                    rightCount++;
                }
            }




            return output;


        }



    }
}
