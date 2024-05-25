using System.Runtime.CompilerServices;

namespace TransDep_AdminApp.Interfaces
{
    public delegate void TransferDTOToModel<TSender, TDTO>(TSender sender, TDTO dto);
    public interface ILayerTransfer<TSender, TDTO>
    {
        public event TransferDTOToModel<TSender,TDTO> TransferDTO;
        public void RequestTransfer(TDTO dto, [CallerMemberName] string senderName = null);
    }
}