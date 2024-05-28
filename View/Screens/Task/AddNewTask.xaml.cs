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
        public TaskValidation localTaskVal = new();
        public TaskListVM localTaskVM = new();
        public TruckListVM localTruckVM = new();
        public DriverListVM localDriverVM = new();

        private LoadValidationForChosenTruck TargetLoadValidationForChosenTruckVal
        {
            get => _targetLoadValidationForChosenTruckVal;
            set => _targetLoadValidationForChosenTruckVal = value;
        }

        public AddNewTask()
        {
            var availableTrucks = localTruckVM.GetFreeTrucksList();
            List<DriverDTO> drivers = new();
            for (int i = 0; i < availableTrucks.Count; i++)
            {
                drivers.Add(localDriverVM.DriverList.ToList().Find(elem => elem.Id == availableTrucks[i].DriverID));
            }

            InitializeComponent();

            localTaskVal.CargoVal = CargoVal_UserCtrl.DataContext as CargoValidation;
            localTaskVal.RouteVal = RouteVal_UserCtrl.DataContext as RouteValidation;
            
            FirstRow_UserCtrl.DataContext = localTaskVal;
            SecondRow_UserCtrl.DataContext = localTaskVal;
            
            input_Truck.ItemsSource = availableTrucks;
            input_Driver.ItemsSource = drivers;
            input_CargoType.ItemsSource = new ObservableCollection<string>(CargoTypeConverter.dictionary.Values);
            
            ((CargoValidation)CargoVal_UserCtrl.DataContext).TargetLoadValidationForChosenTruck = TargetLoadValidationForChosenTruckVal;
            TargetLoadValidationForChosenTruckVal.PropertyChanged += ((CargoValidation)CargoVal_UserCtrl.DataContext).OnLoadValidationForChosenTruckChanged;
            
            TaskInputCompletionEvent += localTaskVM.OnActionRequested;
        }

        private void Truck_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chosenTruck = input_Truck.SelectedItem as TruckDTO;
            var targetDriver = localDriverVM.DriverList.ToList().Find(elem => elem.Id == chosenTruck.DriverID);
            input_Driver.SelectedItem = targetDriver;
            TargetLoadValidationForChosenTruckVal.TargetTruck = chosenTruck;
        }

        private void OnSaveAndQuit(object sender, RoutedEventArgs e)
        {
            if (localTaskVal.IsValid() == false)
            {
                MessageBox.Show("Перевірте чи усі поля водія були правильно заповнені", null, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            OnCompletion(null, ActionType.Add);
            Close();
        }
        public delegate void TaskInputCompleted(object sender, TaskValidation prop1, TaskDTO dto = null, ActionType? tag = null);
        public event TaskInputCompleted TaskInputCompletionEvent;
        public void OnCompletion(TaskValidation val = null, ActionType? tag = null)
        {
            TaskInputCompletionEvent?.Invoke(this, val ?? localTaskVal, null, tag);
        }
    }
}