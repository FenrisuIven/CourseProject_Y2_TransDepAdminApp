using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;
using TransDep_AdminApp;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    public partial class MainWindow
    {
        public MainController MainController;
        public UI_Controller uiController;
        public MainWindow()
        {
            InitializeComponent();
            MainController = new MainController(this);
            MainController.Initialize();
            Task temp = new Task(
                "Test", 
                MainController.truckList.GetTruckFromList(1), 
                new Driver("Name, Middle Name, Last Name"),
                new Route("Cherkasy", "Kyiv"),
                new Cargo(1.5, 20, "Ice Cream"));
            Console.WriteLine(temp);
        }
    }
}