using System;
using System.Windows;
using System.Windows.Data;

namespace TransDep_AdminApp.UI.Screens
{
    public partial class AddNewTruck : Window
    {
        public AddNewTruck()
        {
            InitializeComponent();
        }
        public bool GetCheck
        {
            get
            {
                bool truckBrandNull = input_TruckBrand.Text == null;
                bool truckModelNull = input_TruckModel.Text == null;
                return true;
            }
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