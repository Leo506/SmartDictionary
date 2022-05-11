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
    /// Логика взаимодействия для TrainingWindow.xaml
    /// </summary>
    public partial class TrainingWindow : Window
    {
        TrainingViewModel viewModel;
        public TrainingWindow()
        {
            InitializeComponent();
            viewModel = new TrainingViewModel();
            this.DataContext = viewModel;
        }

        private void CheckInput(object sender, RoutedEventArgs e)
        {
            string text = "";
            if (viewModel.CheckInput(Input.Text))
                text = "Это правильный ответ!!!";
            else
                text = "Увы, вы ошиблись";

            MessageBox.Show(text);
        }
    }
}
