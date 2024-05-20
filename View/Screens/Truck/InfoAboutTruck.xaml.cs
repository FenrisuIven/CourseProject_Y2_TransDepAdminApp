using System;
using System.CodeDom;
using System.Windows;
using System.Windows.Media;

using TransDep_AdminApp.Model;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.View.Screens
{
    public partial class InfoAboutTruck : Window
    {
        private Truck targetTruck;
        public InfoAboutTruck()
        {
            InitializeComponent();
            TruckDTO obj = ((MainWindow)Application.Current.MainWindow).listBox.SelectedItem as TruckDTO;
            targetTruck = ObjectMapper.AutoMapper.Map<TruckDTO, Truck>(obj);
            InitializeTruckInfo();
            InitializeDriverInfo();
        }

        public void InitializeTruckInfo()
        {
            truckName_Label.Content = targetTruck.Name;
            truckId_Label.Content = targetTruck.Id;
            truckAvailability_Label.Content = targetTruck.Availability ? "Вільна" : "На Виклику";
            truckCarrCap_Label.Content = targetTruck.CarryingCapacity;
            truckUVolume_Label.Content = targetTruck.UsefulVolume;
            truckCap_Label.Content = targetTruck.Capacity;
        }

        public void InitializeDriverInfo()
        {
            var driver = MainController.Instance.driverList.Find(elem => elem.Id == targetTruck.DriverID);
            driverId_Label.Content = driver.Id;
            driverName_Label.Content = $"{driver.LastName} {driver.FirstName} {driver.MiddleName}";
            driverRating_Label.Content = $"{driver.Rating}/10";
            driverCategory_Label.Content = driver.Category;

        }
    }
}