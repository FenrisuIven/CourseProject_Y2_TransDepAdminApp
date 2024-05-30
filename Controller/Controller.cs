using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    public class Controller
    {
        private MainWindow window;
        private UI_Controler ui;

        private IEnumerable<Truck> trucks;
        private int amountOfParkingSpots;

        public Controller(MainWindow _win)
        {
            window = _win;
        }
        
        public void Initialize()
        {
            ui = new UI_Controler(window);
            Console.WriteLine(VersionUpdater.GetCurrentVersion());
            window.version.Text = VersionUpdater.GetCurrentVersion();
            
            TruckList.SetTruckList(new List<Truck>
            {
                new Tent(
                    "Тентова фура №1",
                    new int[]{20, 25},
                    new int[]{22, 23},
                    new int[]{60, 96},
                    true),
                new Refrigerated(
                    "Рефрижератор №1",
                    new int[]{12, 22},
                    new int[]{24, 33},
                    new int[]{60, 96},
                    false),
                new Tent(
                    "Тентова фура №2",
                    new int[]{20, 25},
                    new int[]{22, 23},
                    new int[]{60, 96},
                    true),
                new Refrigerated(
                    "Рефрижератор №2",
                    new int[]{12, 22},
                    new int[]{24, 33},
                    new int[]{60, 96},
                    false),
                new Tent(
                    "Тентова фура №3",
                    new int[]{20, 25},
                    new int[]{22, 23},
                    new int[]{60, 96},
                    true),
                new Refrigerated(
                    "Рефрижератор №3",
                    new int[]{12, 22},
                    new int[]{24, 33},
                    new int[]{60, 96},
                    false)
            });
            ui.amountOfParkingSpots = 10;
            var truckList = new ObservableCollection<Truck>(TruckList.GetTruckList);
            
            ui.Initialize(truckList);
        }
    }
}