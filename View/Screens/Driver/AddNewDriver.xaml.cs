using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
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
            
            DriverInputCompletionEvent += localDriverVM.OnAdditionRequested;
        }
        public void SaveAndQuit(object sender, EventArgs e)
        {
            if (!localDriverVal.isValid())
            {
                MessageBox.Show("Перевірте чи усі поля водія були правильно заповнені", null, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            OnCompletion();
            Close();
        }
        public delegate void DriverInputCompleted(object sender, DriverValidation prop1);
        public event DriverInputCompleted DriverInputCompletionEvent;
        public void OnCompletion([CallerMemberName] string memberName = null)
        {
            DriverInputCompletionEvent?.Invoke(this, localDriverVal);
        }

        private void DriverSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            var target = input_DriverSelection.SelectedItem as DriverDTO;
            if (target == null) return;
            Input_FirstName.Text = target.FullName.Split(',')[0];
            Input_MiddleName.Text = target.FullName.Split(',')[1];
            Input_LastName.Text = target.FullName.Split(',')[2];
            
            // - Target: when user selects DriverDTO from the list (ComboBox < input_DriverSelection >) ----------------
            //           update the fields to contain the chars of that DTO so that user can edit them
            //           TextBox-es works correctly, but ComboBox-es don't want to search for item based
            //           on the inputted string. This is expected to work:
            //           Input_Category.SelectedItem = target.Category
            //           But it doesn't because Input_Category.Items contain only ComboBoxItem's
            //           Same problem applies to Input_Rating, since it is also a ComboBox
            var test = Input_Category.Items.Cast<ComboBoxItem>(); // IEnumerable<T>
            Console.WriteLine((int)target.Category[0]); //for C outputs 67
            Console.WriteLine((int)((string)((ComboBoxItem)Input_Category.Items[2]).Content)[0]); //for C outputs 67
            Input_Category.SelectedItem = test.First(elem => elem.Content.Equals(target.Category)); //returns null
            
            Input_Rating.SelectedItem = target.Rating.ToString();
            // ---------------------------------------------------------------------------------------------------------
            
            input_DriverSelection.DataContext = localDriverVM;
            DriverData_UserCtrl.DataContext = localDriverVal;
        }
    }
}