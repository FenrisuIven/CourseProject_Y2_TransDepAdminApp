using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GoogleMapsApi.Entities.Elevation.Response;
using TransDep_AdminApp;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    public enum TruckType
    {
        Refrigerated,
        Container,
        AutoClutch,
        Tent
    }
    public class MainController
    {
        private MainWindow window;
        public UI_Controller ui;

        public TruckList truckList;
        private int amountOfParkingSpots;

        
        public static TruckType[] TruckTypeValues = (TruckType[])Enum.GetValues(typeof(TruckType));
        
        public MainController(MainWindow _win)
        {
            window = _win;
        }

        //public Truck GetTruck(int idx) => truckList.GetTruckFromList(idx);

        public void Initialize()
        {
            ui = new UI_Controller(window);
            truckList = new TruckList();
            Console.WriteLine(VersionUpdater.GetCurrentVersion());
            window.version.Text = VersionUpdater.GetCurrentVersion();

            truckList.SetTruckList(new List<Truck>
            {
                new Tent(
                    "Тентова фура №1",
                    60,
                    60,
                    60,
                    true),
                new Refrigerated(
                    "Рефрижератор №1",
                    60,
                    60,
                    60,
                    false),
                new Tent(
                    "Тентова фура №2",
                    60,
                    60,
                    60,
                    true),
                new Refrigerated(
                    "Рефрижератор №2",
                    60,
                    60,
                    60,
                    false),
                new Tent(
                    "Тентова фура №3",
                    60,
                    60,
                    60,
                    true),
                new Refrigerated(
                    "Рефрижератор №3",
                    60,
                    60,
                    60,
                    false)
            });
            ui.amountOfParkingSpots = 10;

            ui.Initialize(new ObservableCollection<TruckDTO>(truckList.GetTruckList));
        }

        public void AddTruck(object target)
        {
            TruckDTO obj = target is Truck ? ObjectMapper.Map<TruckDTO>(target) : (TruckDTO)target;
            truckList.AddNewTruck(obj);
        }
        
        public void RemoveTruck(object target)
        {
            var boxResult = MessageBox.Show("You really wanna remove this truck from the list?\n" +
                                            "Its info cannot be restored later!", "Remove truck from the list?",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (boxResult == MessageBoxResult.No) return;

            TruckDTO obj = target is Truck ? ObjectMapper.Map<TruckDTO>(target) : (TruckDTO)target;
            truckList.RemoveTruck(obj);
            ui.Refresh(new ObservableCollection<TruckDTO>(truckList.GetTruckList));
        }
    }
    

}