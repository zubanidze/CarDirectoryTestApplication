using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CarDirectoryTestApp.CarDirectory.Views;
using CarDirectoryTestApp.CarDirectory.Models;
using CarDirectoryTestApp.CarDirectory.ViewModels;
using CarDirectoryTestApp.CarDirectory;
using CarDirectoryTestApp.CarDirectory.Commands.AddDocumentCommands;

namespace CarDirectoryTestApp.CarDirectory.ViewModels
{
    internal class AddDocument_ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string filePath;
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                OnPropertyChanged();
            }
        }
        public ICommand ContinueCommand { get; set; }
        public ICommand OpenFileDialogCommand { get; set; }

        public AddDocument_ViewModel()
        {
            ContinueCommand = new ContinueCommand(this);
            OpenFileDialogCommand = new OpenFileDialogCommand(this);

        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
