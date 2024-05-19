using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace TransDep_AdminApp.UI.Screens
{
    public partial class ChangeDriver : Window
    {
        private MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        private TruckDTO targetTruck;
        public ChangeDriver()
        {
            InitializeComponent();
            input_DriverSelection.ItemsSource = ObjectMapper.AutoMapper.Map<List<DriverDTO>, List<Driver>>(MainController.Instance.driverList);
            targetTruck = mainWindow.listBox.SelectedItem as TruckDTO;
            Initialize();
            input_DriverSelection.SelectedIndex = MainController.Instance.driverList.FindIndex(elem => elem.Id == targetTruck.DriverID);
        }

        public void Initialize()
        {
            var driverDto = MainController.Instance.driverList.Find(elem => elem.Id == targetTruck.DriverID);
            UpdateLabels(ObjectMapper.Map<Driver>(driverDto));
        }

        private void UpdateLabels(Driver obj)
        {
            lastName_Label.Content = obj.LastName;
            firstName_Label.Content = obj.FirstName;
            surName_Label.Content = obj.MiddleName;
            id_Label.Content = obj.Id;
            rating_Label.Content = obj.Rating + "/10";
            category_Label.Content = obj.Category;
        }

        private void Input_DriverSelection_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLabels(input_DriverSelection.SelectedItem as Driver);
        }

        private void SaveAndQuit_OnClick(object sender, RoutedEventArgs e)
        {
            var oldTarget = targetTruck;
            targetTruck.DriverID = ((Driver)input_DriverSelection.SelectedItem).Id;
            MainController.Instance.ReplaceTruck(oldTarget, targetTruck);
            Close();
        }
    }
}