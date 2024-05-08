using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TransDep_AdminApp.Trucks;


namespace TransDep_AdminApp.UI.Screens
{
    public partial class AddNewTruck
    {
        public void testButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine("Got: Create New Truck");
            GatherData();
        }
        
        private void GatherData()
        {
            List<string> msg = new List<string>();
            string chosenType_string;
            try
            {
                chosenType_string = ((ComboBoxItem)input_TruckType.SelectedItem).Content.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Перед тим як продовжити, будь ласка -- оберіть тип вантажівки!");
                return;
            }

            try
            {
                string name= GetName(chosenType_string);
                switch (chosenType_string)
                {
                    case "Тентова":
                        Tent truck_Tent = new Tent(name, 
                            int.Parse(input_CarryingCapacity.Text),
                            int.Parse(input_UsefulVolume.Text),
                            int.Parse(input_Capacity.Text));
                        Console.WriteLine(truck_Tent);
                        break;
                    
                    case "Рефрижератор":
                        Refrigerated truck_Refr = new Refrigerated(name, 
                            int.Parse(input_CarryingCapacity.Text),
                            int.Parse(input_UsefulVolume.Text),
                            int.Parse(input_Capacity.Text));
                        Console.WriteLine(truck_Refr);
                        break;
                    
                    case "Автозцепка":
                        Refrigerated truck_Auto = new Refrigerated(name, 
                            int.Parse(input_CarryingCapacity.Text),
                            int.Parse(input_UsefulVolume.Text),
                            int.Parse(input_Capacity.Text));
                        Console.WriteLine(truck_Auto);
                        break;
                    
                    case "Контейнеровіз":
                        Refrigerated truck_Cont = new Refrigerated(name, 
                            int.Parse(input_CarryingCapacity.Text),
                            int.Parse(input_UsefulVolume.Text),
                            int.Parse(input_Capacity.Text));
                        Console.WriteLine(truck_Cont);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Make sure to fill out all of the fields.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Some fields are in the wrong input format.");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Some characteristics are outside of the allowed range.");
            }
        }
        private string GetName(string type)
        {
            string res = "";
            if (!String.IsNullOrWhiteSpace(input_TruckName.Text)) res += input_TruckName.Text;
            if (!String.IsNullOrWhiteSpace(input_TruckBrand.Text)) res += ", " + input_TruckBrand.Text;
            if (!String.IsNullOrWhiteSpace(input_TruckModel.Text)) res += " "+input_TruckModel.Text;
            if (res == "") return type;
            return res;
        }


        private void TruckType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}