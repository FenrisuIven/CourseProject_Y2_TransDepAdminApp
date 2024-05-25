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
    public class TaskListVM : ILayerTransfer<TaskListVM, TaskDTO>
    {
        public ObservableCollection<TruckDTO> TaskList;

        public TaskListVM()
        {
            TaskList = new ObservableCollection<TruckDTO>(
                ObjectMapper.AutoMapper.Map<List<Truck>, List<TruckDTO>>(
                    MainController.Instance.truckList.ToList()));
            TransferDTO += MainController.Instance.TaskAdditionRequested;
        }
        
        public void OnAdditionRequested(object sender, TruckValidation val)
        {
            var obj = new TaskDTO 
            {
                
            };
            //if (everything is okay)
            RequestTransfer(obj);
        }
        
        public event TransferDTOToModel<TaskListVM, TaskDTO> TransferDTO;
        public void RequestTransfer(TaskDTO dto, [CallerMemberName] string senderName = null)
        {
            TransferDTO?.Invoke(this, dto);
        }
    }
}