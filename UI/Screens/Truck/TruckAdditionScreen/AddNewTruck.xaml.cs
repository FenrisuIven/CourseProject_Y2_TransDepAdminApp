using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model.View;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp.UI.Screens
{
    public partial class AddNewTruck : Window
    {
        public AddNewTruck()
        {
            InitializeComponent();
            input_DriverSelection.ItemsSource = MainController.Instance.driverList;
            input_TruckType.ItemsSource = new ObservableCollection<TruckType>(TruckTypeConvert.dictionary.Values);
        }

        private void Check_CreateNewDriver_OnChecked(object sender, RoutedEventArgs e)
        {
            input_DriverSelection.DataContext = null;
            SecondRow_UserCtrl.DataContext = new DriverValidation();
        }

        private void Check_CreateNewDriver_OnUnchecked(object sender, RoutedEventArgs e)
        {
            input_DriverSelection.DataContext = new DriverValidation();
            SecondRow_UserCtrl.DataContext = null;
        }
    }
    public class InvertedBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) => !(bool)value;

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) => throw new NotSupportedException();

    }
    public class SelectionAvailableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) => value != null;

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) => throw new NotSupportedException();

    }
}