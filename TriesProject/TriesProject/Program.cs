using System.Text.Json;

namespace TriesProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /*
            string[] Strings = { "cat", "cats", "watermelon", "carton", "cartoon", "catermelon" , "catster", "catability", "cathedral", "catabilities", "water", "waiter", "watermelons"};

            Trie test = new Trie();

            for(int i = 0; i < Strings.Length; i ++)
            {
                test.Insert(Strings[i]);
            }

            List<string> strings = test.GetAllPrefix("ca");
            */


            WordSugg SuggBot = new WordSugg();

            ConsoleKeyInfo KeyReader;

            string CurrentWord = "";

            do
            {
                KeyReader = Console.ReadKey();
                char Typed = KeyReader.Key.ToString()[0];



                

                if (KeyReader.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("\n");
                    CurrentWord = CurrentWord.ToLower();

                    SuggBot.ReturnSugg(CurrentWord);

                    CurrentWord = "";
                }
                if(KeyReader.Key == ConsoleKey.Spacebar)
                {
                    CurrentWord = "";
                }

                CurrentWord += Typed;

            } while (KeyReader.Key != ConsoleKey.Escape);


        }
    }
}