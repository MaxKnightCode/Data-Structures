using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PorQue
{
    internal class ConnectedCountables<T> where T : IComparable<T>
    {
        public Node<T> Head { get; private set; }
        Node<T> Tail;
        public int Count;


        public ConnectedCountables()
        {
            Count = 0;
            
        }

        public void AddFirst(T item)
        {

            if (Head == null)
            {
                Head = new Node<T>(Tail, item);
                Tail = Head;
                Head.Next = Tail;
            }

            else
            {
                Node<T> temp = new Node<T>(Head, item);
                Head = temp;
                Tail.Next = Head;
            }

            Count++;
        }


        public void AddLast(T item)
        {
            if (Head == null)
            {
                Head = new Node<T>(Tail, item);
                Tail = Head;
                Head.Next = Tail;
            }

            else
            {
                Node<T> temp = new Node<T>(Head, item);
                Tail.Next = temp;
                Tail = temp;
            }


            Count++;
        }

        public void AddBefore(T Want, T Input)
        {
            int iterate = 0;
            Node<T> CurrentNode = Head;

            if (Head == null)
            {
                Console.WriteLine("nah");
                return;

            }

            while (iterate < Count)
            {

                if(Head.Value.CompareTo(Want) == 0)
                {
                    Node<T> tempNode = new Node<T>(Head, Input);
                    Head = tempNode;
                    Count++;
                    return;
                }

                else if(CurrentNode.Next.Value.CompareTo(Want) == 0)
                {
                    Node<T> tempNode = new Node<T>(CurrentNode.Next, Input);
                    CurrentNode.Next = tempNode;
                    Count++;
                    return;
                }

                CurrentNode = CurrentNode.Next;
                iterate++;
            }

            Console.WriteLine("nah");
        }


        public void AddAfter(T Want, T Input) 
        {
            int iterate = 0;
            Node<T> CurrentNode = Head;

            if(Head == null)
            {
                Console.WriteLine("nah");
                return;
                
            }

            while(iterate < Count) 
            {

                if(CurrentNode.Value.Equals(Want))
                {
                    if (CurrentNode == Tail)
                    {
                        Node<T> temp = new Node<T>(CurrentNode.Next, Input);
                        Tail.Next = temp;
                        Tail = temp;

                    }

                    else
                    {
                        Node<T> temp = new Node<T>(CurrentNode.Next, Input);
                        CurrentNode.Next = temp;
                    }
                    
                    Count++;
                    return;
                }


                CurrentNode = CurrentNode.Next;
                iterate++;
            }

            Console.WriteLine("nah"); 
        }


        public bool RemoveFirst()
        {
            if(Head == null)
            {
                return false;
            }

            else
            {
                Head = Head.Next;
                Tail.Next = Head;
                
                Count--;
                return true;
            }

        }


        public bool RemoveLast()
        {
            if(Head == null )
            {
                return false;
            }
            else
            {
                Node<T> CurrentNode = Head;
                int iterate = 0;

                while (iterate < Count)
                {
                    if(CurrentNode.Next.Equals(Tail)) 
                    {
                        CurrentNode.Next = Head;
                        Tail = CurrentNode;
                        break;
                    }
                    CurrentNode = CurrentNode.Next;
                    iterate++;
                }

                Count--;
                return true;

            }
        }


        public void Remove(T Want)
        {
            int Iterate = 0;
            Node<T> CurrentNode = Head;

            if(Head == null)
            {
                Console.WriteLine("nah");
                return;
            }

            else if(Head.Value.Equals(Want))
            {
                Head = CurrentNode.Next;
                Tail.Next = Head;

                Count--;
                return;
            }



            while(Iterate < Count) 
            {

                if( CurrentNode.Next.Value.Equals(Want))
                {
                    if (CurrentNode.Next.Equals(Tail))
                    {
                        CurrentNode.Next = Head;
                        Tail = CurrentNode;

                    }
                    else
                    {
                        CurrentNode.Next = CurrentNode.Next.Next;
                    }

                    Count--;
                    return;
                }



                CurrentNode = CurrentNode.Next;
                Iterate++;
            }


            Console.WriteLine("nah");
        }



        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }


        public Node<T> Search(T Want)
        {
            int iterate = 0;
            Node<T> CurrentNode = Head;


            while (iterate <  Count) 
            {
                if(CurrentNode.Value.Equals(Want))
                {
                    return CurrentNode;
                }

                CurrentNode = CurrentNode.Next;
                iterate++;
            }

            return null;
        }

        public bool Contains(T Want)
        {
            if(Search(Want) != null)
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
            int Iterate = 0;
            Node<T> CurrentNode = Head;

            while(Iterate < Count)
            {
                if (Iterate == Count-1)
                {
                    Console.Write(($"{CurrentNode.Value}"));
                }
                else
                {
                    Console.Write($"{CurrentNode.Value}, ");
                }

                CurrentNode = CurrentNode.Next;
                Iterate++;
            }

            Console.WriteLine();
        }


    }
}
