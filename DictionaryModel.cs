using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDictionary.XML;
using System.IO;

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
            if (!CheckWord(translate))
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
            var all = XmlWorker.GetRecordsCount();
            var random = new Random();
            var index = random.Next(all);

            var result = XmlWorker.GetRecord(index);

            if (result != null)
                return result.Value;
            
            return new Word { translation = "", word = "" };
        }


        /// <summary>
        /// Записать слова из CSV-файла
        /// </summary>
        /// <param name="pathToFile">Путь к файлу</param>
        public void AddWordsFromCsv(string pathToFile)
        {
            var strings = File.ReadAllLines(pathToFile);
            foreach (var s in strings)
            {
                var words = s.Split(',');
                var word  = words[0];
                var translation = words[1];

                if (CheckWord(translation))
                    XmlWorker.AddRecord(word, translation);
            }
        }

        private bool CheckWord(string translation)
        {
            var toCheck = XmlWorker.GetWord(translation);
            if (toCheck != null)
                return false;
            return true;
        }
    }
}
