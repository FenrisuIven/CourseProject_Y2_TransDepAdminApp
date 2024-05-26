using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Interfaces;
using TransDep_AdminApp.Model.Parking;
using TransDep_AdminApp.ViewModel.DTO;
using TransDep_AdminApp.ViewModel.Validation;

namespace TransDep_AdminApp.ViewModel
{
    public class TruckListVM : ILayerTransfer<TruckListVM, TruckDTO>
    {
        public ObservableCollection<TruckDTO> TruckList;

        public TruckListVM()
        {
            TruckList = new ObservableCollection<TruckDTO>(
                ObjectMapper.AutoMapper.Map<List<Truck>, List<TruckDTO>>(
                    MainController.Instance.truckList.ToList()));
            TransferDTO += MainController.Instance.TruckAdditionRequested;
            MainController.Instance.TruckPropChanged += TruckPropChanged;
        }
        
        public void OnAdditionRequested(object sender, TruckValidation val)
        {
            var obj = new TruckDTO 
            {
                Type = val.Type!.Value,
                Id = null,
                DriverID = null,
                Name = val.Name ?? val.Model + " " + val.Brand, 
                CarryingCapacity = val.TruckCharsValidation.CarryingCapacity!.Value,
                UsefulVolume = val.TruckCharsValidation.UsefulVolume!.Value,
                Capacity = val.TruckCharsValidation.Capacity!.Value,
                Availability = true,
                ParkingSpot = -1
            };
            //if (everything is okay)
            RequestTransfer(obj);
        }

        public void TruckPropChanged(string truckId, string propName)
        {
            switch (propName)
            {
                case "Availability":
                    if (MainController.Instance.truckList.ToList().Find(elem => elem.Id == truckId).Availability)
                    {
                        ParkingLot_Ui.AnimateTruckArrival(truckId);
                    }
                    else
                    {
                        ParkingLot_Ui.AnimateTruckDeparture(truckId);
                    }
                    break;
            }
        }
        
        public event TransferDTOToModel<TruckListVM, TruckDTO> TransferDTO;
        public void RequestTransfer(TruckDTO dto, [CallerMemberName] string senderName = null)
        {
            TransferDTO?.Invoke(this, dto);
        }


        /*public void CreateDriver()
        {
            if (input_DriverSelection.SelectedIndex != -1)
            {
                var target = input_DriverSelection.SelectedItem as DriverDTO;
                driver.Item2 = target.Id;
                return;
            }

            var fullName = input_DriverFirstName.Text + "," + input_DriverSurName.Text + "," + input_DriverLastName.Text;
            var rating = int.Parse(((ComboBoxItem)input_DriverRating.SelectedValue).Content as string);
            var category = ((ComboBoxItem)input_DriverCategory.SelectedValue).Content as string;

            driver.Item1 = new Driver(IDGenerator.GenerateRandom(), fullName, rating, category);
        }*/
    }
}