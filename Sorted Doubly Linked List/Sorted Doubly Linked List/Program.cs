namespace SortedDoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            SDLL<int> test = new SDLL<int>();

            test.Insert(20);
            test.Insert(5);
            test.Insert(4);
            test.Insert(3);
            test.Insert(2);
            test.Insert(1);
            test.Insert(10);
            test.Insert(100);
            test.Insert(0);


            test.Remove(4);
            test.Remove(0);
            test.Remove(100);


            test.Print();
            ;
        }
    }
}