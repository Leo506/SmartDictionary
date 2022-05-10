using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;


namespace SmartDictionary.XML
{
    public class XmlWorker
    {
        const string fileName = "Dict.xml";


        /// <summary>
        /// Добавляет новую запись в XML файл
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="translation">Перевод слова</param>
        public static void AddRecord(string word, string translation)
        {
            XDocument doc;

            if (!File.Exists(fileName))
            {
                doc = new XDocument();
                doc.Add(new XElement("Dict"));
            }
            else
                doc = XDocument.Load(fileName);

            var root = doc.Root;


            if (root != null)
            {
                var element = new XElement("Record");
                element.Add(new XAttribute("word", word.ToLower()), new XAttribute("translation", translation.ToLower()));
                root.Add(element);
            }
            doc.Save(fileName);

        }


        /// <summary>
        /// Получение перевода конкретного слова
        /// </summary>
        /// <param name="word">Слово</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public static string GetTranslation(string word)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName);

            XDocument doc = XDocument.Load(fileName);

            var root = doc.Root;

            foreach (var record in root.Elements("Record"))
            {
                if (record.Attribute("word") != null)
                    if (record.Attribute("word").Value == word)
                        return record.Attribute("translation").Value;
            }

            throw new Exception("Word not found");
        }


        /// <summary>
        /// Получение слова по его переводу
        /// </summary>
        /// <param name="translation">Перевод слова</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public static string GetWord(string translation)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();

            XDocument doc = XDocument.Load(fileName);

            var root = doc.Root;

            foreach (var record in root.Elements("Record"))
            {
                if (record.Attribute("translation") != null)
                    if (record.Attribute("translation").Value == translation)
                        return record.Attribute("word").Value;
            }

            throw new Exception("Translation not found");
        }
    }
}
