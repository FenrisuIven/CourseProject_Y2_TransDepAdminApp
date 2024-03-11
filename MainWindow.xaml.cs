using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;
using TransDep_AdminApp.Misc;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    public partial class MainWindow
    {
        public IEnumerable<Truck> trucks { get; }
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(VersionUpdater.GetCurrentVersion());
            version.Text = VersionUpdater.GetCurrentVersion();
            
            trucks = new ObservableCollection<Truck>
            {
                //
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
                    false)
            };
            listBox.ItemsSource = trucks;
        }
    }
}