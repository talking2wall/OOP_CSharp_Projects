namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private eLicenseType m_licenseType;
        private int m_engineCapacity;

        public ElectricMotorcycle() : base(2, 28.0f, 1.6f) 
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
