using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Media;
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
            SetTruckList();
            TransferDTO += MainController.Instance.TruckActionRequested;
            
            MainController.Instance.FinishedChanges += (tag) =>
            {
                SetTruckList();
                CollectionChanged?.Invoke();
            };
        }

        private void SetTruckList()
        {
            TruckList = new ObservableCollection<TruckDTO>(
                ObjectMapper.AutoMapper.Map<List<Truck>, List<TruckDTO>>(
                    MainController.Instance.truckList.ToList()));
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
                        DriverID = val.DesiredDriverID,
                        AssignedColor = Colors.Red,
                        Name = val.Name ?? val.Brand + " " + val.Model, 
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
        
        public delegate void OnCollectionChanged();
        public event OnCollectionChanged CollectionChanged;

        
        public event TransferDTOToModel<TruckListVM, TruckDTO> TransferDTO;
        public void RequestTransfer(TruckDTO dto, TruckDTO replaceWith = null, ActionType? tag = null)
        {
            TransferDTO?.Invoke(this, dto, replaceWith, tag);
        }
    }
}