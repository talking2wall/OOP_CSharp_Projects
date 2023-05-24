namespace Ex03.GarageLogic
{
    public class Tire
    {
        private readonly float r_maxAirPressure;
        private string m_manufacturer;
        private float m_currentAirPressure;

        public Tire(float i_maxAir)
        {
            r_maxAirPressure = i_maxAir;
        }

        public string Manufacturer
        {
            get { return m_manufacturer; }
            set { m_manufacturer = value; }
        }

        public float AirPressure
        {
            get { return m_currentAirPressure; }
            set 
            { 
                if(value > MaxAirPresure)
                {
                    throw new ValueOutOfRangeException(0, MaxAirPresure);
                }

                m_currentAirPressure = value; 
            }
        }

        public float MaxAirPresure
        {
            get { return r_maxAirPressure; }
        }

        public void Inflate(float i_airPressureToAdd)
        {
            m_currentAirPressure += i_airPressureToAdd;
        }
    }
}