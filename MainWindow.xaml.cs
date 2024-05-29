using System;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using TransDep_AdminApp.View;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp
{
    public partial class MainWindow
    {
        public TruckListVM localTruckVM;
        public MainWindow()
        {
            InitializeComponent();
            MainController.Instance.Initialize();
            localTruckVM = new();
            listBox.ItemsSource = localTruckVM.TruckList;

            localTruckVM.CollectionChanged += () =>
            {
                listBox.ItemsSource = localTruckVM.TruckList;
                listBox.Items.Refresh();
            };

            /*var truckDTO = MainController.Instance.truckList[1];
            var truck = ObjectMapper.AutoMapper.Map<Truck>(truckDTO);
            Task task = new Task("Test", truckDTO,
                MainController.Instance.driverList[0],
                new Route("Cherkasy", "Kyiv"),
                new Cargo(1.5, 20, 20, CargoType.RequiresRefrigerator));

            Console.WriteLine(task);*/
        }
        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            var target = listBox.SelectedItem;
            UI_NewWindowHandler.Window(sender, target);
        }

        private void RemoveTruck(object sender, RoutedEventArgs e) {}
            // TODO: -- MainController.Instance.RemoveTruck(listBox.SelectedItem);
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            MainController.Instance.Serialize();
        }
        
        public void DepartureCommand(object sender, RoutedEventArgs e)
        {
            ParkingLotVM.Instance.RequestTruckAnimation(MainController.Instance.truckList[2].Id, "dep");
        }
        public void ArrivalCommand(object sender, RoutedEventArgs e)
        {
            ParkingLotVM.Instance.RequestTruckAnimation(MainController.Instance.truckList[2].Id, "arr");
        }


        private void ChangeAvalDev(object sender, RoutedEventArgs e) { }
    }
}