using CarDirectoryTestApp.CarDirectory.ViewModels;
using CarDirectoryTestApp.CarDirectory.Commands.AddDocumentCommands;
using CarDirectoryTestApp.CarDirectory;
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

namespace CarDirectoryTestApp.CarDirectory.Views
{
    /// <summary>
    /// Логика взаимодействия для AddDocument_GUI.xaml
    /// </summary>
    public partial class AddDocument_GUI : Window
    {
        public AddDocument_GUI()
        {
            InitializeComponent();
            DataContext = new AddDocument_ViewModel();

        }
    }
}
