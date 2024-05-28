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
        
        public void OnActionRequested(object sender, DriverValidation val = null, DriverDTO dto = null, ActionType? tag = null)
        {
            if (tag is ActionType.Replace && dto != null) RequestTransfer(dto, tag);
            if (tag is ActionType.Add && val != null)
            {
                
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
                    RequestTransfer(obj, tag);
                }
                catch { /*ignored*/ }
            }
        }

        public List<DriverDTO> GetFreeDriversList()
        {
            return DriverList.Where(elem => elem.AssignedTruckID == null).ToList();
        }

        public event TransferDTOToModel<DriverListVM, DriverDTO> TransferDTO;
        public void RequestTransfer(DriverDTO dto, ActionType? tag = null)
        {
            TransferDTO?.Invoke(this, dto);
        }
    }
}