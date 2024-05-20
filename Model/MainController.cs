using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Collections.Immutable;

using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.Interfaces;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.Model
{
    
    public class MainController
    {
        private MainWindow window = Application.Current.MainWindow as MainWindow;

        public List<Truck> truckList { get; private set; }
        public List<Driver> driverList { get; private set; }
        public List<Task> taskList { get; private set; }
        
        public const string _serializationPath = "C:/Users/Nova/source/repos/TransDep_AdminApp/Serialization";
        
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
            truckList = new List<Truck>();
            driverList = new List<Driver>();
            Console.WriteLine(VersionUpdater.GetCurrentVersion());
            window.version.Text = VersionUpdater.GetCurrentVersion();
            
            driverList = new List<Driver> {
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 10, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 7, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 9, "C"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 8, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 4, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 5, "CE"),
            };
            
            truckList = new List<Truck> {
                new Tent(IDGenerator.GenerateRandom(), driverList[0].Id, "Тентова фура №1", 60, 60, 60, 1, false),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[1].Id, "Рефрижератор №1", 60, 60, 60, 2, false),
                new Tent(IDGenerator.GenerateRandom(), driverList[2].Id, "Тентова фура №2", 60, 60, 60, 0),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[0].Id, "Рефрижератор №2", 60, 60, 60, 3),
                new Tent(IDGenerator.GenerateRandom(), driverList[0].Id, "Тентова фура №3", 60, 60, 60, 4, false),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[0].Id, "Рефрижератор №3", 60, 60, 60, 5)
            };

            for (int i = 0; i < truckList.Count; i++)
            {
                truckList[0].SetDriverID(driverList[i].Id);
                driverList[i].SetTruckID(truckList[i].Id);
            }
            
            truckList = FileIO<Truck>.Deserialize(_serializationPath + "/truckList.json");
            driverList = FileIO<Driver>.Deserialize(_serializationPath + "/driverList.json");
            
            //ui.amountOfParkingSpots = 10;

            UIController.Initialize();
        }

        public void Serialize()
        {
            FileIO<Truck>.Serialize(truckList, _serializationPath + "/truckList.json");
            FileIO<Driver>.Serialize(driverList, _serializationPath + "/driverList.json");
            FileIO<Task>.Serialize(taskList, _serializationPath + "/taskList.json");
        }
        
        public void AddTruck(object target)
        {
            Truck obj = target is TruckDTO ? ObjectMapper.AutoMapper.Map<Truck>(target) : (Truck)target;
            truckList.Add(obj);
            UIController.Refresh();
        }
        
        public void RemoveTruck(object target)
        {
            var boxResult = MessageBox.Show("You really wanna remove this truck from the list?\n" +
                                            "Its info cannot be restored later!", "Remove truck from the list?",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (boxResult == MessageBoxResult.No) return;

            Truck obj = target is TruckDTO ? ObjectMapper.AutoMapper.Map<TruckDTO, Truck>(target as TruckDTO) : (Truck)target;
            truckList.Remove(obj);
            UIController.Refresh();
        }

        public void ReplaceTruck(object target, object replace)
        {
            Truck targetObj = target is TruckDTO ? ObjectMapper.AutoMapper.Map<Truck>(target) : (Truck)target;
            Truck replaceObj = replace is TruckDTO ? ObjectMapper.AutoMapper.Map<Truck>(replace) : (Truck)replace;
            truckList = truckList.ToImmutableList().Replace(targetObj, replaceObj).ToList();
            UIController.Refresh();
        }
        
        public void AddDriver(object target)
        {
            Driver obj = target is DriverDTO ? ObjectMapper.AutoMapper.Map<Driver>(target) : (Driver)target;
            driverList.Add(obj);
        }
        
        public void RemoveDriver(object target)
        {
            var boxResult = MessageBox.Show("You really wanna remove this driver from the list?\n" +
                                            "Its info cannot be restored later!", "Remove driver from the list?",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (boxResult == MessageBoxResult.No) return;

            Driver obj = target is DriverDTO ? ObjectMapper.AutoMapper.Map<Driver>(target) : (Driver)target;
            driverList.Remove(obj);
        }

        public void ReplaceDriver(object target, object replace)
        {
            Driver targetObj = target is DriverDTO ? ObjectMapper.AutoMapper.Map<Driver>(target) : (Driver)target;
            Driver replaceObj = replace is DriverDTO ? ObjectMapper.AutoMapper.Map<Driver>(replace) : (Driver)replace;
            driverList = driverList.ToImmutableList().Replace(targetObj, replaceObj).ToList();
        }
    }
}