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
        public Controller controller;
        public UI_Controler uiController;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller(this);
            controller.Initialize();
            Task temp = new Task(
                "Test", 
                controller.truckList.GetTruckFromList(1), 
                new Driver("Name, Middle Name, Last Name"),
                new Route("Cherkasy", "Kyiv"),
                new Cargo(1.5, 20, "Ice Cream"));
            Console.WriteLine(temp);
        }
    }
}