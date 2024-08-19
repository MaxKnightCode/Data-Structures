using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriesProject
{
    internal class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public bool IsWord;
        public char Value;

        public TrieNode(char value)
        {
            Children = new Dictionary<char, TrieNode>();
            IsWord = false;
            Value = value;
        }


    }
}
