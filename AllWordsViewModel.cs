using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDictionary
{
    public class AllWordsViewModel
    {
        public ObservableCollection<Word> Words;

        public AllWordsViewModel()
        {
            Words = new ObservableCollection<Word>();
            for (int i = 0; i < XML.XmlWorker.GetRecordsCount(); i++)
            {
                var word = XML.XmlWorker.GetRecord(i);
                if (word != null)
                    Words.Add(word.Value);
            }
        }
    }
}
