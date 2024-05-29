using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;
using TransDep_AdminApp.ViewModel.Validation;

namespace TransDep_AdminApp.View.Screens
{
    public partial class AddNewTruck : Window
    {
        public TruckListVM localTruckVM = new();
        public TruckValidation localTruckVal = new(); 
        public DriverListVM localDriverVM = new();
        public DriverValidation localDriverVal = new();
      
        #region ViewSide
        public AddNewTruck()
        {
            InitializeComponent();
            input_DriverSelection.ItemsSource = localDriverVM.GetFreeDriversList();
            input_TruckType.ItemsSource = TruckTypeConvert.dictionary.Values;

            localTruckVal = TruckData_UserCtrl.DataContext as TruckValidation;
            localTruckVal!.TruckCharsValidation = TruckChars_UserCtrl.DataContext as TruckCharsValidationBase;

            Input_DriverRating.ItemsSource = DriverConfiguration.Ratings;
            Input_DriverCategory.ItemsSource = DriverConfiguration.Categories;
            
            input_DriverSelection.DataContext = localDriverVal;
            SecondRow_UserCtrl.DataContext = null;
            
            TruckInputCompletionEvent += localTruckVM.OnActionRequested; 
            DriverInputCompletionEvent += localDriverVM.OnActionRequested;
        }

        private void Check_CreateNewDriver_OnChecked(object sender, RoutedEventArgs e)
        {
            input_DriverSelection.DataContext = null;
            SecondRow_UserCtrl.DataContext = localDriverVal;
        }
        private void Check_CreateNewDriver_OnUnchecked(object sender, RoutedEventArgs e)
        {
            input_DriverSelection.DataContext = localDriverVal;
            SecondRow_UserCtrl.DataContext = null;
        }
        
        private void TruckType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var target = (TruckType)input_TruckType.SelectedItem;
            TruckChars_UserCtrl.DataContext = ValidationsFactory.CreateTruckValidation(target);
            localTruckVal!.TruckCharsValidation = TruckChars_UserCtrl.DataContext as TruckCharsValidationBase;
        }
        private void Input_TruckName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            input_TruckName_l.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            input_TruckBrand_l.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            input_TruckModel_l.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }
        
        #endregion
        
        public void SaveAndQuit(object sender, EventArgs e)
        {
            if (!localTruckVal.IsValid())
            {
                MessageBox.Show("Перевірте чи усі поля вантажівки були правильно заповнені", null, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (check_CreateNewDriver.IsChecked == true)
            {
                if (!localDriverVal.isValid())
                {
                    MessageBox.Show("Перевірте чи усі поля водія були правильно заповнені", null, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
            }
            else
            {
                if (localDriverVal.DriverDto is null)
                {
                    MessageBox.Show("Перевірте чи усі поля водія були правильно заповнені", null, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
            }

            if (localDriverVal.DriverDto != null) localTruckVal.DesiredDriverID = localDriverVal.DriverDto.Id;
            
            OnCompletion(ActionType.Add);
            Close();
        }

        public delegate void TruckInputCompleted(TruckValidation prop1, TruckDTO dto = null, TruckDTO prop2 = null, ActionType? tag = null);
        public delegate void DriverInputCompleted(DriverValidation prop1, DriverDTO dto = null, DriverDTO prop2 = null, ActionType? tag = null);
        public event TruckInputCompleted TruckInputCompletionEvent;
        public event DriverInputCompleted DriverInputCompletionEvent;
        public void OnCompletion(ActionType? tag = null)
        {
            TruckInputCompletionEvent?.Invoke(localTruckVal, null, null, tag);
            DriverInputCompletionEvent?.Invoke(localDriverVal, null, null, tag);
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