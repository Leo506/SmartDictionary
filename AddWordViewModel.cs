using System.ComponentModel;


namespace SmartDictionary
{
    public class AddWordViewModel : INotifyPropertyChanged
    {
        private string _word;
        public string Word
        {
            get { return _word; }
            set
            {
                _word = value;
                OnPropertyChanged(nameof(Word));
            }
        }

        private string _translation;
        public string Translation
        {
            get { return _translation; }
            set 
            { 
                _translation = value; 
                OnPropertyChanged(nameof(Translation)); 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private DictionaryModel model;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public AddWordViewModel()
        {
            _word = _translation = "";
            model = new DictionaryModel();
        }

        public bool AddWord()
        {
            return model.AddNewWord(_word, _translation);
        }
    }
}
