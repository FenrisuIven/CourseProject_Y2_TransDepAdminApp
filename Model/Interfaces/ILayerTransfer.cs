using TransDep_AdminApp.Enums;

namespace TransDep_AdminApp.Interfaces
{
    public delegate void TransferDTOToModel<TSender, TDTO>(TSender sender, TDTO dto, TDTO replaceWith, ActionType? tag = null);
    public interface ILayerTransfer<TSender, TDTO>
    {
        public event TransferDTOToModel<TSender,TDTO> TransferDTO;
        public void RequestTransfer(TDTO dto, TDTO? replaceWith, ActionType? tag);
    }
}