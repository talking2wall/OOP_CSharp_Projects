namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        private eColor m_color;
        private eNumberOfDoors m_numOfDoors;

        public FuelCar() : base(5, 32.0f, eFuelType.Octan95, 50.0f) 
        {
        }

        public eColor Color
        {
            get { return m_color; }
            set { m_color = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_numOfDoors; }
            set { m_numOfDoors = value; }
        }
    }
}
