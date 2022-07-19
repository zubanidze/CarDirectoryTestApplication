using CarDirectoryTestApp.CarDirectory.Models;
using CarDirectoryTestApp.CarDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDirectoryTestApp.CarDirectory.Commands.CarDirectoryCommands
{
    internal class ShowStatsCommand : ICommand
    {
        CarDirectory_ViewModel viewModel;
        public event EventHandler? CanExecuteChanged;

        public ShowStatsCommand(CarDirectory_ViewModel vm)
        {
            this.viewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string stats = " ";
            Car oldestCar = viewModel.Cars.OrderBy(x=>x.YearOfProduction).FirstOrDefault();
            stats += "Самая древняя машина под номером - " + oldestCar.Number + ", она произведена в " + oldestCar.YearOfProduction.ToString() + " году" + "\n";
            Car newestPost = viewModel.Cars.OrderBy(x => x.DateTimeOfWrite).LastOrDefault();
            stats += "Самая последння запись о машине под номером - " + newestPost.Number + ", она произведена в " + newestPost.DateTimeOfWrite.ToString()+ "\n";
            Car strongestCar = viewModel.Cars.OrderBy(x => x.HorsePowers).LastOrDefault();
            stats += "Самый мощный двигатель в машине под номером - " + strongestCar.Number + ", в нем " + newestPost.HorsePowers.ToString() + " лошадинных сил" + "\n";
            stats += "и так далее...";
            MessageBox.Show(stats, "Пример статистики");

        }
    }
}
