using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree 
{
    internal class Node <T>
        where T : IComparable<T>
    {
        public T Value;
        public Node<T> LeftChild;
        public Node<T> RightChild;

        //int ChildCount;

        public int Height;
        public int Balance;

        
        public Node(T value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
            Height = 1;
        }

        


        public int UpdateHeightReturnBalance()
        {
            //add to height every time
            //compare the height of left and right
            //set it to the greater one
            //(all in context of recursion of insert)

            int leftChildHeight = 0;
            int rightChildHeight = 0;

            if(this.LeftChild != null)
            {
                leftChildHeight = this.LeftChild.Height;
            }
            if(this.RightChild != null)
            {
                rightChildHeight = this.RightChild.Height;
            }

            if(leftChildHeight > rightChildHeight)
            {
                this.Height = leftChildHeight + 1;
            }
            else if(leftChildHeight <= rightChildHeight)
            {
                this.Height = rightChildHeight + 1;
            }

            return Balancing(leftChildHeight, rightChildHeight);
        }


        public int Balancing(int LeftChildHeight, int RightChildHeight)
        {
            return this.Balance = RightChildHeight - LeftChildHeight;
        }


        

    }
}
