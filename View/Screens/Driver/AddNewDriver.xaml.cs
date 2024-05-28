using System;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.ViewModel;
using TransDep_AdminApp.ViewModel.DTO;
using TransDep_AdminApp.ViewModel.Validation;

namespace TransDep_AdminApp.View.Screens
{
    public partial class AddNewDriver : Window
    {
        public DriverListVM localDriverVM;
        public DriverValidation localDriverVal;
        public AddNewDriver()
        {
            InitializeComponent();
            localDriverVM = new DriverListVM();
            input_DriverSelection.ItemsSource = localDriverVM.DriverList;

            localDriverVal = new DriverValidation() 
            {
                IgnoredProps = new[]{ "DriverDto" }
            };
            input_DriverSelection.DataContext = localDriverVM;
            DriverData_UserCtrl.DataContext = localDriverVal;
            
            Input_Category.ItemsSource = DriverConfiguration.Categories;
            Input_Rating.ItemsSource = DriverConfiguration.Ratings;
            
            DriverInputCompletionEvent += localDriverVM.OnActionRequested;
        }
        
        public void SaveAndQuit(object sender, EventArgs e)
        {
            if (!localDriverVal.isValid())
            {
                MessageBox.Show("Перевірте чи усі поля водія були правильно заповнені", null, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            OnCompletion(ActionType.Add);
            Close();
        }

        private void DriverSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            var target = input_DriverSelection.SelectedItem as DriverDTO;
            if (target == null) return;
            Input_FirstName.Text = target.FullName.Split(',')[0];
            Input_MiddleName.Text = target.FullName.Split(',')[1];
            Input_LastName.Text = target.FullName.Split(',')[2];
            
            var activeCategoryIndex = DriverConfiguration.Categories.FindIndex(c => c == target.Category);
            var activeRatingIndex = DriverConfiguration.Ratings.FindIndex(r => int.Parse(r) == target.Rating);
            
            Input_Category.SelectedItem = Input_Category.Items[activeCategoryIndex];
            Input_Rating.SelectedItem = Input_Rating.Items[activeRatingIndex];
        }
        
        public delegate void DriverInputCompleted(DriverValidation prop1, DriverDTO dto = null, DriverDTO prop2 = null, ActionType? tag = null);
        public event DriverInputCompleted DriverInputCompletionEvent;
        public void OnCompletion(ActionType? tag = null)
        {
            DriverInputCompletionEvent?.Invoke(localDriverVal, null, null, tag);
        }
    }
}