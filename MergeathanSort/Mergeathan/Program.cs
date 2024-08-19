
using Mergeathan;
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");

        MergeSort<string> test = new MergeSort<string>();



        string[] array = new string[] { "cat" };
        string[] test2 = test.Sort(array);

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{test2[i]}, ");

        }

        

    }
}

