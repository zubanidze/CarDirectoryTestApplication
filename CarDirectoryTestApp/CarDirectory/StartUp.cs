using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDirectoryTestApp.CarDirectory.Views;
using CarDirectoryTestApp.CarDirectory.Models;
using CarDirectoryTestApp.CarDirectory.ViewModels;
using System.Windows;
using System.Web;
using System.IO;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace CarDirectoryTestApp.CarDirectory
{
    internal class StartUp
    {
        public static string CurrentFilePath;
        [STAThread]
        public static void Main()
        {
            
            var result = AddDocumentUIHandler();
            if (!result)
                return;

            List<Car> carsCollection = new List<Car>();
            if (!string.IsNullOrEmpty(CurrentFilePath))
                carsCollection = TryDeserializeDocument();
            ObservableCollection<Car> carsObservableCollection = new ObservableCollection<Car>();
            if (carsCollection != null)
                 carsObservableCollection = new ObservableCollection<Car>(carsCollection);

            result = CarDirectoryUIHandler(carsObservableCollection);
            if (!result)
                return;
        }
        private static bool AddDocumentUIHandler()
        {
            AddDocument_GUI ui = new AddDocument_GUI();
            var vm = ui.DataContext as AddDocument_ViewModel;
            if (ui.ShowDialog() != true)
                return false;
            CurrentFilePath = vm.FilePath;
            return true;
        }
        private static bool CarDirectoryUIHandler(ObservableCollection<Car> cars)
        {
            CarDirectory_GUI ui = new CarDirectory_GUI();
            var vm = ui.DataContext as CarDirectory_ViewModel;
            vm.Cars = cars;
            if (ui.ShowDialog() != true)
                return false;
            return true;
        }

        private static List<Car> TryDeserializeDocument()
        {
            try
            {
                if (File.Exists(CurrentFilePath))
                {

                    string data = File.ReadAllText(CurrentFilePath);
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
