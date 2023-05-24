namespace Ex03.GarageLogic
{
    internal class Truck : FuelVehicle
    {
        private bool m_hasHazardousMaterials;
        private float m_cargoVolume;

        public Truck() : base(14, 34.0f, eFuelType.Soler, 120.0f) 
        {
        }

        public bool HasHazardousMaterials
        {
            get { return m_hasHazardousMaterials; }
            set { m_hasHazardousMaterials = value; }
        }

        public float CargoVolume
        {
            get { return m_cargoVolume; }
            set { m_cargoVolume = value; }
        }
    }
}
