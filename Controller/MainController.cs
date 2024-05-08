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

        public Truck GetTruck(int idx) => truckList.GetTruckFromList(idx);

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
                    22,
                    23,
                    60,
                    true),
                new Refrigerated(
                    "Рефрижератор №1",
                    22,
                    23,
                    60,
                    false),
                new Tent(
                    "Тентова фура №2",
                    22,
                    23,
                    60,
                    true),
                new Refrigerated(
                    "Рефрижератор №2",
                    22,
                    23,
                    60,
                    false),
                new Tent(
                    "Тентова фура №3",
                    25,
                    23,
                    60,
                    true),
                new Refrigerated(
                    "Рефрижератор №3",
                    22,
                    33,
                    60,
                    false)
            });
            ui.amountOfParkingSpots = 10;

            ui.Initialize(new ObservableCollection<Truck>(truckList.GetTruckList));
        }

        public void RemoveTruck(object target)
        {
            var boxResult = MessageBox.Show("You really wanna remove this truck from the list?\n" +
                                            "Its info cannot be restored later!", "Remove truck from the list",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (boxResult == MessageBoxResult.No) return;

            truckList.RemoveTruck(target);
            ui.Refresh(new ObservableCollection<Truck>(truckList.GetTruckList));
        }
    }
    

}