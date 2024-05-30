using System;
using System.CodeDom;
using System.Linq;
using System.Windows;
using System.Windows.Media;

using TransDep_AdminApp.Model;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.View.Screens
{
    public partial class InfoAboutTruck : Window
    {
        private TruckDTO targetTruck;
        public InfoAboutTruck(TruckDTO target)
        {
            InitializeComponent();
            targetTruck = target;
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
            var driver = MainController.Instance.driverList.ToList().Find(elem => elem.Id == targetTruck.DriverID);
            driverName_Label.Content = $"{driver.LastName} {driver.FirstName} {driver.MiddleName}";
            driverId_Label.Content = driver.Id;
            driverRating_Label.Content = $"{driver.Rating}/10";
            driverCategory_Label.Content = driver.Category;
        }
    }
}