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


        public static string? GetAttributeValue(string targetAttr, string keyAttr, string valueAttr)
        {
            if (!File.Exists(fileName))
                return null;

            XDocument doc = XDocument.Load(fileName);
            var root = doc.Root;

            var tmp = root?.Elements("Record").Where(el => el.Attribute(keyAttr)?.Value == valueAttr).ToArray();
            if (tmp?.Length == 0)
                return null;

            return tmp?[0].Attribute(targetAttr)?.Value;
        }



        /// <summary>
        /// Получение общего кол-ва записей в файле
        /// </summary>
        /// <returns></returns>
        public static int GetRecordsCount()
        {
            if (!File.Exists(fileName))
                return 0;

            XDocument doc = XDocument.Load(fileName);

            return doc.Root.Elements("Record").Count();
        }



        /// <summary>
        /// Получение записи по ее индексу
        /// </summary>
        /// <param name="index">Индекс записи</param>
        /// <returns></returns>
        public static XElement? GetRecord(int index)
        {
            if (!File.Exists(fileName))
                return null;

            XDocument doc = XDocument.Load(fileName);

            int i = 0;
            foreach (var item in doc.Root.Elements("Record"))
            {
                if (i == index)
                {
                    return item;
                }
                i++;
            }

            return null;
        }
    }
}
