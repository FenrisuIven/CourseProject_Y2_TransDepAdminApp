using System;
using AutoMapper;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.Model.Parking;
using System.Collections.Generic;

namespace TransDep_AdminApp.ViewModel
{
    public class UIController
    {
        private static MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public static void Initialize()
        {
            mainWindow.listBox.ItemsSource = MainController.Instance.truckList;
            mainWindow.ParkingLot_ItemsCtrl.ItemsSource = ParkingLot.GetTrucksOnLot;
        }
        public static void Refresh()
        {
            mainWindow.listBox.Items.Refresh();
            mainWindow.listBox.SelectedItem = null;
            mainWindow.listBox.SelectedIndex = -1;

            mainWindow.ParkingLot_ItemsCtrl.ItemsSource = ParkingLot.GetTrucksOnLot;
            mainWindow.ParkingLot_ItemsCtrl.Items.Refresh();
        }
    }
}