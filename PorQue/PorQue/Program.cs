// See https://aka.ms/new-console-template for more information
using PorQue;

Console.WriteLine("Hello, World!");


//int[] tempArray = { 1, 2, 3, 4, 5 };

AQue<int> Que = new AQue<int>(10);

//for(int i = 0; i < tempArray.Length; i++)
//{
//    Que.Enque(tempArray[i]);

//}


//int x = Que.Count;
//for(int i = 0;i < x;i++)
//{
//    Que.Deque();
//}


//for (int i = 0; i < tempArray.Length; i++)
//{
//    Que.Enque(tempArray[i]);

//}
//Que.Enque(5);

//Que.Enque(5);
//Que.Enque(6);
//Que.Deque();

//Console.WriteLine(Que.Peek());

//if(Que.IsEmpty()!= true)
//{
//    Console.WriteLine("not empty");
//}

//Que.Print();

//Que.Clear();

//Que.Print();

//if (Que.IsEmpty())
//{
//    Console.WriteLine("empty");
//}


//for(int i = 0; i < 5; i++)
//{
//    Que.Enque(i);
//}

//for (int i = 0; i < 5; i++)
//{
//    Que.Deque();
//}

for (int i = 0; i < 11; i++)
{
    Que.Enque(i);
}

Que.Enque(11);

;
//LLQue test
/*
LLQue<int> Que = new LLQue<int>();

for(int i  = 0; i < tempArray.Length; i++)
{
    Que.Enque(tempArray[i]);
}

Que.Print();

LLQue<int> import = new LLQue<int>();

int x = Que.Count;

for(int i = 0; i < x; i ++)
{
    import.Enque(Que.Deque());
}

Que.Print();
import.Print();

Console.WriteLine(import.Peegarde());

if(import.IsEmpty()== false)
{
    Console.WriteLine("whoa");
}

import.Clear();

if(import.IsEmpty())
{
    Console.WriteLine("ew");
}
*/

