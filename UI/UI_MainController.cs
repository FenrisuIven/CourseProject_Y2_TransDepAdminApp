using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Trucks;
using TransDep_AdminApp.UI.Screens;

namespace TransDep_AdminApp
{
    public class UI_Controller
    {
        private MainWindow window;
        public int amountOfParkingSpots;

        public UI_Controller(MainWindow _win)
        {
            window = _win;
        }
        public void Initialize(IEnumerable<Truck> _trucks)
        {
            window.listBox.ItemsSource = _trucks;
            
            for (int i = 0; i < amountOfParkingSpots; i++)
            {
                //window.parkingGrid.ColumnDefinitions.Add(new ColumnDefinition());
                TextBox temp = new TextBox();
                temp.Text = $"Truck {i}";
                temp.TextAlignment = TextAlignment.Center;
                
                Grid.SetColumn(temp, i);
                //window.parkingGrid.Children.Add(temp);
            }
            for (int i = 0; i < amountOfParkingSpots; i++)
            {
                TextBox temp = new TextBox();
                temp.Text = $"Truck {i}";
                temp.TextAlignment = TextAlignment.Center;
                Grid.SetRow(temp, 1);
                Grid.SetColumn(temp, i);
                //window.parkingGrid.Children.Add(temp);
            }
        }

        public void Refresh(IEnumerable<Truck> _trucks)
        {
            window.listBox.ItemsSource = _trucks;
            window.listBox.SelectedItem = null;
            window.listBox.SelectedIndex = -1;
        }
        
        public void Window(object sender)
        {
            Console.WriteLine("Got: Open Second Window");
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
                case "changeTask":
                    new ChangeTask().ShowDialog();
                    return;
                case "changeDriver":
                    new ChangeDriver().ShowDialog();
                    return;
                
                case "aboutTruck":
                    new InfoAboutTruck().ShowDialog();
                    return;
            }
        }

        public string GetTargetName(object sender)
        {
            if (sender is Button) return ((Button)sender).Name;
            if (sender is MenuItem) return ((MenuItem)sender).Name;
            
            return "";
        }
    }
}