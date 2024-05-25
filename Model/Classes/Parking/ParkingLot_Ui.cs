using System;
using Autofac;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace TransDep_AdminApp.Model.Parking
{
    public static class ParkingLot_Ui
    {
        public static void AnimateTruckDeparture(string truckId)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            
            var carToDriveAway = ParkingLot.ParkedTrucks.FirstOrDefault(spot => spot.TruckId == truckId);
            var truckPresenter = new ContentPresenter();
            if (carToDriveAway != null)
            {
                truckPresenter = mainWindow!.ParkingLot_ItemsCtrl.ItemContainerGenerator.ContainerFromItem(carToDriveAway) as ContentPresenter;
            }
            else return;
            
            double canvasWidth = mainWindow!.ParkingCanvas.Width;
            double canvasHeight = mainWindow!.ParkingCanvas.Height;


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
        public static void AnimateTruckArrival(string truckId)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            
            var carToDriveAway = ParkingLot.ParkedTrucks.FirstOrDefault(spot => spot.TruckId == truckId);
            var truckPresenter = new ContentPresenter();
            if (carToDriveAway != null)
            {
                truckPresenter = mainWindow!.ParkingLot_ItemsCtrl.ItemContainerGenerator.ContainerFromItem(carToDriveAway) as ContentPresenter;
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
}