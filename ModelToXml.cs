using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDictionary.XML;

namespace SmartDictionary
{
    public static class ModelToXml
    {
        public static void AddWord(Word word)
        {
            XmlWorker.AddRecord(word);
        }

        public static string? GetTranslation(string word)
        {
            return XmlWorker.GetAttributeValue("translation", "word", word);
        }


        public static string? GetWord(string translation)
        {
            return XmlWorker.GetAttributeValue("word", "translation", translation);
        }

        public static Word? GetWord(int index)
        {
            var element = XmlWorker.GetRecord(index);
            Word word = new Word() { word = element.Attribute("word").Value, translation = element.Attribute("translation").Value, notes = element.Attribute("notes").Value };
            return word;
        }

        public static int GetWordsCount()
        {
            return XmlWorker.GetRecordsCount();
        }
    }
}
