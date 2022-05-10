using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDictionary.XML;

namespace SmartDictionary
{
    public struct Word
    {
        public string word { get; set; }
        public string translation { get; set; }
    }

    public class DictionaryModel
    {

        /// <summary>
        /// Добавляет в словарь новое слово и его перевод
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="translate">Перевод</param>
        /// <returns></returns>
        public bool AddNewWord(string word, string translate)
        {
            var toCheck = XmlWorker.GetWord(translate);
            if (toCheck != null)
                return false;

            XmlWorker.AddRecord(word, translate);

            return true;
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
