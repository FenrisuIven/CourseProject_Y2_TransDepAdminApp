using System;
using System.Windows;

namespace TransDep_AdminApp.UI.Screens
{
    public partial class InfoAboutTruck : Window
    {
        private Truck targetTruck;
        public InfoAboutTruck()
        {
            InitializeComponent();
            TruckDTO obj = ((MainWindow)Application.Current.MainWindow).listBox.SelectedItem as TruckDTO;
            targetTruck = ObjectMapper.MapToTruckSub(obj) as Truck;
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
            var driverDto = MainController.Instance.driverList.Find(elem => elem.Id == targetTruck.DriverID);
            var driver = ObjectMapper.Map<Driver>(driverDto);
            driverId_Label.Content = driver.Id;
            driverName_Label.Content = $"{driver.LastName} {driver.FirstName} {driver.MiddleName}";
            driverRating_Label.Content = $"{driver.Rating}/10";
            driverCategory_Label.Content = driver.Category;

        }
    }
}