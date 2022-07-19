﻿using CarDirectoryTestApp.CarDirectory.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDirectoryTestApp.CarDirectory.Commands.AddDocumentCommands
{
    internal class OpenFileDialogCommand : ICommand
    {
        AddDocument_ViewModel viewModel;
        public event EventHandler? CanExecuteChanged;

        public OpenFileDialogCommand(AddDocument_ViewModel vm)
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
            viewModel.FilePath = openFileDialog.FileName;
            Window win = parameter as Window;
            win.DialogResult = true;
            win.Close();
        }
    } 
}
