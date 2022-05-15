using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartDictionary.XML
{
    public class WordRecord : IXmlRecord
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public string Notes { get; set; }

        public WordRecord(string word, string translation, string notes)
        {
            Word = word;
            Translation = translation;
            Notes = notes;
        }

        public WordRecord() { }

        public XElement GetElement()
        {
            var element = new XElement("Record");
            element.Add(new XAttribute("word", Word.ToLower()), new XAttribute("translation", Translation.ToLower()), new XAttribute("notes", Notes.ToLower()));
            return element;
        }
    }
}
