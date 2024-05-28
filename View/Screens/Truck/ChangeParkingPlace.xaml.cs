using System.Linq;
using System.Windows;
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
        var newDTO = ObjectMapper.AutoMapper.Map<TruckDTO>(_localTarget);
        _localVM.OnActionRequested(this, null, newDTO, "replace");
    }
}