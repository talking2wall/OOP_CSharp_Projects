using System;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Octan98,
        Octan96,
        Octan95,
        Soler
    }

    internal abstract class FuelVehicle : Vehicle
    {
        private readonly eFuelType r_fuelType;
        private readonly float r_maxFuelLevel;
        private float m_currentFuelLevel;

        public FuelVehicle(int i_tires, float i_maxAirPressure, eFuelType i_fuelType, float i_maxFuelLevel) : base(i_tires, i_maxAirPressure)
        {
            r_fuelType = i_fuelType;
            r_maxFuelLevel = i_maxFuelLevel;
        }

        public float CurrentFuelLevel
        {
            get { return m_currentFuelLevel; }
            set
            {
                if (value > MaxFuelLevel)
                {
                    throw new ValueOutOfRangeException(0, MaxFuelLevel);
                }

                m_currentFuelLevel = value;
                SetEnergyPersentageLeft((CurrentFuelLevel / MaxFuelLevel) * 100);
            }
        }

        public float MaxFuelLevel
        {
            get { return r_maxFuelLevel; }
        }

        public eFuelType FuelType
        {
            get { return r_fuelType; }
        }

        public void Refuel(float i_fuelLitersToAdd, eFuelType i_fuelType)
        {
            if (i_fuelType != FuelType)
            {
                throw new ArgumentException(string.Format("An error has occured, The expected fuel type is {0} but recieved {1}.", FuelType, i_fuelType));
            }

            CurrentFuelLevel += i_fuelLitersToAdd;
        }
    }
}
