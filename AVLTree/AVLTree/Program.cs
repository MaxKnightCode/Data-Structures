namespace AVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            TreeClass<int> test = new TreeClass<int>();

            test.Insert(37);
            test.Insert(24);
            test.Insert(41);
            test.Insert(7);
            test.Insert(32);
            test.Insert(40);
            test.Insert(42);
            test.Insert(2);
            test.Insert(120);

            test.Insert(5);

            /*
            test.insert(5);
            test.insert(4);
            test.insert(1);
            test.insert(3);
            */

            ;
        }
    }
}