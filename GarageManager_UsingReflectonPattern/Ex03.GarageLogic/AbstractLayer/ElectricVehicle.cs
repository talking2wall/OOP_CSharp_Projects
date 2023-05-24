namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        private readonly float r_maxBatteryTime;
        private float m_batteryTimeLeft;

        public ElectricVehicle(int i_tires, float i_maxAirPressure, float i_maxBatteryTime) : base(i_tires, i_maxAirPressure) 
        {
            r_maxBatteryTime = i_maxBatteryTime;
        }

        public float BatteryHoursLeft
        {
            get { return m_batteryTimeLeft; }
            set
            {
                if (value > MaxBatteryHours)
                {
                    throw new ValueOutOfRangeException(0, MaxBatteryHours);
                }

                m_batteryTimeLeft = value;
                SetEnergyPersentageLeft((m_batteryTimeLeft / MaxBatteryHours) * 100);
            }
        }

        public float MaxBatteryHours
        {
            get { return r_maxBatteryTime; }
        }

        public void Charge(float i_numOfHoursToAdd)
        {
            BatteryHoursLeft += i_numOfHoursToAdd;
        }
    }
}
