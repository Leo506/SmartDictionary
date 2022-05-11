using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDictionary
{
    public class TrainingViewModel : INotifyPropertyChanged
    {
        DictionaryModel model;

        private Word _hiddenWord;
        public Word HiddenWord
        {
            get { return _hiddenWord; }
            set
            {
                _hiddenWord = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HiddenWord)));
            }
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        
        public TrainingViewModel()
        {
            model = new DictionaryModel();
            ChooseNewWord();
        }

        private void ChooseNewWord()
        {
            HiddenWord = model.GetRandomWord();
        }


        public bool CheckInput(string input)
        {
            if (input.ToLower() == _hiddenWord.word)
            {
                ChooseNewWord();
                return true;
            }

            return false;
        }

        
    }
}
