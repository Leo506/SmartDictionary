﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDictionary.XML;
using System.IO;
using System.Xml.Linq;

namespace SmartDictionary
{
    public struct Word : IXmlRecord
    {
        public string word { get; set; }
        public string translation { get; set; }
        public string notes { get; set; }

        public XElement GetElement()
        {
            var element = new XElement("Record");
            element.Add(new XAttribute("word", word.ToLower()), new XAttribute("translation", translation.ToLower()), new XAttribute("notes", notes.ToLower()));
            return element;
        }
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

            Word record = new Word() { word = word, translation = translate, notes = "" };
            XmlWorker.AddRecord(record);

            return true;
        }


        /// <summary>
        /// Добавляет в словарь новое слово и его перевод
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="translation">Перевод</param>
        /// <param name="notes">Примечания</param>
        /// <returns></returns>
        public bool AddNewWord(string word, string translation, string notes)
        {
            if (!CheckWord(translation))
                return false;

            Word record = new Word() { word = word, translation = translation, notes = notes };
            XmlWorker.AddRecord(record);

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

                var notes = "";
                if (words.Count() == 3)
                    notes = words[2];

                if (CheckWord(translation))
                    XmlWorker.AddRecord(new Word() { word = word, translation = translation, notes = notes});
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
