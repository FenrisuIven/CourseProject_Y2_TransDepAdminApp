using System.Linq;
using System.Windows.Markup;
using System.Windows.Media;

namespace TransDep_AdminApp.Model.Parking
{
    public class ParkedTruck
    {
        public string TruckId { get; set; }
        public string Name { get; set; }
        public string DriverName { get; set; }
        public Color AssignedColor { get; set; }
        
        public int Spot { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        
        public ParkedTruck(){}
        public ParkedTruck(int spotNum, string truckId)
        {
            TruckId = truckId;
            Spot = spotNum;

            var truck = MainController.Instance.truckList.ToList().Find(elem => elem.Id == truckId);
            Name = truck.Name == null ? "Undefined" : truck.Name;
            AssignedColor = truck.AssignedColor;
            if (truck.DriverID == null)
            {
                DriverName = "Undefined";
                return;
            }
            var driver = MainController.Instance.driverList.ToList().Find(elem => elem.Id == truck.DriverID);
            DriverName = driver == null ? "Undefined" : driver.LastName + " " + driver.FirstName.ToCharArray()[0] + "." + driver.MiddleName.ToCharArray()[0] + ".";
        }

        public void SetRowColIdx(int amountOfSpots)
        {
            Row = (Spot - 1) / (amountOfSpots / 2);
            Col = (Spot - 1) % (amountOfSpots / 2);
        }
    }
}