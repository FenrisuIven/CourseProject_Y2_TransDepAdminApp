using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.View.Screens
{
    public partial class ChangeDriver : Window
    {
        private TruckDTO targetTruck;
        private TruckListVM localTruckVM = new();
        private DriverListVM localDriverVM = new();
        public ChangeDriver(TruckDTO target)
        {
            InitializeComponent();
            input_DriverSelection.ItemsSource = localDriverVM.DriverList;
            targetTruck = target;
            Initialize();
            input_DriverSelection.SelectedIndex = localDriverVM.DriverList.ToList().FindIndex(elem => elem.Id == targetTruck.DriverID);
        }

        public void Initialize()
        {
            var driver = localDriverVM.DriverList.ToList().Find(elem => elem.Id == targetTruck.DriverID);
            UpdateLabels(driver);
        }

        private void UpdateLabels(DriverDTO obj)
        {
            firstName_Label.Content = obj.FullName.Split(',')[1];
            surName_Label.Content = obj.FullName.Split(',')[2];
            lastName_Label.Content = obj.FullName.Split(',')[0];
            id_Label.Content = obj.Id;
            rating_Label.Content = obj.Rating + "/10";
            category_Label.Content = obj.Category;
        }

        private void Input_DriverSelection_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLabels(input_DriverSelection.SelectedItem as DriverDTO);
        }

        private void OnSaveAndQuit(object sender, RoutedEventArgs e)
        {
            var oldTarget = targetTruck;
            targetTruck.DriverID = ((DriverDTO)input_DriverSelection.SelectedItem).Id;
            
            localTruckVM.OnActionRequested(null, oldTarget,targetTruck, ActionType.Replace);
            Close();
        }
    }
}