using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private VehicleFactory m_vehicleFactory = new VehicleFactory();
        private Dictionary<VehicleOwner, Vehicle> m_vehiclesInGarage = new Dictionary<VehicleOwner, Vehicle>();

        public bool CheckIfInGarage(string i_licenseNumber, bool changeVehicleState = true)
        {
            bool inGarage = false;
            if (m_vehiclesInGarage != null)
            {
                foreach (KeyValuePair<VehicleOwner, Vehicle> pair in m_vehiclesInGarage)
                {
                    if (pair.Value.LicenseNumber == i_licenseNumber)
                    {
                        if (changeVehicleState == true)
                        {
                            pair.Key.VehicleState = eVehicleState.InRepair;
                        }

                        inGarage = true;
                        break;
                    }
                }
            }

            return inGarage;
        }

        public void AddToGarage(VehicleOwner i_vehicleOwner, Vehicle i_vehicle)
        {
            m_vehiclesInGarage.Add(i_vehicleOwner, i_vehicle);
        }
        
        public List<string> GetLicenseNumbers()
        {
            List<string> licenseNumbers = new List<string>();
            foreach (KeyValuePair<VehicleOwner, Vehicle> pair in m_vehiclesInGarage)
            {
                licenseNumbers.Add(pair.Value.LicenseNumber);
            }

            return licenseNumbers;
        }

        public List<string> SortVehiclesBySate(eVehicleState i_VehicleState)
        {
            List<string> sortedVehicles = new List<string>();
            foreach (KeyValuePair<VehicleOwner, Vehicle> pair in m_vehiclesInGarage)
            {
                if (pair.Key.VehicleState == i_VehicleState)
                {
                    sortedVehicles.Add(pair.Value.LicenseNumber);
                }
            }

            return sortedVehicles;
        }

        public void ChangeVehicleState(string i_licenseNumber, eVehicleState i_vehicleState)
        {
            foreach (KeyValuePair<VehicleOwner, Vehicle> pair in m_vehiclesInGarage)
            {
                if (pair.Value.LicenseNumber == i_licenseNumber)
                {
                    pair.Key.VehicleState = i_vehicleState;
                    break;
                }
            }
        }

        public void InflateTiresToMax(string i_licenseNumber)
        {
            foreach (KeyValuePair<VehicleOwner, Vehicle> pair in m_vehiclesInGarage)
            {
                if (pair.Value.LicenseNumber == i_licenseNumber)
                {
                    foreach (Tire vehicleTire in pair.Value.Tires)
                    {
                        vehicleTire.Inflate(vehicleTire.MaxAirPresure - vehicleTire.AirPressure);
                    }

                    break;
                }
            }
        }

        public void RefuelVehicle(string i_licenseNumber, eFuelType i_fuelType, float i_amountOfLitersToAdd)
        {
            foreach (KeyValuePair<VehicleOwner, Vehicle> pair in m_vehiclesInGarage)
            {
                if (pair.Value.LicenseNumber == i_licenseNumber)
                {
                    if (pair.Value is FuelVehicle)
                    {
                        (pair.Value as FuelVehicle).Refuel(i_amountOfLitersToAdd, i_fuelType);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("Electric vehicle can not be refueled.");
                    }
                }
            }
        }

        public void ChargeVehicle(string i_licenseNumber, float i_amountOfMinutesToAdd)
        {
            foreach (KeyValuePair<VehicleOwner, Vehicle> pair in m_vehiclesInGarage)
            {
                if (pair.Value.LicenseNumber == i_licenseNumber)
                {
                    if (pair.Value is ElectricVehicle)
                    {
                        (pair.Value as ElectricVehicle).Charge(i_amountOfMinutesToAdd / 60);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("Fuel vehicle can not be charged.");
                    }
                }
            }
        }

        public KeyValuePair<VehicleOwner, Vehicle> GetVehicleDetailsByLicenseNumber(string i_licenseNumber)
        {
            KeyValuePair<VehicleOwner, Vehicle> vehicleDetailsPair = new KeyValuePair<VehicleOwner, Vehicle>();
            foreach (KeyValuePair<VehicleOwner, Vehicle> pair in m_vehiclesInGarage)
            {
                if (pair.Value.LicenseNumber == i_licenseNumber)
                {
                    vehicleDetailsPair = pair;
                }
            }

            return vehicleDetailsPair;
        }
    }
}
