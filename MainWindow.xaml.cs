using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using AutoMapper;
using TransDep_AdminApp;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp
{
    public partial class MainWindow
    {
        public MainController mainController;
        public UI_Controller uiController;
        public MainWindow()
        {
            InitializeComponent();
            mainController = new MainController(this);
            mainController.Initialize();
            Task task = new Task(
                "Test", 
                mainController.truckList.GetTruckFromList(1), 
                new Driver("Name,Middle Name,Last Name", 7),
                new Route("Cherkasy", "Kyiv"),
                new Cargo(1.5, 20, CargoType.RequiresRefrigerator));
            
            // var cargo = new Cargo(1,1,CargoType.RequiresRefrigerator);
            // var cargoDto = ObjectMapper.Map<CargoDTO>(cargo);
            // var cargoObj = ObjectMapper.Map<Cargo>(cargoDto);
            
            Console.WriteLine(task);
        }
    }
}