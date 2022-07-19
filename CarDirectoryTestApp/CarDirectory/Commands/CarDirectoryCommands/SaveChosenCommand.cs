using CarDirectoryTestApp.CarDirectory.Models;
using CarDirectoryTestApp.CarDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDirectoryTestApp.CarDirectory.Commands.CarDirectoryCommands
{
    internal class SaveChosenCommand : ICommand
    {
        CarDirectory_ViewModel viewModel;
        public event EventHandler? CanExecuteChanged;

        public SaveChosenCommand(CarDirectory_ViewModel vm)
        {
            this.viewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (viewModel.Cars.Where(x => x.IsChecked == true).Count() != 0)
            {
                foreach (var car in viewModel.Cars.Where(x => x.IsChecked == true))
                {
                    if(!IsAllDataCorrect(car))
                    {
                        MessageBox.Show("Проверьте заполнение полей");
                        return;
                    }
                    car.AuthorName = Environment.UserName;
                    car.DateTimeOfWrite = DateTime.UtcNow;
                }
                var fileName = Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.Desktop), "cars-" + DateTime.Now.ToString().Replace(':', '-') + ".json");
                using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
                {
                    FileNode fNode = new FileNode();
                    fNode.CarInfo = viewModel.Cars.Where(x => x.IsChecked == true).ToList();
                    JsonSerializer.Serialize<FileNode>(fs, fNode);
                }
                MessageBox.Show("Успешно сохранено");
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни одного автомобиля");
            }
        }
        private bool IsAllDataCorrect(Car car)
        {
            if (string.IsNullOrEmpty(car.Number))
                return false;
            if (string.IsNullOrEmpty(car.Brand))
                return false;
            if (string.IsNullOrEmpty(car.Model))
                return false;
            if (string.IsNullOrEmpty(car.Color))
                return false;
            if (string.IsNullOrEmpty(car.BodyType))
                return false;
            if (string.IsNullOrEmpty(car.EngineNumber))
                return false;
            if (car.HorsePowers<=0)
                return false;
            if (car.YearOfProduction<=1890|| car.YearOfProduction>2022)
                return false;
            if (!Regex.IsMatch(car.Number, @"^[А-Я]{1}\d{3}[А-Я]{2}\d{2,3}$"))
            {
                return false;
            }
            return true;

        }
    }
}
