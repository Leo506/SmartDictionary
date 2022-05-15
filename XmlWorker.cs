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

        static XmlWorker()
        {
            if (!File.Exists(fileName))
            { 
                var doc = new XDocument();
                doc.Add(new XElement("Dict"));
                doc.Save(fileName);
            }
        }


        /// <summary>
        /// Добавляет новую запись в XML файл
        /// </summary>
        /// <param name="record">Запись</param>
        public static void AddRecord(IXmlRecord record)
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
                root.Add(record.GetElement());

            doc.Save(fileName);
        }

        /// <summary>
        /// Получение перевода конкретного слова
        /// </summary>
        /// <param name="word">Слово</param>
        /// <returns></returns>
        public static string? GetTranslation(string word)
        {
            if (!File.Exists(fileName))
                return null;

            XDocument doc = XDocument.Load(fileName);

            var root = doc.Root;

            foreach (var record in root.Elements("Record"))
            {
                if (record.Attribute("word") != null)
                    if (record.Attribute("word").Value == word)
                        return record.Attribute("translation").Value;
            }

            return null;
        }


        /// <summary>
        /// Получение слова по его переводу
        /// </summary>
        /// <param name="translation">Перевод слова</param>
        /// <returns></returns>
        public static string? GetWord(string translation)
        {
            if (!File.Exists(fileName))
                return null;

            XDocument doc = XDocument.Load(fileName);

            var root = doc.Root;

            foreach (var record in root.Elements("Record"))
            {
                if (record.Attribute("translation") != null)
                    if (record.Attribute("translation").Value == translation)
                        return record.Attribute("word").Value;
            }

            return null;
        }



        /// <summary>
        /// Получение общего кол-ва записей в файле
        /// </summary>
        /// <returns></returns>
        public static int GetRecordsCount()
        {
            if (!File.Exists(fileName))
                return -1;

            XDocument doc = XDocument.Load(fileName);

            return doc.Root.Elements("Record").Count();
        }



        /// <summary>
        /// Получение записи по ее индексу
        /// </summary>
        /// <param name="index">Индекс записи</param>
        /// <returns></returns>
        public static Word? GetRecord(int index)
        {
            if (!File.Exists(fileName))
                return null;

            XDocument doc = XDocument.Load(fileName);

            int i = 0;
            foreach (var item in doc.Root.Elements("Record"))
            {
                if (i == index)
                {
                    var word = item.Attribute("word").Value;
                    var translation = item.Attribute("translation").Value;

                    return new Word { translation = translation, word = word };
                }
                i++;
            }

            return null;
        }
    }
}
