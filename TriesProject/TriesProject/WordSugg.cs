using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TriesProject
{
    internal class WordSugg
    {
        Trie trie = new Trie();

        public WordSugg()
        {
            string aa = File.ReadAllText("../../../fulldictionary.json");
            var d = JsonSerializer.Deserialize<Dictionary<string, string>>(aa);

            List<string> dictionary = new List<string>(d.Keys);

            for (int i = 0; i < d.Count; i++)
            {
                trie.Insert(dictionary[i]);
            }

            ;
        }


        public void ReturnSugg(string Word)
        {

            List<string> allSugg = trie.GetAllPrefix(Word);

            for(int i = 0; i < allSugg.Count; i++)
            {
                Console.Write($"{allSugg[i]}, ");
            }

        }


    }
}
