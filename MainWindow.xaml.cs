using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
        }


        private void OpenAddWordWindow(object sender, RoutedEventArgs e)
        {
            // Показываем окно
            var addWord = new AddWord();
            addWord.ShowDialog();
        }


        private void OpenTrainingWindow(object sender, RoutedEventArgs e)
        {
            var trainging = new TrainingWindow();
            trainging.ShowDialog();
        }


        private void OpenSelectFile(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.OpenFileDialog())
            {
                var dialogResult = dialog.ShowDialog();

                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    viewModel.AddFromCSV(dialog.FileName);
                }
            }
        }
    }
}
