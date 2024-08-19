using DollazOnMyMind072523;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");






        
        string[] TestArray = { "dollaz", "on", "my" , "head"};
        AStack<string> Stackie = new AStack<string>(10);

        for(int i = 0; i < TestArray.Length; i++) 
        {
            Stackie.Push(TestArray[i]);
        
        }

        Stackie.Print();

        AStack<string> Test = new AStack<string>(10);

        int x = Stackie.Count;

        for (int i = 0; i < x;i++)
        {
            Test.Push(Stackie.Pop());
        }


        Test.Print();
        Stackie.Print();








        /* LL Testing
        ConnectedCountables<int> LL = new ConnectedCountables<int>();

        for (int i = 0; i < TestArray.Length; i++)
        {
            LL.AddFirst(TestArray[i]);
        }

        LL.AddBefore(10, 100);

        LL.AddAfter(1, 200);

        LL.RemoveFirst();
        LL.RemoveLast();
        LL.Remove(10);


        Console.WriteLine($"{LL.Search(9).Value}");
        
        if(LL.Contains(5))
        {
            Console.WriteLine("yaaaaay");

        }
        else
        {
            Console.WriteLine("Noooooo");
        }

        LL.Print();
        */


    }
}
