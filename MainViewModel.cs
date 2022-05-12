using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDictionary
{
    public class MainViewModel
    {
        DictionaryModel model;

        public MainViewModel()
        {
            model = new DictionaryModel();
        }

        public void AddFromCSV(string path)
        {
            model.AddWordsFromCsv(path);
        }
    }
}
