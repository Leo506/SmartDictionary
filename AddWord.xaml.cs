using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartDictionary
{
    /// <summary>
    /// Логика взаимодействия для AddWord.xaml
    /// </summary>
    public partial class AddWord : Window
    {
        AddWordViewModel viewModel;
        public AddWord()
        {
            InitializeComponent();
            viewModel = new AddWordViewModel();
            this.DataContext = viewModel;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            var result = viewModel.AddWord();
            if (!result)
                MessageBox.Show("Уже есть такое слово");
            else
                DialogResult = true;
        }
    }
}
