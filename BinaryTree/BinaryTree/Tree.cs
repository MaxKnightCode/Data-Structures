using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Tree<T> where T : IComparable<T>
    {
        Nodes<T> Root
        {
            get => rootArr[0];
            set => rootArr[0] = value;
        }
        Nodes<T>[] rootArr = new Nodes<T>[1];
        public int Count;

        public Tree()
        {
            Root = null;
            Count = 0;
        }

        public void Insert(T Input)
        {
            Nodes<T> ToInsert = new Nodes<T>(Input, null, null);
            Nodes<T> Pointer = Root;

            Count++;
            if (Pointer == null)
            {
                Root = ToInsert;
                return;
            }


            while (true)
            {
                int childIndex = (Input.CompareTo(Pointer.Value) + 2) / 2;

                if (Pointer.Kids[childIndex] == null)
                {
                    Pointer.Kids[childIndex] = ToInsert;
                    return;
                }
                Pointer = Pointer.Kids[childIndex];
            }


        }


        public Nodes<T> Search(T Search)
        {
            Nodes<T> Pointer = Root;

            while (Pointer != null)
            {
                if (Pointer.Value.Equals(Search)) return Pointer;

                int childIndex = (Search.CompareTo(Pointer.Value) + 2) / 2;
                Pointer = Pointer.Kids[childIndex];
            }
            return null;

        }

        public Nodes<T> Min()
        {
            bool searching = true;

            Nodes<T> Pointer = Root;

            while (searching)
            {
                if (Pointer.Left == null)
                {
                    return Pointer;
                }

                Pointer = Pointer.Left;


            }
            return null;

        }

        public Nodes<T> Max(Nodes<T> Input)
        {
            bool searching = true;

            Nodes<T> Pointer = Input;

            while (searching)
            {
                if (Pointer.Right == null)
                {
                    return Pointer;
                }

                Pointer = Pointer.Right;
            }
            return null;

        }



        public void Delete(T Input)
        {
            Nodes<T> Pointer = Root;

            //I have this check because...

            var myArray = rootArr;
            ChildType myType = ChildType.Root;


            while (Pointer != null)
            {
                

                if (Pointer.Value.Equals(Input))
                {
                    Count--;


                    if (Pointer.Left != null)
                    {
                        if (Pointer.Right != null)
                        {
                            Nodes<T> TermPointer = Pointer.Left;
                            myArray = Pointer.Kids;

                            int direction = 0;

                            while (TermPointer.Right != null)
                            {
                                myArray = TermPointer.Kids;
                                TermPointer = TermPointer.Right;
                                direction = 1;
                            }
                            myArray[direction] = TermPointer.Left;
                            Pointer.Value = TermPointer.Value;
                            //TermPointer edit
                        }
                        else
                        {
                            myArray[(int)myType] = Pointer.Kids[0];
                        }
                        return;
                    }
                    myArray[(int)myType] = Pointer.Kids[1];

                    return;

                }


                int childIndex = (Input.CompareTo(Pointer.Value) + 2) / 2;

                myArray = Pointer.Kids;

                myType = (ChildType)childIndex;

                Pointer = Pointer.Kids[childIndex];
            }

            throw new ArgumentException("die scumbag");


        }



        public Queue<Nodes<T>> PreOrder()
        {
            Queue<Nodes<T>> Output = new Queue<Nodes<T>>();
            Stack<Nodes<T>> ProcessingQ = new Stack<Nodes<T>>();

            ProcessingQ.Push(Root);

            for (int i = 0; i < Count; i++)
            {
                Nodes<T> PointerNode = ProcessingQ.Pop();

                if (PointerNode == null) continue;

                Output.Enqueue(PointerNode);

                ProcessingQ.Push(PointerNode.Right);
                ProcessingQ.Push(PointerNode.Left);
            }

            return Output;
        }

        int RandomizeSign(int a)
        {
            return a * Random.Shared.Next(2) * 2 - 1;
        }



        public Queue<Nodes<T>> InOrder()
        {
            Queue<Nodes<T>> Output = new Queue<Nodes<T>>();
            Stack<Nodes<T>> ProcessingQ = new Stack<Nodes<T>>();
            Nodes<T> CurrNode = Root;

            //Keep going left until you can't, and when you get leftmost, 
            //every time you move left, you push the node
            //if there's no more nodes, you begin popping
            //if you can't pop left or right, pop
            //
            //after pop, exclusively go right

            //state machine

            while (Output.Count != Count)
            {
                if (CurrNode == null)
                {
                    CurrNode = ProcessingQ.Pop();
                }

                else if (CurrNode.Left != null)
                {
                    ProcessingQ.Push(CurrNode);
                    CurrNode = CurrNode.Left;

                    continue;
                }

                Output.Enqueue(CurrNode);
                CurrNode = CurrNode.Right;
            }

            return Output;


            /*
            while(Output.Count.CompareTo(Count) < 0)
            {

                while(CurrNode.Left != null)
                {
                    CurrNode = CurrNode.Left;
                    ProcessingQ.Push(CurrNode);
                }

                Nodes<T> temp = ProcessingQ.Pop();
                Output.Enqueue(temp);

                if (temp.Right != null)
                {
                    CurrNode = temp.Right;
                    ProcessingQ.Push(CurrNode);
                }
                else if(Output.Count < Count)
                {
                    while (temp.Right == null)
                    {
                        
                        temp = ProcessingQ.Pop();
                        Output.Enqueue(temp);
                        if (temp.Right != null)
                        {
                            CurrNode = temp.Right;
                            ProcessingQ.Push(CurrNode);
                        }
                    }
                }
            }
            return Output;
            */

        }






        public Queue<Nodes<T>> PostOrder()
        {
            Queue<Nodes<T>> Output = new Queue<Nodes<T>>();
            Stack<Nodes<T>> Temp = new Stack<Nodes<T>>();
            Stack<Nodes<T>> ProcessingQ = new Stack<Nodes<T>>();
            Nodes<T> CurrNode = Root;

            ProcessingQ.Push(Root);

            for (int i = 0; i < Count; i++)
            {
                //pushes 10 in the wrong order
                Nodes<T> PointerNode = ProcessingQ.Pop();
                

                //Processing q: 6, 8, 10, 
                //temp: 7, 9, 12, 13, 14, 
                if (PointerNode.Left != null)
                {
                    ProcessingQ.Push(PointerNode.Left);
                }
                if (PointerNode.Right != null)
                {
                    ProcessingQ.Push(PointerNode.Right);
                }

                Temp.Push(PointerNode);
            }

            int var = Temp.Count;
            for (int i = 0; i < var; i++)
            {
                Output.Enqueue(Temp.Pop());
            }

            return Output;

        }


        public Nodes<T>[] BreadthFirst()
        {
            Nodes<T>[] Output = new Nodes<T>[Count];
            Queue<Nodes<T>> ProcessingQ = new Queue<Nodes<T>>();

            Nodes<T> temp;
            var myArray = rootArr;

            ProcessingQ.Enqueue(Root);

            for (int i = 0; i < Count; i++)
            {
                temp = ProcessingQ.Dequeue();
                myArray = temp.Kids;


                for (int j = 0; j <= 1; j++)
                {
                    if (myArray[j] != null)
                    {
                        ProcessingQ.Enqueue(myArray[j]);
                    }
                }

                Output[i] = temp;
            }


            return Output;
        }



        public void PrintTree()
        {







        }


    }
}
