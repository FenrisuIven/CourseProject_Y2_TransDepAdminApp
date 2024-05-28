using System;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

using TransDep_AdminApp.View;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp
{
    public partial class MainWindow
    {
        private TruckListVM _localTruckVM;
        public MainWindow()
        {
            InitializeComponent();
            MainController.Instance.Initialize();
            Initialize();
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
            var target = listBox.SelectedItem;
            UI_NewWindowHandler.Window(sender, target);
        }
        private void ChangeAvalDeb(object sender, RoutedEventArgs e)
        {
            object target = listBox.SelectedItem;
            Truck obj = target is TruckDTO ? ObjectMapper.AutoMapper.Map<TruckDTO, Truck>(target as TruckDTO) : (Truck)target;
            int idx = MainController.Instance.truckList.ToList().FindIndex(elem => elem.Id == obj.Id);
            
            bool availability = !obj.Availability;
            MainController.Instance.truckList[idx].SetAvailability(availability);
            
            //something strange
            /*if (availability)
            {
                MainController.Instance.truckList[idx].SetParkingSpot(ParkingLot.GetFreeSpotNum());
                ParkingLot.AddParkedTruck(obj.Id);
                ParkingLot.TakePlace(MainController.Instance.truckList[idx].ParkingSpot!.Value);
            }
            //if (!availability) ParkingLot.Initialize();
            MainController.Instance.RefreshParkingSpots();
            
            MainController.Instance.PropertyChanged(MainController.Instance.truckList[idx].Id, "Availability");*/
            //something strange
        }

        private void RemoveTruck(object sender, RoutedEventArgs e) {}
            // TODO: -- MainController.Instance.RemoveTruck(listBox.SelectedItem);
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            MainController.Instance.Serialize();
        }
        
        public void Initialize()
        {
            _localTruckVM = new();
            listBox.ItemsSource = _localTruckVM.TruckList;
            //ParkingLot_ItemsCtrl.ItemsSource = ParkingLot.GetTrucksOnLot;
        }
        public void Refresh()
        {
            //ParkingLot_ItemsCtrl.ItemsSource = ParkingLot.GetTrucksOnLot;
            //ParkingLot_ItemsCtrl.Items.Refresh();
        }
        
        public void DepartureCommand(object sender, RoutedEventArgs e)
        {
            //ParkingLot_Ui.AnimateTruckDeparture(MainController.Instance.truckList[2].Id);
        }
        public void ArrivalCommand(object sender, RoutedEventArgs e)
        {
            //ParkingLot_Ui.AnimateTruckArrival(MainController.Instance.truckList[2].Id);
        }

        
    }
}