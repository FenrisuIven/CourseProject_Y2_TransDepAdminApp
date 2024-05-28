using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Interfaces;
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
            TransferDTO += MainController.Instance.TruckActionRequested;
            
        }
        
        public void OnActionRequested(TruckValidation val = null, TruckDTO dto = null, TruckDTO replaceWith = null, ActionType? tag = null)
        {
            if (tag is ActionType.Replace && dto != null && replaceWith != null) RequestTransfer(dto, replaceWith, tag);
            if (tag is ActionType.Remove && dto != null) RequestTransfer(dto, null, tag);
            if (tag is ActionType.Add && val != null)
            {
                try
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
                    RequestTransfer(obj, null, tag);
                }
                catch { /*ignore*/ }
            }
        }

        public List<TruckDTO> GetFreeTrucksList() => TruckList.Where(elem => elem.Availability).ToList();
        
        public event TransferDTOToModel<TruckListVM, TruckDTO> TransferDTO;
        public void RequestTransfer(TruckDTO dto, TruckDTO replaceWith = null, ActionType? tag = null)
        {
            TransferDTO?.Invoke(this, dto, replaceWith, tag);
        }
    }
}