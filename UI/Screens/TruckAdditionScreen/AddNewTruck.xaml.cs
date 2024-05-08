using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TransDep_AdminApp.Trucks;

namespace TransDep_AdminApp.UI.Screens
{
    public partial class AddNewTruck : Window
    {
        public AddNewTruck()
        {
            InitializeComponent();
        }

        
    }
    public class InvertedBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) => !(bool)value;

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) => throw new NotSupportedException();

    }
}