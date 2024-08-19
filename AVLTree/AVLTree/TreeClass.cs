using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    internal class TreeClass<T>
        where T : IComparable<T>
    {

        Node<T> Root;
        int size;

        public TreeClass()
        {
            size = 0;
        }


        public void Insert(T item)
        {
            Root = InsertRec(Root, item);

            //if root == null => node = new
            //else => node is root

            size++;
        }

        Node<T> InsertRec(Node<T> pointer, T input)
        {
            if (pointer == null) return new Node<T>(input);

            if (input.CompareTo(pointer.Value) > 0)//if input is greater than pointer.value
            {

                pointer.RightChild = InsertRec(pointer.RightChild, input);

                //if ptr.right == null => node = new
                //else => node is ptr.right
            }
            else if (input.CompareTo(pointer.Value) < 0)
            {

                pointer.LeftChild = InsertRec(pointer.LeftChild, input);
            }
            else
            {
                Console.WriteLine("nar");
                size--;
            }

            if (pointer.UpdateHeightReturnBalance() > 1 && pointer.RightChild.Balance < 0)
            {
                pointer.RightChild = RotateRight(pointer.RightChild);
            }

            else if (pointer.UpdateHeightReturnBalance() < -1 && pointer.LeftChild.Balance > 0)
            {
                pointer.LeftChild = RotateLeft(pointer.LeftChild);
            }

            if (pointer.UpdateHeightReturnBalance() > 1)
            {
                pointer = RotateLeft(pointer);
            }
            else if (pointer.UpdateHeightReturnBalance() < -1)
            {
                pointer = RotateRight(pointer);
            }



            return pointer;
        }


        public Node<T> RotateLeft(Node<T> pointer)//doesn't work lol
        {
            //temp = pointer.rightchild
            //pointer.rightchild = temp.left
            //temp.leftchild = pointer
            //return tempheady

            Node<T> TempHeady = pointer.RightChild;
            pointer.RightChild = TempHeady.LeftChild;
            TempHeady.LeftChild = pointer;
            TempHeady.LeftChild?.UpdateHeightReturnBalance();//the question mark says "if not null then..."
            TempHeady.UpdateHeightReturnBalance();



            return TempHeady;
        }


        public Node<T> RotateRight(Node<T> pointer)//doesn't work lol
        {
            Node<T> tempHeady = pointer.LeftChild;
            pointer.LeftChild = tempHeady.RightChild;
            tempHeady.RightChild = pointer;
            tempHeady.RightChild?.UpdateHeightReturnBalance();
            tempHeady.UpdateHeightReturnBalance();
            return tempHeady;
        }


        public void Delete(T Value)
        {
            PrivDelete(Value, Root);


            size--;
        }




        Node<T> PrivDelete(T toDelete, Node<T> pointer)
        {
            if (pointer == null)
            {
                throw new InvalidDataException("kys");
            }

            if (pointer.Value.CompareTo(toDelete) < 0)
            {
                pointer.RightChild = PrivDelete(toDelete, pointer.RightChild);
            }
            else if (pointer.Value.CompareTo(toDelete) > 0)
            {
                pointer.LeftChild = PrivDelete(toDelete, pointer.LeftChild);
            }
            else
            {
                //leaf
                if (pointer.RightChild == null && pointer.LeftChild == null)
                {
                    return null;
                }

                // one child
                else if (pointer.RightChild == null)
                {
                    return pointer.LeftChild;
                }

                else if (pointer.LeftChild == null)
                {
                    return pointer.RightChild;
                }

                //two child
                else
                {
                    Node<T> temp = GetMax(pointer.LeftChild);

                    pointer.Value = temp.Value;
                    pointer.LeftChild = PrivDelete(temp.Value, pointer.LeftChild);
                }
                
            }


            if (pointer.UpdateHeightReturnBalance() > 1 && pointer.RightChild.Balance < 0)
            {
                pointer.RightChild = RotateRight(pointer.RightChild);
            }

            else if (pointer.UpdateHeightReturnBalance() < -1 && pointer.LeftChild.Balance > 0)
            {
                pointer.LeftChild = RotateLeft(pointer.LeftChild);
            }

            if (pointer.UpdateHeightReturnBalance() > 1)
            {
                pointer = RotateLeft(pointer);
            }
            else if (pointer.UpdateHeightReturnBalance() < -1)
            {
                pointer = RotateRight(pointer);
            }

            return pointer;

        }

        public Node<T> GetMax(Node<T> pointer)
        {
            while (pointer.RightChild != null)
            {
                pointer = pointer.RightChild;
            }

            return pointer;
        }
    }
}
