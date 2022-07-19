using CarDirectoryTestApp.CarDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDirectoryTestApp.CarDirectory.Commands.AddDocumentCommands
{
    internal class ContinueCommand : ICommand
    {
        AddDocument_ViewModel viewModel;
        public event EventHandler? CanExecuteChanged;

        public ContinueCommand(AddDocument_ViewModel vm)
        {
            this.viewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Window win = parameter as Window;
            win.DialogResult = true;
            win.Close();
        }
    }
}
