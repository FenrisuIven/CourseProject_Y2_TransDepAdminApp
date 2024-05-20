using System;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

using TransDep_AdminApp.View;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.Model.Parking;

namespace TransDep_AdminApp
{
    public partial class MainWindow
    {
        private ParkingLot _parkingLot;
        public MainWindow()
        {
            InitializeComponent();
            MainController.Instance.Initialize();
            var truckDTO = MainController.Instance.truckList[1];
            var truck = ObjectMapper.AutoMapper.Map<Truck>(truckDTO);
            Task task = new Task("Test", truckDTO, 
                MainController.Instance.driverList[0],
                new Route("Cherkasy", "Kyiv"),
                new Cargo(1.5, 20, 20, CargoType.RequiresRefrigerator));
            
            Console.WriteLine(task);
        }
        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            UI_Controller.Window(sender);
        }
        
        private void RemoveTruck(object sender, RoutedEventArgs e) => MainController.Instance.RemoveTruck(listBox.SelectedItem);
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            MainController.Instance.Serialize();
        }
        public void DepartureCommand(object sender, RoutedEventArgs e)
        {
            var carToDriveAway = ParkingLot.ParkedTrucks.FirstOrDefault(spot => spot.TruckId == MainController.Instance.truckList[2].Id);
            if (carToDriveAway != null)
            {
                var obj = ParkingLot_ItemsCtrl.ItemContainerGenerator.ContainerFromItem(carToDriveAway) as ContentPresenter;
                ParkingLot_Ui.AnimateTruckDeparture(obj);
            }
        }
        public void ArrivalCommand(object sender, RoutedEventArgs e)
        {
            var carToDriveAway = ParkingLot.ParkedTrucks.FirstOrDefault(spot => spot.TruckId == MainController.Instance.truckList[2].Id);
            if (carToDriveAway != null)
            {
                var obj = ParkingLot_ItemsCtrl.ItemContainerGenerator.ContainerFromItem(carToDriveAway) as ContentPresenter;
                ParkingLot_Ui.AnimateTruckArrival(obj);
            }
        }
    }
}