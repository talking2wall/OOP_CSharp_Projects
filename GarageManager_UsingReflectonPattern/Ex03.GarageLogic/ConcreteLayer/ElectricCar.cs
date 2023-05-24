namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        private eColor m_color;
        private eNumberOfDoors m_numOfDoors;

        public ElectricCar() : base(5, 32.0f, 4.7f) 
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
