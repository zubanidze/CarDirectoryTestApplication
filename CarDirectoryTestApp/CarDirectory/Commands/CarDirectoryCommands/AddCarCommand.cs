using CarDirectoryTestApp.CarDirectory.Models;
using CarDirectoryTestApp.CarDirectory.ViewModels;
using CarDirectoryTestApp.CarDirectory.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDirectoryTestApp.CarDirectory.Commands.CarDirectoryCommands
{
    internal class AddCarCommand : ICommand
    {
        CarDirectory_ViewModel viewModel;
        public event EventHandler? CanExecuteChanged;

        public AddCarCommand(CarDirectory_ViewModel vm)
        {
            this.viewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            openFileDialog.ShowDialog();
            var filePath = openFileDialog.FileName;
            try
            {
                ObservableCollection<Car> cars = new ObservableCollection<Car>(TryDeserializeCarDocument(filePath));
                foreach (Car car in cars)
                {
                    
                    viewModel.Cars.Add(car);

                }
            }
            catch
            {
                return;
            }
        }


        private List<Car> TryDeserializeCarDocument(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {

                    string data = File.ReadAllText(filePath);
                    FileNode carsCollection = JsonSerializer.Deserialize<FileNode>(data);
                    return carsCollection.CarInfo;
                }
                else
                {
                    MessageBox.Show("Выбран некорректный файл");
                    return null;
                }
            }
            catch
            {
                MessageBox.Show("Выбран некорректный файл");
                return null;
            }
        }

    }
}
