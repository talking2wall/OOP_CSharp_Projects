namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly Tire[] r_tires;
        private string m_modelName;
        private string m_licenseNumber;
        private float m_energyPercentageLeft;

        public Vehicle(int i_tires, float i_maxAirPressure)
        {
            r_tires = new Tire[i_tires];
            for (int i = 0; i < Tires.Length; i++)
            {
                Tires[i] = new Tire(i_maxAirPressure);
            }
        }

        public string LicenseNumber
        {
            get { return m_licenseNumber; }
            set { m_licenseNumber = value; }
        }

        public string ModelName
        {
            get { return m_modelName; }
            set { m_modelName = value; }
        }

        public float EnergyPercentageLeft
        {
            get { return m_energyPercentageLeft; }
        }
        
        public void SetEnergyPersentageLeft(float i_energyPersentageLeft)
        {
            m_energyPercentageLeft = i_energyPersentageLeft;
        }

        public Tire[] Tires
        {
            get { return r_tires; }
        }

        public void SetTireManufacturer(int i_tireIndex, string i_manufacturer)
        {
            Tires[i_tireIndex].Manufacturer = i_manufacturer;
        }

        public void SetTireAirPressure(int i_tireIndex, float i_airPressure)
        {
            Tires[i_tireIndex].AirPressure = i_airPressure;
        }

        public void SetAllTiresAirPressure(float i_airPressure)
        {
            for (int i = 0; i < Tires.Length; i++)
            {
                SetTireAirPressure(i, i_airPressure);
            }
        }

        public void SetAllTiresManufacturer(string i_manufacturer)
        {
            for (int i = 0; i < this.Tires.Length; i++)
            {
                SetTireManufacturer(i, i_manufacturer);
            }
        }
    }
}
