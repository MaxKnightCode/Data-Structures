namespace HeapTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Heap<int> HTTest = new Heap<int>();

            Random rand = new Random();

            int[] test = new int[100];

            for (int i = 0; i < test.Length; i ++)
            {
                test[i] = rand.Next(-100,100);
            }




            for (int i = 0; i < test.Length; i++)
            {
                HTTest.insert(test[i]);
            }

            

            for (int i = 0; i < test.Length; i++)
            {
                Console.Write($"{HTTest.pop()}, ");
            }


            HTTest.PrintHeap();


        }
    }
}