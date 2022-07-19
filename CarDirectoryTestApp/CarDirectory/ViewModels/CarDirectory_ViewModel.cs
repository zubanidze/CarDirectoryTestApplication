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
using CarDirectoryTestApp.CarDirectory.Commands.CarDirectoryCommands;

namespace CarDirectoryTestApp.CarDirectory.ViewModels
{
    internal class CarDirectory_ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Car> cars;

        public ObservableCollection<Car> Cars
        {
            get => cars;
            set
            {
                cars = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCarCommand { get; set; }
        public ICommand SaveAllCommand { get; set; }
        public ICommand SaveChosenCommand { get; set; }
        public ICommand ShowStatsCommand { get; set; }  
        public CarDirectory_ViewModel()
        {
            AddCarCommand = new AddCarCommand(this);
            SaveAllCommand = new SaveAllCommand(this);
            SaveChosenCommand = new SaveChosenCommand(this);
            ShowStatsCommand = new ShowStatsCommand(this);

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
