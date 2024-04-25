using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    public partial class MainWindow
    {
        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            MainController.ui.Window(sender);
        }
        private void RemoveTruck(object sender, RoutedEventArgs e) => MainController.RemoveTruck(listBox.SelectedItem);
    }
}