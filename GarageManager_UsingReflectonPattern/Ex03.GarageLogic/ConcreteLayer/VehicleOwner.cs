namespace Ex03.GarageLogic
{
    public enum eVehicleState
    {
        InRepair,
        Repaired,
        Paid
    }

    public class VehicleOwner
    {
        private readonly string r_ownerName;
        private readonly string r_ownerPhoneNumber;
        private eVehicleState m_vehicleState = eVehicleState.InRepair;

        public VehicleOwner(string i_ownerName, string i_ownerPhoneNumber)
        {
            r_ownerName = i_ownerName;
            r_ownerPhoneNumber = i_ownerPhoneNumber;
        }

        public string OwnerName
        {
            get { return r_ownerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return r_ownerPhoneNumber; }
        }

        public eVehicleState VehicleState
        {
            get { return m_vehicleState; }
            set { m_vehicleState = value; }
        }
    }
}
