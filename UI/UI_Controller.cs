using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Parking;
using TransDep_AdminApp.Trucks;
using TransDep_AdminApp.UI.Screens;

namespace TransDep_AdminApp
{
    public class UI_Controller
    {
        private MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public int amountOfParkingSpots;

        private UI_Controller() { }
        private static UI_Controller _instance;
        public static UI_Controller Instance
        {
            get
            {
                if (_instance == null) _instance = new UI_Controller();
                return _instance;
            }
        }
        public void Initialize()
        {
            mainWindow.listBox.ItemsSource = MainController.Instance.truckList;
            mainWindow.ParkingLot_ItemsCtrl.ItemsSource = ParkingLot.GetTrucksOnLot;
        }

        public void Refresh()
        {
            mainWindow.listBox.Items.Refresh();
            mainWindow.listBox.SelectedItem = null;
            mainWindow.listBox.SelectedIndex = -1;

            mainWindow.ParkingLot_ItemsCtrl.ItemsSource = ParkingLot.GetTrucksOnLot;
            mainWindow.ParkingLot_ItemsCtrl.Items.Refresh();
        }
        
        public static void Window(object sender)
        {
            var target = GetTargetName(sender);
            switch (target)
            {
                case "newTruck":
                    new AddNewTruck().ShowDialog();
                    return;
                case "newTask":
                    new AddNewTask().ShowDialog();
                    return;
                case "newDriver":
                    new AddNewDriver().ShowDialog();
                    return;
                
                case "changeTruck":
                    new ChangeTruck().ShowDialog();
                    return;
                case "changeDriver":
                    new ChangeDriver().ShowDialog();
                    return;
                
                case "aboutTruck":
                    new InfoAboutTruck().ShowDialog();
                    return;
                case "changeParkingSpace":
                    new ChangeParkingPlace().ShowDialog();
                    return;
                
                case "rawDriverData":
                    new DriverListDisplay().Show();
                    return;
                case "rawTruckData":
                    new TruckListDisplay().Show();
                    return;
            }
        }

        private static string GetTargetName(object sender)
        {
            if (sender is Button) return ((Button)sender).Name;
            if (sender is MenuItem) return ((MenuItem)sender).Name;
            
            return "";
        }
    }
}