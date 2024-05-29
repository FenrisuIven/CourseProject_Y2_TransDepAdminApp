using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TransDep_AdminApp.Model;
using TransDep_AdminApp.Enums;
using TransDep_AdminApp.Interfaces;
using TransDep_AdminApp.ViewModel.DTO;
using TransDep_AdminApp.ViewModel.Validation;

namespace TransDep_AdminApp.ViewModel
{
    public class DriverListVM : ILayerTransfer<DriverListVM, DriverDTO>
    {
        public ObservableCollection<DriverDTO> DriverList;

        public DriverListVM()
        {
            DriverList = new ObservableCollection<DriverDTO>(
                ObjectMapper.AutoMapper.Map<List<Driver>, List<DriverDTO>>(
                    MainController.Instance.driverList.ToList()));
            TransferDTO += MainController.Instance.DriverActionRequested;
        }
        
        public void OnActionRequested(DriverValidation val = null, DriverDTO dto = null, DriverDTO replaceWith = null, ActionType? tag = null)
        {
            if (tag is ActionType.Replace && dto != null && replaceWith != null) RequestTransfer(dto, replaceWith, tag);
            if (tag is ActionType.Remove && dto != null) RequestTransfer(dto, null, tag);
            if (tag is ActionType.Add && val != null)
            {
                if (val.DriverDto != null) return;
                try
                {
                    var obj = new DriverDTO 
                    {
                        Id = null,
                        FullName = val.FirstName + "," + val.MiddleName + "," + val.LastName,
                        AssignedTruckID = null,
                        Rating = int.Parse(val.Rating),
                        Category = val.Category
                    };
                    RequestTransfer(obj, null, tag);
                }
                catch { /*ignored*/ }
            }
        }

        public List<DriverDTO> GetFreeDriversList()
        {
            return DriverList.Where(elem => elem.AssignedTruckID == null).ToList();
        }

        public event TransferDTOToModel<DriverListVM, DriverDTO> TransferDTO;
        public void RequestTransfer(DriverDTO dto, DriverDTO replaceWith = null, ActionType? tag = null)
        {
            TransferDTO?.Invoke(this, dto, replaceWith, tag);
        }
    }
}