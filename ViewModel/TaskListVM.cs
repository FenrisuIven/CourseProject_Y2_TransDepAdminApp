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
    public class TaskListVM : ILayerTransfer<TaskListVM, TaskDTO>
    {
        public ObservableCollection<TruckDTO> TaskList;

        public TaskListVM()
        {
            TaskList = new ObservableCollection<TruckDTO>(
                ObjectMapper.AutoMapper.Map<List<Truck>, List<TruckDTO>>(
                    MainController.Instance.truckList.ToList()));
            TransferDTO += MainController.Instance.TaskActionRequested;
        }
        
        public void OnActionRequested(object sender, TaskValidation val = null, TaskDTO dto = null, ActionType? tag = null)
        { 
            if (tag is ActionType.Add && val != null)
            {
                try
                {
                    var obj = new TaskDTO
                    {
                        Name = val.Name,
                        TruckExecutorID = val.Truck.Id,
                        DriverExecutorID = val.Driver.Id,
                        Route = new RouteDTO()
                        {
                            Origin = val.RouteVal.StartPoint,
                            Destination = val.RouteVal.EndPoint
                        },
                        Cargo = new CargoDTO()
                        {
                            Weight = double.Parse(val.CargoVal.Weight),
                            Volume = double.Parse(val.CargoVal.Volume),
                            Amount = double.Parse(val.CargoVal.Amount),
                        }
                    };
                    RequestTransfer(obj);
                }
                catch(Exception e)
                { /*ignored*/ }
            }
            
        }
        
        public event TransferDTOToModel<TaskListVM, TaskDTO> TransferDTO;
        public void RequestTransfer(TaskDTO dto, TaskDTO replaceWith = null,ActionType? tag = null)
        {
            TransferDTO?.Invoke(this, dto, null);
        }
    }
}