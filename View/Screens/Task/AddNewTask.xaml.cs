using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;
using TransDep_AdminApp.ViewModel.Validation;

namespace TransDep_AdminApp.View.Screens
{
    public partial class AddNewTask : Window
    {
        private LoadValidationForChosenTruck _targetLoadValidationForChosenTruckVal = new();
        public TaskListVM localTaskVM;

        private LoadValidationForChosenTruck TargetLoadValidationForChosenTruckVal
        {
            get => _targetLoadValidationForChosenTruckVal;
            set => _targetLoadValidationForChosenTruckVal = value;
        }

        public AddNewTask()
        {
            localTaskVM = new();
            var availableTrucks = MainController.Instance.truckList.Where(elem => elem.Availability).ToList();
            List<Driver> drivers = new();
            for (int i = 0; i < availableTrucks.Count; i++)
            {
                drivers.Add(MainController.Instance.driverList.ToList().Find(elem => elem.Id == availableTrucks[i].DriverID));
            }

            InitializeComponent();
            
            input_Truck.ItemsSource = availableTrucks;
            input_Driver.ItemsSource = drivers;
            input_CargoType.ItemsSource = new ObservableCollection<string>(CargoTypeConverter.dictionary.Values);
            
            ((CargoValidation)CargoVal_UserCtrl.DataContext).TargetLoadValidationForChosenTruck = TargetLoadValidationForChosenTruckVal;
            TargetLoadValidationForChosenTruckVal.PropertyChanged += ((CargoValidation)CargoVal_UserCtrl.DataContext).OnLoadValidationForChosenTruckChanged;
            
            TaskInputCompletionEvent += localTaskVM.OnActionRequested;
        }

        private void Truck_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenTruck = input_Truck.SelectedItem as Truck;
            var targetDriver = MainController.Instance.driverList.ToList().Find(elem => elem.Id == chosenTruck.DriverID);
            input_Driver.SelectedItem = targetDriver;
            TargetLoadValidationForChosenTruckVal.TargetTruck = chosenTruck;
        }

        private void OnSaveAndQuit(object sender, RoutedEventArgs e)
        {
            var taskValidation = SecondRow_UserCtrl.DataContext as TaskValidation;
            taskValidation.CargoVal = CargoVal_UserCtrl.DataContext as CargoValidation;
            taskValidation.RouteVal = RouteVal_UserCtrl.DataContext as RouteValidation;
            
            //driver is nonexistent in validation at this point
            
            if (taskValidation.IsValid() == false)
            {
                MessageBox.Show("sumth is wong");
                return;
            }
            OnCompletion(taskValidation);
            Close();
        }
        public delegate void TaskInputCompleted(object sender, TaskValidation prop1, TaskDTO dto = null, ActionType? tag = null);
        public event TaskInputCompleted TaskInputCompletionEvent;
        public void OnCompletion(TaskValidation val, ActionType? tag = null)
        {
            TaskInputCompletionEvent?.Invoke(this, val, null, tag);
        }
    }
}