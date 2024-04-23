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
    public class Controller
    {
        private MainWindow window;
        public UI_Controler ui;

        public TruckList truckList;
        private int amountOfParkingSpots;

        public Controller(MainWindow _win)
        {
            window = _win;
        }

        public Truck GetTruck(int idx) => truckList.GetTruckFromList(idx);

        public void Initialize()
        {
            ui = new UI_Controler(window);
            truckList = new TruckList();
            Console.WriteLine(VersionUpdater.GetCurrentVersion());
            window.version.Text = VersionUpdater.GetCurrentVersion();

            truckList.SetTruckList(new List<Truck>
            {
                new Tent(
                    "Тентова фура №1",
                    new int[] { 20, 25 },
                    new int[] { 22, 23 },
                    new int[] { 60, 96 },
                    true),
                new Refrigerated(
                    "Рефрижератор №1",
                    new int[] { 12, 22 },
                    new int[] { 24, 33 },
                    new int[] { 60, 96 },
                    false),
                new Tent(
                    "Тентова фура №2",
                    new int[] { 20, 25 },
                    new int[] { 22, 23 },
                    new int[] { 60, 96 },
                    true),
                new Refrigerated(
                    "Рефрижератор №2",
                    new int[] { 12, 22 },
                    new int[] { 24, 33 },
                    new int[] { 60, 96 },
                    false),
                new Tent(
                    "Тентова фура №3",
                    new int[] { 20, 25 },
                    new int[] { 22, 23 },
                    new int[] { 60, 96 },
                    true),
                new Refrigerated(
                    "Рефрижератор №3",
                    new int[] { 12, 22 },
                    new int[] { 24, 33 },
                    new int[] { 60, 96 },
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

        public void SwitchPage(object target)
        {
            Console.WriteLine("Got: Open Second Window");
            var name = ui.GetTargetName(target);
            switch (name)
            {
                case "newTruck":
                    window.navigationFrame.Content = new Page1();
                    return;
                
                case "aboutTruck":
                    window.navigationFrame.Content = new Page2();
                    return;
            }
        }
    }
}