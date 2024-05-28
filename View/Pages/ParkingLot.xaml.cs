using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using TransDep_AdminApp.ViewModel;

namespace TransDep_AdminApp.View
{
    public partial class ParkingLot : Page
    {
        public ParkingLotVM localVM;
    
        public ParkingLot()
        {
            InitializeComponent();
            localVM = new();
            ParkingLot_ItemsCtrl.ItemsSource = localVM.ParkedTrucks;
            localVM.LotChanged += LocalVMCollectionChanged;
        }
        private void LocalVMCollectionChanged()
        {
            ParkingLot_ItemsCtrl.ItemsSource = localVM.ParkedTrucks;
            ParkingLot_ItemsCtrl.Items.Refresh();
        }
    }
    public class ColumnToCanvasLeftConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int column = (int)value;
            
            return column * (700 / 9) + 7;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class RowToCanvasTopConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int row = (int)value;
            return row * 480 + 15;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}