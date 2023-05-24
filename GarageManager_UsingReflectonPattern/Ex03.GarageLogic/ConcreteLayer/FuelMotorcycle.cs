namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        private eLicenseType m_licenseType;
        private int m_engineCapacity;

        public FuelMotorcycle() : base(2, 28.0f, eFuelType.Octan98, 6.0f) 
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_licenseType; }
            set { m_licenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_engineCapacity; }
            set { m_engineCapacity = value; }
        }
    }
}
