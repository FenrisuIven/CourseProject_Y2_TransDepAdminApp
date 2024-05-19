using System;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autofac.Core.Activators;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Trucks;
using TransDep_AdminApp.Parking;

namespace TransDep_AdminApp
{
    
    public class MainController
    {
        private MainWindow window = Application.Current.MainWindow as MainWindow;

        public List<TruckDTO> truckList { get; private set; }
        public List<DriverDTO> driverList { get; private set; }
        public List<TaskDTO> taskList { get; private set; }
        
        public const string _serializationPath = "C:/Users/Nova/source/repos/TransDep_AdminApp/Controller/Serialization";
        
        // -- Singleton --
        private MainController() { }
        private static MainController _instance;
        public static MainController Instance
        {
            get
            {
                if (_instance == null) _instance = new MainController();
                return _instance;
            }
        }
        // -- Singleton --

        public void Initialize()
        {
            truckList = new List<TruckDTO>();
            driverList = new List<DriverDTO>();
            Console.WriteLine(VersionUpdater.GetCurrentVersion());
            window.version.Text = VersionUpdater.GetCurrentVersion();
            
            /*driverList = ObjectMapper.AutoMapper.Map<List<Driver>, List<DriverDTO>>(new List<Driver>
            {
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 10, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 7, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 9, "C"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 8, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 4, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 5, "CE"),
            });
            
            truckList = ObjectMapper.AutoMapper.Map<List<Truck>, List<TruckDTO>>(new List<Truck> 
            {
                new Tent(IDGenerator.GenerateRandom(), driverList[0].Id, "Тентова фура №1", 60, 60, 60, false),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[1].Id, "Рефрижератор №1", 60, 60, 60, false),
                new Tent(IDGenerator.GenerateRandom(), driverList[2].Id, "Тентова фура №2", 60, 60, 60),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[0].Id, "Рефрижератор №2", 60, 60, 60),
                new Tent(IDGenerator.GenerateRandom(), driverList[0].Id, "Тентова фура №3", 60, 60, 60, false),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[0].Id, "Рефрижератор №3", 60, 60, 60)
            });

            for (int i = 0; i < truckList.Count; i++)
            {
                truckList[i].DriverID = driverList[i].Id;
                driverList[i].AssignedTruckID = truckList[i].Id;
            }*/
            
            truckList = FileIO<TruckDTO>.Deserialize(_serializationPath + "/truckList.json");
            driverList = FileIO<DriverDTO>.Deserialize(_serializationPath + "/driverList.json");
            
            //ui.amountOfParkingSpots = 10;

            UI_Controller.Instance.Initialize();
        }

        public void Serialize()
        {
            FileIO<TruckDTO>.Serialize(truckList, _serializationPath + "/truckList.json");
            FileIO<DriverDTO>.Serialize(driverList, _serializationPath + "/driverList.json");
            FileIO<TaskDTO>.Serialize(taskList, _serializationPath + "/taskList.json");
        }
        
        public void AddTruck(object target)
        {
            TruckDTO obj = target is Truck ? ObjectMapper.Map<TruckDTO>(target) : (TruckDTO)target;
            truckList.Add(obj);
            UI_Controller.Instance.Refresh();
        }
        
        public void RemoveTruck(object target)
        {
            var boxResult = MessageBox.Show("You really wanna remove this truck from the list?\n" +
                                            "Its info cannot be restored later!", "Remove truck from the list?",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (boxResult == MessageBoxResult.No) return;

            TruckDTO obj = target is Truck ? ObjectMapper.Map<TruckDTO>(target) : (TruckDTO)target;
            truckList.Remove(obj);
            UI_Controller.Instance.Refresh();
        }

        public void ReplaceTruck(object target, object replace)
        {
            TruckDTO targetDto = target is Truck ? ObjectMapper.Map<TruckDTO>(target) : (TruckDTO)target;
            TruckDTO replaceDto = replace is Truck ? ObjectMapper.Map<TruckDTO>(replace) : (TruckDTO)replace;
            truckList = truckList.ToImmutableList().Replace(targetDto, replaceDto).ToList();
            UI_Controller.Instance.Refresh();
        }
        
        public void AddDriver(object target)
        {
            DriverDTO obj = target is Driver ? ObjectMapper.Map<DriverDTO>(target) : (DriverDTO)target;
            driverList.Add(obj);
        }
        
        public void RemoveDriver(object target)
        {
            var boxResult = MessageBox.Show("You really wanna remove this driver from the list?\n" +
                                            "Its info cannot be restored later!", "Remove driver from the list?",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (boxResult == MessageBoxResult.No) return;

            DriverDTO obj = target is Driver ? ObjectMapper.Map<DriverDTO>(target) : (DriverDTO)target;
            driverList.Remove(obj);
        }

        public void ReplaceDriver(object target, object replace)
        {
            DriverDTO targetDto = target is Driver ? ObjectMapper.Map<DriverDTO>(target) : (DriverDTO)target;
            DriverDTO replaceDto = replace is Driver ? ObjectMapper.Map<DriverDTO>(replace) : (DriverDTO)replace;
            driverList = driverList.ToImmutableList().Replace(targetDto, replaceDto).ToList();
        }
    }
}