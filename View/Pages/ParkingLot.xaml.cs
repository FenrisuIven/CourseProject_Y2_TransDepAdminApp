using System;
using System.IO;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;

using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.Model.Parking;

namespace TransDep_AdminApp.View
{
    public partial class ParkingLot : Page
    {
        public static string ImagePath = "images/profile-pic_mask_2.png";
    
        public ParkingLot()
        {
            InitializeComponent();
            ParkingLot_ItemsCtrl.ItemsSource = ParkingLotVM.Instance.ParkedTrucks;
            ParkingLotVM.Instance.LotChanged += LocalVMCollectionChanged;
            
            ParkingLotVM.Instance.OnAnimateTruck += RequestedTruckAnimation;
        }
        private void LocalVMCollectionChanged()
        {
            ParkingLot_ItemsCtrl.ItemsSource = ParkingLotVM.Instance.ParkedTrucks;
            ParkingLot_ItemsCtrl.Items.Refresh();
        }
        private void RequestedTruckAnimation(string id, string type)
        {
            if (type == "arr") AnimateTruckArrival(id);
            else if (type == "dep") AnimateTruckDeparture(id);
        }

        
        public void AnimateTruckDeparture(string truckId)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            
            var carToDriveAway = ParkingLotVM.Instance.ParkedTrucks.ToList().FirstOrDefault(spot => spot.TruckId == truckId);
            if (carToDriveAway == null) return;
            var truckPresenter = ParkingLot_ItemsCtrl.ItemContainerGenerator.ContainerFromItem(carToDriveAway) as ContentPresenter;
            if (truckPresenter == null) return;
            
            double canvasWidth = canvas.Width;
            double canvasHeight = canvas.Height;


            var centerYAnimation = new DoubleAnimation
            {
                To = canvasHeight / 2 - truckPresenter.ActualHeight / 2,
                Duration = TimeSpan.FromSeconds(2)
            };

            var driveOutAnimation = new DoubleAnimation
            {
                To = canvasWidth,
                BeginTime = TimeSpan.FromSeconds(2),
                Duration = TimeSpan.FromSeconds(3)
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(centerYAnimation);
            storyboard.Children.Add(driveOutAnimation);


            Storyboard.SetTarget(centerYAnimation, truckPresenter);
            Storyboard.SetTargetProperty(centerYAnimation, new PropertyPath("(Canvas.Top)"));

            Storyboard.SetTarget(driveOutAnimation, truckPresenter);
            Storyboard.SetTargetProperty(driveOutAnimation, new PropertyPath("(Canvas.Left)"));

            storyboard.Begin();
        }
        public void AnimateTruckArrival(string truckId)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            
            var carToDriveAway = ParkingLotVM.Instance.ParkedTrucks.FirstOrDefault(spot => spot.TruckId == truckId);
            var truckPresenter = new ContentPresenter();
            if (carToDriveAway != null)
            {
                truckPresenter = ParkingLot_ItemsCtrl.ItemContainerGenerator.ContainerFromItem(carToDriveAway) as ContentPresenter;
            }
            else return;
                
            double colPos = ((ParkedTruck)truckPresenter.Content).Col * (700 / 9) + 7;
            double rowPos = ((ParkedTruck)truckPresenter.Content).Row * 480 + 15;


            var driveInAnimation = new DoubleAnimation
            {
                To = colPos,
                Duration = TimeSpan.FromSeconds(3)
            };
            
            var centerYAnimation = new DoubleAnimation
            {
                To = rowPos,
                BeginTime = TimeSpan.FromSeconds(3),
                Duration = TimeSpan.FromSeconds(2)
            };


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(driveInAnimation);
            storyboard.Children.Add(centerYAnimation);
            
            Storyboard.SetTarget(driveInAnimation, truckPresenter);
            Storyboard.SetTargetProperty(driveInAnimation, new PropertyPath("(Canvas.Left)"));
            
            Storyboard.SetTarget(centerYAnimation, truckPresenter);
            Storyboard.SetTargetProperty(centerYAnimation, new PropertyPath("(Canvas.Top)"));

            storyboard.Begin();
        }
    }
    public class ColorToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color AssignedColor)
            {
                var original = new WriteableBitmap(new BitmapImage(new Uri("pack://application:,,,/" + ParkingLot.ImagePath)));

                var outBmp = BitmapFactory.New(original.PixelWidth, original.PixelHeight);
                var prevPixel = Colors.Aqua;
                var prevColor = Colors.Aqua;
                outBmp.ForEach((x, y) =>
                {
                    if (original.GetPixel(x, y) != prevPixel)
                    {
                        prevPixel = original.GetPixel(x,y);
                        prevColor = MultiplyColors(original.GetPixel(x, y), AssignedColor, original.GetPixel(x, y).A);
                    }
                    return prevColor;
                });
                
                return outBmp;
            }
            return DependencyProperty.UnsetValue;
        }

        private Color MultiplyColors(Color imagePixel, Color chosenColor, byte alpha)
        {
            var amount = alpha / 255.0;
            var r = (byte)(chosenColor.R * amount + imagePixel.R * (1 - amount));
            var g = (byte)(chosenColor.G * amount + imagePixel.G * (1 - amount));
            var b = (byte)(chosenColor.B * amount + imagePixel.B * (1 - amount));
            return Color.FromArgb(imagePixel.A, r,g,b);
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
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