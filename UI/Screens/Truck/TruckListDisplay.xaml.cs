using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace TransDep_AdminApp.UI.Screens;

public partial class TruckListDisplay : Window
{
    public TruckListDisplay()
    {
        InitializeComponent();
        MainListBox.ItemsSource = MainController.Instance.truckList.Select(elem => ObjectMapper.MapToTruckSub(elem));
    }
}