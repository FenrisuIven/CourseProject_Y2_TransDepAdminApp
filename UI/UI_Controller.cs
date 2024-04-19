using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    public class UI_Controler
    {
        private MainWindow window;
        private Window addWindow;
        public int amountOfParkingSpots;
        public UI_Controler(MainWindow _win)
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

        public void OpenAddWindow()
        {
            
        }
    }
}