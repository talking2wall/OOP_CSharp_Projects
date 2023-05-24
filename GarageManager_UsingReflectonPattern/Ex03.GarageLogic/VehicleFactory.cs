using System;

namespace Ex03.GarageLogic
{
    public enum eVehicle
    {
        ElectricCar,
        FuelCar,
        ElectricMotorcycle,
        FuelMotorcycle,
        Truck
    }

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(eVehicle i_vehicle)
        {
            Vehicle vehicle;
            switch(i_vehicle)
            {
                case eVehicle.ElectricCar:
                    vehicle = new ElectricCar();
                    break;
                case eVehicle.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle();
                    break;
                case eVehicle.FuelCar:
                    vehicle = new FuelCar();
                    break;
                case eVehicle.FuelMotorcycle:
                    vehicle = new FuelMotorcycle();
                    break;
                case eVehicle.Truck:
                    vehicle = new Truck();
                    break;
                default:
                    throw new ValueOutOfRangeException(0, Enum.GetValues(typeof(eVehicle)).Length - 1);
            }

            return vehicle;
        }
    }
}
