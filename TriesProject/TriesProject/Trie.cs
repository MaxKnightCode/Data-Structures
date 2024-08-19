using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TriesProject
{
    internal class Trie
    {
        TrieNode Root = new TrieNode('*');

        public Trie()
        {

        }

        public void Clear()
        {

        }

        public void Insert(string Word, int Index = 0, TrieNode Current = null)
        {

            if (Index == 0) // Default set of pointer 
            {
                Current = Root;
            }

            if (Current.Children.ContainsKey(Word[Index]) != true) // Check if it needs to make new branch
            {
                Current.Children.Add(Word[Index], new TrieNode(Word[Index]));
            }

            if (Index >= Word.Length - 1) // check if word is done
            {
                Current.Children[Word[Index]].IsWord = true;
                return;
            }

            Insert(Word, Index + 1, Current.Children[Word[Index]]);

        }


        public TrieNode Search(string Word, int Index = 0, TrieNode Current = null)
        {

            if (Index == 0)
            {
                Current = Root;
            }

            if (Current.Children.ContainsKey(Word[Index]))
            {
                if (Index >= Word.Length - 1)
                {
                    return Current.Children[Word[Index]];
                }
                else if (Index < Word.Length - 1)
                {
                    return Search(Word, Index + 1, Current.Children[Word[Index]]);
                }
            }

            return null;
        }

        public void Remove(string Word)
        {
            if (Search(Word) != null)
            {
                Search(Word).IsWord = false;
            }

        }

        public List<string> GetAllPrefix(string Word)
        {
            TrieNode Current = Search(Word);

            List<string> ReturnList = new List<string>();


            if (Current.Children != null)
            {
                List<char> Keys = new List<char>(Current.Children.Keys);
                GetAllHelper(Current, ReturnList, Word);
            }


            return ReturnList;
        }

        private void GetAllHelper(TrieNode Current, List<string> ReturnList, string returnWord)
        {
            if (Current.Children != null)
            {
                List<char> Keys = new List<char>(Current.Children.Keys);

                if (Current.IsWord)
                {
                    ReturnList.Add(returnWord);
                }

                for (int i = 0; i < Keys.Count; i++)
                {
                    GetAllHelper(Current.Children[Keys[i]], ReturnList, returnWord + Keys[i]);
                }
            }


        }

    }
}
