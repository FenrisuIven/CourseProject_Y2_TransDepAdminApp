using System.Windows.Controls;
using TransDep_AdminApp.View.Screens;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.View
{
    public class UI_NewWindowHandler
    {
        public static void Window(object sender, object target)
        {
            TruckDTO truckDTO = target is TruckDTO ? (TruckDTO)target : null;
            DriverDTO driverDTO = target is DriverDTO ? (DriverDTO)target : null;
            
            var targetName = GetTargetName(sender);
            switch (targetName)
            {
                case "newTruck":
                    new AddNewTruck().ShowDialog();
                    return;
                case "newTask":
                    new AddNewTask().ShowDialog();
                    return;
                case "newDriver":
                    new AddNewDriver().ShowDialog();
                    return;
                
                case "changeTruck":
                    new ChangeTruck().ShowDialog();
                    return;
                case "changeDriver":
                    new ChangeDriver(truckDTO).ShowDialog();
                    return;
                
                case "aboutTruck":
                    new InfoAboutTruck(truckDTO).ShowDialog();
                    return;
                case "changeParkingSpace":
                    new ChangeParkingPlace(truckDTO).ShowDialog();
                    return;
                
                case "rawDriverData":
                    new DriverListDisplay().Show();
                    return;
                case "rawTruckData":
                    new TruckListDisplay().Show();
                    return;
            }
        }

        private static string GetTargetName(object sender)
        {
            if (sender is Button) return ((Button)sender).Name;
            if (sender is MenuItem) return ((MenuItem)sender).Name;
            
            return "";
        }
    }
}