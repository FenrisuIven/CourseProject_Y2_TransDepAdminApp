using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.Interfaces;
using TransDep_AdminApp.Model.Trucks;
using TransDep_AdminApp.ViewModel.DTO;
using TransDep_AdminApp.Model.Parking;
using TransDep_AdminApp.ViewModel.Validation;


namespace TransDep_AdminApp.View.Screens
{
    public partial class AddNewTruck : IDataGatherer<Truck>
    {
        private (Driver? newDriver, string existingDriverId) driver;
        public void testButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine("Got: Create New Truck");
            var obj = GatherData();
            if (driver.Item1 != null) MainController.Instance.AddDriver(driver.Item1);
            if (obj != null)
            {
                MainController.Instance.AddTruck(obj);
                ParkingLot.TakePlace(obj.ParkingSpot);
                ParkingLot.AddParkedTruck(obj);
                UIController.Refresh();
                Close();
            }
            
        }
        
        public Truck GatherData()
        {
           // TODO: Check if fields are valid before parsing and creating an object
           // bool valid = ((TruckValidation)TruckData_UserCtrl.DataContext).
            
            var chosenType = (TruckType)input_TruckType.SelectedItem;

            try
            {
                CreateDriver();
                
                var name = GetName();
                var currentTruckId = IDGenerator.GenerateRandom(5);
                var driverId = driver.Item1 != null ? driver.Item1.Id : driver.Item2;
                var carryCap = int.Parse(input_CarryingCapacity_r.Text);
                var useVol = int.Parse(input_UsefulVolume_r.Text);
                var cap = int.Parse(input_Capacity_r.Text);
                var parkingSpot = ParkingLot.GetFreeSpotNum();

                if (driver.newDriver != null) driver.newDriver.SetTruckID(currentTruckId);
                else if (!string.IsNullOrEmpty(driver.existingDriverId))
                {
                    var driverDto = input_DriverSelection.SelectedItem as DriverDTO;
                    driverDto.AssignedTruckID = currentTruckId;
                    MainController.Instance.ReplaceDriver(input_DriverSelection.SelectedItem as DriverDTO, driverDto);
                }
                
                switch (chosenType)
                {
                    case TruckType.Tent:
                        return new Tent(
                            currentTruckId, driverId, name, carryCap, useVol, cap, parkingSpot);
                    
                    case TruckType.Refrigerated:
                        return new Refrigerated(
                            currentTruckId, driverId, name, carryCap, useVol, cap, parkingSpot);

                    case TruckType.AutoClutch:
                        return new AutomaticClutch(
                            currentTruckId, driverId, name, carryCap, useVol, cap, parkingSpot);

                    case TruckType.Container:
                        return new Container(
                            currentTruckId, driverId, name, carryCap, useVol, cap, parkingSpot);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Перевірте чи усі поля були заповнені", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (FormatException)
            {
                MessageBox.Show("Перевірте чи усі поля у правильному форматі","", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Чи дійсно ви хочете вийти\nбез збереження введених даних?","", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            }

            return default;
        }

        public void CreateDriver()
        {
            if (input_DriverSelection.SelectedIndex != -1)
            {
                var target = input_DriverSelection.SelectedItem as DriverDTO;
                driver.Item2 = target.Id;
                return;
            }

            var fullName = input_DriverFirstName.Text + "," + input_DriverSurName.Text + "," + input_DriverLastName.Text;
            var rating = int.Parse(((ComboBoxItem)input_DriverRating.SelectedValue).Content as string);
            var category = ((ComboBoxItem)input_DriverCategory.SelectedValue).Content as string;
            
            driver.Item1 = new Driver(IDGenerator.GenerateRandom(), fullName, rating, category);
        }
        
        private string GetName()
        {
            if (!string.IsNullOrEmpty(input_TruckName_l.Text)) return input_TruckName_l.Text;
            
            string res = "";
            if (!string.IsNullOrEmpty(input_TruckBrand_l.Text)) res += input_TruckBrand_l.Text + " ";
            if (!string.IsNullOrEmpty(input_TruckModel_l.Text)) res += input_TruckModel_l.Text;
            return res;
        }

        private void TruckType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var target = (TruckType)input_TruckType.SelectedItem;
            TruckChars_UserControl.DataContext = ValidationsFactory.CreateValidation(target);
        }

        private void Input_TruckName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            input_TruckName_l.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            input_TruckBrand_l.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            input_TruckModel_l.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}