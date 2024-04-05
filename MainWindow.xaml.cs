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
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller(this);
            controller.Initialize();
            Task temp = new Task(
                "Test", 
                TruckList.GetTruckFromList(1), 
                new Driver("Name, Middle Name, Last Name"),
                new Route("Cherkassy", "Kyiv"),
                new Cargo(1.5, 20, "Ice Cream"));
            Console.WriteLine(temp);
        }
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        } 
    }
}