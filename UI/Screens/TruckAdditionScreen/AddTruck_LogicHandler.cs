using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TransDep_AdminApp.Interfaces;
using TransDep_AdminApp.Model.View;
using TransDep_AdminApp.Trucks;


namespace TransDep_AdminApp.UI.Screens
{
    public partial class AddNewTruck : IDataGatherer<Truck>
    {
        public void testButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine("Got: Create New Truck");
            var obj = GatherData();
            if (obj != null)
            {
                _parentUiController.parentWindow.mainController.AddTruck(obj);
                _parentUiController.Refresh();
                Close();
            }
            
        }
        
        public Truck GatherData()
        {
            string chosenType_string;
            try
            {
                chosenType_string = input_TruckType.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Перед тим як продовжити, будь ласка -- оберіть тип вантажівки!");
                return default;
            }

            try
            {
                string name = GetName(chosenType_string);
                if (string.IsNullOrEmpty(input_CarryingCapacity_r.Text)
                    || string.IsNullOrEmpty(input_UsefulVolume_r.Text)
                    || string.IsNullOrEmpty(input_Capacity_r.Text))
                    throw new NullReferenceException();
                
                switch (chosenType_string)
                {
                    case "Tent":
                        return new Tent(name,
                            int.Parse(input_CarryingCapacity_r.Text),
                            int.Parse(input_UsefulVolume_r.Text),
                            int.Parse(input_Capacity_r.Text));

                    case "Рефрижератор":
                        return new Refrigerated(name,
                            int.Parse(input_CarryingCapacity_r.Text),
                            int.Parse(input_UsefulVolume_r.Text),
                            int.Parse(input_Capacity_r.Text));

                    case "AutoClutch":
                        return new AutomaticClutch(name,
                            int.Parse(input_CarryingCapacity_r.Text),
                            int.Parse(input_UsefulVolume_r.Text),
                            int.Parse(input_Capacity_r.Text));

                    case "Контейнеровіз":
                        return new Container(name,
                            int.Parse(input_CarryingCapacity_r.Text),
                            int.Parse(input_UsefulVolume_r.Text),
                            int.Parse(input_Capacity_r.Text));
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Make sure to fill out all of the fields.");
                HighlightFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Some fields are in the wrong input format.");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Some characteristics are outside of the allowed range.");
            }

            return default;
        }

        public void HighlightFields()
        {
            foreach (var child in FirstRowGrid.Children)
            {
                if (!(child is TextBox)) continue;
                if (!string.IsNullOrWhiteSpace(((TextBox)child).Name)) continue;

            }
        }
        
        private string GetName(string type)
        {
            string res = "";
            if (!String.IsNullOrWhiteSpace(input_TruckName_l.Text)) res += input_TruckName_l.Text;
            else res += type;
            if (!String.IsNullOrWhiteSpace(input_TruckBrand_l.Text)) res += ", " + input_TruckBrand_l.Text;
            if (!String.IsNullOrWhiteSpace(input_TruckModel_l.Text)) res += " " + input_TruckModel_l.Text;
            if (res == "") return type;
            return res;
        }

        private void TruckType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (input_TruckType.SelectedItem.ToString())
            {
                case "AutoClutch":
                    TruckChars_UserControl.DataContext = new AutoClutchValidation();
                    return;
            }
        }
    }
}