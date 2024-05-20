using System.Linq;
using System.Windows;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Model.Parking;

namespace TransDep_AdminApp.View.Screens;

public partial class ChangeParkingPlace : Window
{
    public ChangeParkingPlace()
    {
        InitializeComponent();
        var parent = Application.Current.MainWindow as MainWindow;
        var target_Truck = parent.listBox.SelectedItem as Truck;
        var target = ParkingLot.ParkedTrucks.ToList().Find(elem => elem.TruckId == target_Truck.Id);
        
    }
}