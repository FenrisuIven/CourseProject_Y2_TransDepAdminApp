using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.Interfaces;
using TransDep_AdminApp.Model.Parking;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.View;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.Model
{
    
    public class MainController
    {
        public ObservableCollection<Truck> truckList { get; private set; }
        public ObservableCollection<Driver> driverList { get; private set; }
        public ObservableCollection<Task> taskList { get; private set; }
        
        private TruckListVM _localTruckVM { get; set; }
        
        
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
            Console.WriteLine(VersionUpdater.GetCurrentVersion());
            ((MainWindow)Application.Current.MainWindow).version.Text = VersionUpdater.GetCurrentVersion();
            
            /*var _driverList = ObjectMapper.AutoMapper.Map<List<Driver>, List<DriverDTO>>(new List<Driver> {
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 10, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 7, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 9, "C"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 8, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 4, "CE"),
                new (IDGenerator.GenerateRandom(), "Степан, Андрійович, Бандера", 5, "CE"),
            });
            driverList = new ObservableCollection<DriverDTO>(_driverList);

            var _truckList = ObjectMapper.AutoMapper.Map<List<Truck>, List<TruckDTO>>(new List<Truck>
            {
                new Tent(IDGenerator.GenerateRandom(), driverList[0].Id, "Тентова фура №1", 60, 60, 60, 1, false),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[1].Id, "Рефрижератор №1", 60, 60, 60, 2, false),
                new Tent(IDGenerator.GenerateRandom(), driverList[2].Id, "Тентова фура №2", 60, 60, 60, 0),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[0].Id, "Рефрижератор №2", 60, 60, 60, 3),
                new Tent(IDGenerator.GenerateRandom(), driverList[0].Id, "Тентова фура №3", 60, 60, 60, 4, false),
                new Refrigerated(IDGenerator.GenerateRandom(), driverList[0].Id, "Рефрижератор №3", 60, 60, 60, 5)
            });
                //.Select(elem => ObjectMapper.AutoMapper.Map<TruckDTO>(elem));
            truckList = new ObservableCollection<TruckDTO>(_truckList);
            taskList = new ObservableCollection<TaskDTO>();
            
            
            for (int i = 0; i < truckList.Count; i++)
            {
                truckList[0].DriverID = driverList[i].Id;
                driverList[i].AssignedTruckID = truckList[i].Id;
            }*/

            var objListTruck = FileIO<TruckDTO>.Deserialize(_serializationPath + "/truckList.json");
            var objListDriver = FileIO<DriverDTO>.Deserialize(_serializationPath + "/driverList.json");
            var objListTask = FileIO<TaskDTO>.Deserialize(_serializationPath + "/taskList.json");
            
            truckList = new ObservableCollection<Truck>(ObjectMapper.AutoMapper.Map<List<TruckDTO>, List<Truck>>(objListTruck));
            driverList = new ObservableCollection<Driver>(ObjectMapper.AutoMapper.Map<List<DriverDTO>, List<Driver>>(objListDriver));
            taskList = new ObservableCollection<Task>(ObjectMapper.AutoMapper.Map<List<TaskDTO>, List<Task>>(objListTask));

            RefreshParkingSpots();

            _localTruckVM = new();
        }

        public void Serialize()
        {
            var dtoListTruck = ObjectMapper.AutoMapper.Map<List<Truck>, List<TruckDTO>>(truckList.ToList());
            var dtoListDriver = ObjectMapper.AutoMapper.Map<List<Driver>, List<DriverDTO>>(driverList.ToList());
            var dtoListTask = ObjectMapper.AutoMapper.Map<List<Task>, List<TaskDTO>>(taskList.ToList());
            
            FileIO<TruckDTO>.Serialize(dtoListTruck, _serializationPath + "/truckList.json");
            FileIO<DriverDTO>.Serialize(dtoListDriver, _serializationPath + "/driverList.json");
            FileIO<TaskDTO>.Serialize(dtoListTask, _serializationPath + "/taskList.json");
        }

        public void RefreshParkingSpots()
        {
            foreach (var truck in truckList)
            {
                if (!truck.Availability)
                {
                    truck.SetParkingSpot(null);
                }
            }
            ParkingLot.Initialize();
        }

        public delegate void TruckPropertyChanged(string truckID, string propName);
        public event TruckPropertyChanged TruckPropChanged;

        public void PropertyChanged(string truckID, string propName = null)
        {
            TruckPropChanged?.Invoke(truckID, propName);
        }
        
        public void TruckAdditionRequested(TruckListVM sender, TruckDTO dto)
        {
            if (dto.Id is null) dto.Id = IDGenerator.GenerateRandom();
            if (dto.ParkingSpot == -1) dto.ParkingSpot = ParkingLot.GetFreeSpotNum();

            if (dto.DriverID is null)
            {
                var targetDriver = driverList.ToList().Find(elem => elem.AssignedTruckId is null);
                if (targetDriver != null)
                {
                    dto.DriverID = targetDriver.Id;
                    targetDriver.SetTruckID(dto.Id);
                }
            }

            try
            {
                var newTruck = ObjectMapper.AutoMapper.Map<Truck>(dto);
                truckList.Add(newTruck);
                ParkingLot.AddParkedTruck(dto);
                ParkingLot.TakePlace(dto.ParkingSpot);
            }
            catch { /*ignored*/ }
            
            RefreshParkingSpots();
            ((MainWindow)Application.Current.MainWindow)!.Refresh();
        }
        public void DriverAdditionRequested(DriverListVM sender, DriverDTO dto)
        {
            if (dto.Id is null)
            {
                dto.Id = IDGenerator.GenerateRandom();
            }
            if (dto.AssignedTruckID is null)
            {
                var targetTruck = truckList.ToList().Find(elem => elem.DriverID is null);
                if (targetTruck != null)
                {
                    dto.AssignedTruckID = targetTruck.Id;
                    targetTruck.SetDriverID(dto.Id);
                }
            }

            try
            {
                var newDriver = ObjectMapper.AutoMapper.Map<Driver>(dto);
                driverList.Add(newDriver);
            }
            catch { /*ignored*/ }
        }
        
        public void TaskAdditionRequested(TaskListVM sender, TaskDTO dto)
        {
            try
            {
                var newTask = ObjectMapper.AutoMapper.Map<Task>(dto);
                taskList.Add(newTask);
            }
            catch { /*ignored*/ }
        }
        
        public void RemoveTruck(object target)
        {
            var boxResult = MessageBox.Show("You really wanna remove this truck from the list?\n" +
                                            "Its info cannot be restored later!", "Remove truck from the list?",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (boxResult == MessageBoxResult.No) return;

            Truck obj = target is TruckDTO ? ObjectMapper.AutoMapper.Map<TruckDTO, Truck>(target as TruckDTO) : (Truck)target;
            truckList.Remove(obj);
        }
        public void ReplaceTruck(object target, object replace)
        {
            Truck targetObj = target is TruckDTO ? ObjectMapper.AutoMapper.Map<Truck>(target) : (Truck)target;
            Truck replaceObj = replace is TruckDTO ? ObjectMapper.AutoMapper.Map<Truck>(replace) : (Truck)replace;
            truckList = new ObservableCollection<Truck>(truckList.ToImmutableList().Replace(targetObj, replaceObj));
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
            driverList = new ObservableCollection<Driver>(driverList.ToImmutableList().Replace(targetObj, replaceObj));
        }

    }
}