using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.View.Screens
{
    public partial class ChangeDriver : Window
    {
        private MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        private Truck targetTruck;
        public ChangeDriver()
        {
            InitializeComponent();
            input_DriverSelection.ItemsSource = MainController.Instance.driverList;
            targetTruck = mainWindow.listBox.SelectedItem as Truck;
            Initialize();
            input_DriverSelection.SelectedIndex = MainController.Instance.driverList.ToList().FindIndex(elem => elem.Id == targetTruck.DriverID);
        }

        public void Initialize()
        {
            var driver = MainController.Instance.driverList.ToList().Find(elem => elem.Id == targetTruck.DriverID);
            UpdateLabels(driver);
        }

        private void UpdateLabels(Driver obj)
        {
            var driver = ObjectMapper.AutoMapper.Map<Driver>(obj);
            lastName_Label.Content = driver.LastName;
            firstName_Label.Content = driver.FirstName;
            surName_Label.Content = driver.MiddleName;
            id_Label.Content = driver.Id;
            rating_Label.Content = driver.Rating + "/10";
            category_Label.Content = driver.Category;
        }

        private void Input_DriverSelection_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLabels(input_DriverSelection.SelectedItem as Driver);
        }

        private void SaveAndQuit_OnClick(object sender, RoutedEventArgs e)
        {
            var oldTarget = targetTruck;
            targetTruck.SetDriverID(((Driver)input_DriverSelection.SelectedItem).Id);
            MainController.Instance.ReplaceTruck(oldTarget, targetTruck);
            Close();
        }
    }
}