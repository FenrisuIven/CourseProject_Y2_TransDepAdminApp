using System.Runtime.CompilerServices;

namespace TransDep_AdminApp.Interfaces
{
    public delegate void TransferDTOToModel<TSender, TDTO>(TSender sender, TDTO dto, string tag = null);
    public interface ILayerTransfer<TSender, TDTO>
    {
        public event TransferDTOToModel<TSender,TDTO> TransferDTO;
        public void RequestTransfer(TDTO dto, string tag);
    }
}