using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Model.Parking;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.View.Screens;

namespace TransDep_AdminApp.View
{
    public class UI_Controller
    {
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