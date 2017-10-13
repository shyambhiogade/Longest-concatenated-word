using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace concanatedWords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }

        Trie trie;
        List<string> concateWords = new List<string>();
        string originalWord;
        int shortestWordLength = int.MaxValue;
        void FindPrefix(string word)
        {
            for (int i = shortestWordLength-1; i < word.Length; i++)
            {
                string prefix = word.Substring(0, i+1);                
                if (trie.Search(prefix))
                {
                    string suffix = word.Substring(i);
                    if (trie.Search(suffix))
                    {
                        concateWords.Add(originalWord);
                        break;
                    }
                    FindPrefix(suffix);
                }
            }
        }

        private void startSearch_Click(object sender, EventArgs e)
        {
            label1.Text = "Searching.........";
            var items = new List<string>();
            var stream = new StreamReader("NET Test 00.txt");
            
            trie = new Trie();
            trie.InsertRange(items);

            while (!stream.EndOfStream)
            {
                var item = stream.ReadLine().Trim();
                if (item.Length > 0)
                {
                    items.Add(item);
                    trie.Insert(item);
                    if (item.Length < shortestWordLength)
                    {
                        shortestWordLength = item.Length;
                    }
                }
            }

            var lookup = (Lookup<int, string>)items.ToLookup(i => i.Length,i => i);
            var sortedLookup = lookup.OrderByDescending(i => i.Key);            

            foreach (var item in sortedLookup)
            {
                foreach (var val in item)
                {
                    originalWord = val;
                    FindPrefix(val);
                }
            }

            var result = "Longest concanated word is =  "+ concateWords[0] + "\nSecond longest concanated word is = " + concateWords[1] + "\n" + "no of concanated word is = " + concateWords.Count;
            Debug.WriteLine(result);
            label1.Text = result;
        }
    }
}
