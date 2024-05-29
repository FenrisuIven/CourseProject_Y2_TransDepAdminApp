using System.Linq;
using System.Windows;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;

namespace TransDep_AdminApp.View.Screens;

public partial class ChangeParkingPlace : Window
{
    private TruckListVM _localVM;
    private TruckDTO _localTarget;
    public ChangeParkingPlace(TruckDTO target)
    {
        InitializeComponent();
        _localVM = new();
        _localTarget = target;

        ParkingPlace.ItemsSource = Enumerable.Range(1, 18).ToList();
        ParkingPlace.SelectedItem = _localTarget.ParkingSpot;
    }

    private void OnSaveAndQuit(object sender, RoutedEventArgs e)
    {
        var newDTO = new TruckDTO {
            Type = _localTarget.Type,
            Id = _localTarget.Id,
            AssignedColor = _localTarget.AssignedColor,
            DriverID = _localTarget.DriverID,
            Name = _localTarget.Name,
            CarryingCapacity = _localTarget.CarryingCapacity,
            UsefulVolume = _localTarget.UsefulVolume,
            Capacity = _localTarget.Capacity,
            Availability = _localTarget.Availability,
            ParkingSpot = (int)ParkingPlace.SelectedItem
        };
        _localVM.OnActionRequested(null, _localTarget, newDTO,ActionType.Replace);
        Close();
    }
}