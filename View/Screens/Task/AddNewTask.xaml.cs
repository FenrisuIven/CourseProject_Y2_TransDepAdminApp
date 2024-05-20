using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using TransDep_AdminApp.Model;

namespace TransDep_AdminApp.View.Screens
{
    public partial class AddNewTask : Window
    {
        public AddNewTask()
        {
            var availableTrucks = MainController.Instance.truckList.Where(elem => elem.Availability).ToList();
            List<Driver> drivers = new();
            for (int i = 0; i < availableTrucks.Count; i++)
            {
                drivers.Add(MainController.Instance.driverList.Find(elem => elem.Id == availableTrucks[i].DriverID));
            }

            InitializeComponent();
            input_Truck.ItemsSource = availableTrucks;
            input_Driver.ItemsSource = drivers;
            input_CargoType.ItemsSource = new ObservableCollection<string>(CargoTypeConverter.dictionary.Values);
        }

        private void Truck_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenTruck = input_Truck.SelectedItem as Truck;
            var targetDriver = MainController.Instance.driverList.Find(elem => elem.Id == chosenTruck.DriverID);
            input_Driver.SelectedItem = targetDriver;
        }
    }
}