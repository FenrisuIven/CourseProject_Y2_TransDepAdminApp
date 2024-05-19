using System;
using Autofac;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TransDep_AdminApp.Parking;

namespace TransDep_AdminApp
{
    public partial class MainWindow
    {
        private ParkingLot _parkingLot;
        public MainWindow()
        {
            InitializeComponent();
            MainController.Instance.Initialize();
            Task task = new Task(
                "Test", 
                ObjectMapper.MapToTruckSub(MainController.Instance.truckList[1]), 
                MainController.Instance.driverList[0],
                new Route("Cherkasy", "Kyiv"),
                new Cargo(1.5, 20, CargoType.RequiresRefrigerator));
            
            Console.WriteLine(task);
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            MainController.Instance.Serialize();
        }
    }
}