using System;
using Autofac;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TransDep_AdminApp.Parking;

namespace TransDep_AdminApp.Parking
{
    public static class ParkingLot_Ui
    {
        private static void AnimateTruckDeparture(ContentPresenter carPresenter)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            double canvasWidth = mainWindow.ParkingCanvas.Width;
            double canvasHeight = mainWindow.ParkingCanvas.Height;


            var centerYAnimation = new DoubleAnimation
            {
                To = canvasHeight / 2 - carPresenter.ActualHeight / 2,
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


            Storyboard.SetTarget(centerYAnimation, carPresenter);
            Storyboard.SetTargetProperty(centerYAnimation, new PropertyPath("(Canvas.Top)"));

            Storyboard.SetTarget(driveOutAnimation, carPresenter);
            Storyboard.SetTargetProperty(driveOutAnimation, new PropertyPath("(Canvas.Left)"));

            storyboard.Begin();
        }
        private static void AnimateTruckArrival(ContentPresenter carPresenter)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            double colPos = ((ParkedTruck)carPresenter.Content).Col * (700 / 9) + 7;
            double canvasHeight = ((ParkedTruck)carPresenter.Content).Row * 480 + 15;


            var centerYAnimation = new DoubleAnimation
            {
                To = canvasHeight / 2 - carPresenter.ActualHeight / 2,
                Duration = TimeSpan.FromSeconds(2)
            };

            var driveOutAnimation = new DoubleAnimation
            {
                To = colPos,
                BeginTime = TimeSpan.FromSeconds(2),
                Duration = TimeSpan.FromSeconds(3)
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(centerYAnimation);
            storyboard.Children.Add(driveOutAnimation);
            
            Storyboard.SetTarget(driveOutAnimation, carPresenter);
            Storyboard.SetTargetProperty(driveOutAnimation, new PropertyPath("(Canvas.Left)"));
            
            Storyboard.SetTarget(centerYAnimation, carPresenter);
            Storyboard.SetTargetProperty(centerYAnimation, new PropertyPath("(Canvas.Top)"));

            storyboard.Begin();
        }
        public static void DepartureCommand()
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            var carToDriveAway = ParkingLot.ParkedTrucks.FirstOrDefault(spot => spot.TruckId == MainController.Instance.truckList[2].Id);
            if (carToDriveAway != null)
            {
                var obj = mainWindow.ParkingLot_ItemsCtrl.ItemContainerGenerator.ContainerFromItem(carToDriveAway) as ContentPresenter;
                AnimateTruckDeparture(obj);
            }
        }
        public static void ArrivalCommand()
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            var carToDriveAway = ParkingLot.ParkedTrucks.FirstOrDefault(spot => spot.TruckId == MainController.Instance.truckList[2].Id);
            if (carToDriveAway != null)
            {
                var obj = mainWindow.ParkingLot_ItemsCtrl.ItemContainerGenerator.ContainerFromItem(carToDriveAway) as ContentPresenter;
                AnimateTruckArrival(obj);
            }
        }
    }
}