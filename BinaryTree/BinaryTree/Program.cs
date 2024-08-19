// See https://aka.ms/new-console-template for more information
using BinaryTree;

class Program
{

    public static void Main()
    {

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        Console.WriteLine("Hello, World!");


        Tree<int> tree = new Tree<int>();

        tree.Insert(7);
        tree.Insert(6);
        tree.Insert(9);
        tree.Insert(2);

        
        tree.Insert(8);
        tree.Insert(12);
        tree.Insert(1);
        tree.Insert(4);
        tree.Insert(10);
        tree.Insert(11);
        tree.Insert(3);
        tree.Insert(5);
        tree.Insert(13);
        tree.Insert(14);

        
        Nodes<int>[] test = tree.BreadthFirst();


        for (int i = 0; i < tree.Count; i++)
        {
            Console.Write($"{test[i].Value}, ");
        }



    //
    ;
    }
}