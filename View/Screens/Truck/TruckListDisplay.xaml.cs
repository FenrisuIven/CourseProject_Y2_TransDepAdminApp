using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

using TransDep_AdminApp.Model;
using TransDep_AdminApp.ViewModel;

namespace TransDep_AdminApp.View.Screens;

public partial class TruckListDisplay : Window
{
    public TruckListDisplay()
    {
        InitializeComponent();
        MainListBox.ItemsSource = MainController.Instance.truckList.Select(elem => ObjectMapper.AutoMapper.Map<Truck>(elem));
    }
}