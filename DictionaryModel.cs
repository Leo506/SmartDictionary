using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDictionary
{
    public struct Word
    {
        public string word { get; set; }
        public string translation { get; set; }
    }

    public class DictionaryModel
    {
        public bool AddNewWord(string word, string translate)
        {
            throw new NotImplementedException();
        }

        public bool RemoveWord(string word)
        {
            throw new NotImplementedException();
        }


        public Word GetRandomWord()
        {
            throw new NotImplementedException();
        }
    }
}
