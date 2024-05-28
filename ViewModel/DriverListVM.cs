using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TransDep_AdminApp.Model;
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
        
        public void OnActionRequested(object sender, DriverValidation val = null, DriverDTO dto = null, string tag = null)
        {
            if (tag == "replace" && dto != null) RequestTransfer(dto, tag);
            if (tag == "add" && val != null)
            {
                var obj = new DriverDTO 
                {
                    Id = null,
                    FullName = val.FirstName + "," + val.MiddleName + "," + val.LastName,
                    AssignedTruckID = null,
                    Rating = int.Parse(val.Rating.Remove(0,38)),
                    Category = val.Category.Remove(0,38)
                };
                //if (everything is okay)
                RequestTransfer(obj, tag);
            }
        }

        public List<DriverDTO> GetFreeDriversList()
        {
            return DriverList.Where(elem => elem.AssignedTruckID == null).ToList();
        }

        public event TransferDTOToModel<DriverListVM, DriverDTO> TransferDTO;
        public void RequestTransfer(DriverDTO dto, [CallerMemberName] string senderName = null)
        {
            TransferDTO?.Invoke(this, dto);
        }
    }
}