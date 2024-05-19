using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace TransDep_AdminApp.UI.Screens;

public partial class DriverListDisplay : Window
{
    public DriverListDisplay()
    {
        InitializeComponent();
        var list = ObjectMapper.AutoMapper.Map<List<DriverDTO>, List<Driver>>(MainController.Instance.driverList);
        MainListBox.ItemsSource = list;
    }
}