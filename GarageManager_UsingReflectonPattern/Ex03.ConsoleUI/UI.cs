using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        private GarageLogic.Garage garage = new GarageLogic.Garage();
        private GarageLogic.VehicleFactory factory = new GarageLogic.VehicleFactory();

        public void RunMenu()
        {
            bool exitSystem = false;
            while(exitSystem == false)
            {
            Console.WriteLine("Garage Managment System Menu");
            Console.WriteLine("============================");
            Console.WriteLine("Please select an option (enter function number):");
            Console.WriteLine("1. Add vehicle to garage.");
            Console.WriteLine("2. Get license numbers (get all or sort by vehicle state).");
            Console.WriteLine("3. Change vehicle state.");
            Console.WriteLine("4. Inflate vehicle tires to maximum.");
            Console.WriteLine("5. Refuel a fuel driven vehicle.");
            Console.WriteLine("6. Charge an electric vehicle.");
            Console.WriteLine("7. Get all vehicle data by license number.");
            Console.WriteLine("8. Exit system.");
            int answer;
            bool validInput = int.TryParse(Console.ReadLine(), out answer);
            while(validInput == false || answer > 8 || answer < 1)
            {
                Console.Write("Invalid input, please try again: ");
                validInput = int.TryParse(Console.ReadLine(), out answer);
            }

            try
                {
                    switch (answer)
                    {
                        case 1:
                            addVehicleUI();
                            break;
                        case 2:
                            getLicenseNumbersUI();
                            break;
                        case 3:
                            changeVehicleStateUI();
                            break;
                        case 4:
                            inflateTiresToMaxUI();
                            break;
                        case 5:
                            refuelVehicleUI();
                            break;
                        case 6:
                            chargeVehicleUI();
                            break;
                        case 7:
                            printVehicleInfo();
                            break;
                        case 8:
                            exitSystem = true;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("An error occured while trying to set the value, the value is not matching the expected value type.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (GarageLogic.ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }

                if(exitSystem)
                {
                    Console.WriteLine("Press enter to exit...");
                }
                else
                {
                    Console.WriteLine("\nGetting back to menu...\n");
                }
            }
        }

        private void addVehicleUI()
        {
            GarageLogic.Vehicle vehicle;
            string licenseNumberInput;
            Console.Write("Please enter license number: ");
            licenseNumberInput = Console.ReadLine();
            if (garage.CheckIfInGarage(licenseNumberInput))
            {
                Console.WriteLine("The vehicle is already in the garage.");
            }
            else
            {
                string ownerName;
                string ownerPhoneNumber;
                Console.WriteLine("Please enter vehicle type:");
                printEnumValues(typeof(GarageLogic.eVehicle));
                vehicle = factory.CreateVehicle((GarageLogic.eVehicle)int.Parse(Console.ReadLine()));
                Type typeOfVehicle = vehicle.GetType();
                PropertyInfo[] allProperties = typeOfVehicle.GetProperties();
                foreach (PropertyInfo propertyInfo in allProperties)
                {
                    if (propertyInfo.CanWrite)
                    {
                        if (propertyInfo.Name == "LicenseNumber")
                        {
                            propertyInfo.SetValue(vehicle, licenseNumberInput, null);
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.IsEnum)
                            {
                                Console.WriteLine(string.Format("Please enter {0}: ", fixPropertyName(propertyInfo.Name)));
                                printEnumValues(propertyInfo.PropertyType);
                                int inputEnumVal;
                                inputEnumVal = int.Parse(Console.ReadLine());
                                if (!Enum.IsDefined(propertyInfo.PropertyType, inputEnumVal))
                                {
                                    throw new GarageLogic.ValueOutOfRangeException(0, Enum.GetValues(propertyInfo.PropertyType).Length - 1);
                                }

                                propertyInfo.SetValue(vehicle, Enum.ToObject(propertyInfo.PropertyType, inputEnumVal), null);
                            }
                            else
                            {
                                if (propertyInfo.PropertyType == typeof(bool))
                                {
                                    Console.Write(string.Format("Please enter if {0}: \nfor yes enter 'true', for no enter 'false': ", fixPropertyName(propertyInfo.Name)));
                                }
                                else
                                {
                                    Console.Write(string.Format("Please enter {0}: ", fixPropertyName(propertyInfo.Name)));
                                }

                                propertyInfo.SetValue(vehicle, Convert.ChangeType(Console.ReadLine(), propertyInfo.PropertyType), null);
                            }
                        }
                    }
                }

                Console.Write("Do you want to enter manufacturer name for all tires together?\nEnter '1' for yes, '0' for no: ");
                string answer = Console.ReadLine();
                while (answer.Length != 1 || (answer[0] != '0' && answer[0] != '1'))
                {
                    Console.WriteLine("Invalid input, please try again:");
                    answer = Console.ReadLine();
                }

                if (answer[0] == '0')
                {
                    for (int i = 0; i < vehicle.Tires.Length; i++)
                    {
                        Console.Write(string.Format("Please enter tire {0} manufacturer name: ", i + 1));
                        vehicle.SetTireManufacturer(0, Console.ReadLine());
                    }
                }
                else
                {
                    Console.Write("Enter all tires manufacturer name: ");
                    vehicle.SetAllTiresManufacturer(Console.ReadLine());
                }

                Console.Write("Do you want to enter air pressure for all tires together?\nEnter '1' for yes, '0' for no: ");
                answer = Console.ReadLine();
                while (answer.Length != 1 || (answer[0] != '0' && answer[0] != '1'))
                {
                    Console.WriteLine("Invalid input, please try again:");
                    answer = Console.ReadLine();
                }

                if (answer[0] == '0')
                {
                    for (int i = 0; i < vehicle.Tires.Length; i++)
                    {
                        Console.Write(string.Format("Please enter tire {0} current air pressure: ", i + 1));
                        vehicle.SetTireAirPressure(0, float.Parse(Console.ReadLine()));
                    }
                }
                else
                {
                    Console.Write("Enter all tires current air pressure: ");
                    vehicle.SetAllTiresAirPressure(float.Parse(Console.ReadLine()));
                }

                Console.Write("Please enter the owner's name: ");
                ownerName = Console.ReadLine();
                Console.Write("Please enter the owner's phone number: ");
                ownerPhoneNumber = Console.ReadLine();
                garage.AddToGarage(new GarageLogic.VehicleOwner(ownerName, ownerPhoneNumber), vehicle);
                Console.WriteLine("The vehicle was added to the garage.");
            }
        }

        private void getLicenseNumbersUI()
        {
            Console.Write("Do you want to select vehicle state to sort?\nPlease enter '1' for yes, '0' for no: ");
            string answer = Console.ReadLine();
            while (answer.Length != 1 || (answer[0] != '0' && answer[0] != '1'))
            {
                Console.Write("Invalid input, please try again: ");
                answer = Console.ReadLine();
            }

            if(answer[0] == '0')
            {
                List<string> licenseNumbers = garage.GetLicenseNumbers();
                if (licenseNumbers.Count == 0)
                {
                    Console.WriteLine("There are no vehicles in the garage.");
                }
                else
                {
                    Console.WriteLine("The license numbers are:");
                    foreach (string licenseNumber in licenseNumbers)
                    {
                        Console.WriteLine(licenseNumber);
                    }
                }
            }
            else
            {
                Console.WriteLine("License numbers of which vehicle state do you want to display?");
                printEnumValues(typeof(GarageLogic.eVehicleState));
                List<string> licenseNumbers = garage.SortVehiclesBySate((GarageLogic.eVehicleState)int.Parse(Console.ReadLine()));
                if(licenseNumbers.Count == 0)
                {
                    Console.WriteLine("There are no vehicles in the garage in that state.");
                }
                else
                {
                    Console.WriteLine("The license numbers are:");
                    foreach (string licenseNumber in licenseNumbers)
                    {
                        Console.WriteLine(licenseNumber);
                    }
                }
            }
        }

        private void changeVehicleStateUI()
        {
            Console.WriteLine("Please enter the vehicle's license number:");
            string inputLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the new vehicle state:");
            printEnumValues(typeof(GarageLogic.eVehicleState));
            int newVehicleState = int.Parse(Console.ReadLine());
            if(garage.CheckIfInGarage(inputLicenseNumber, false))
            {
                garage.ChangeVehicleState(inputLicenseNumber, (GarageLogic.eVehicleState)newVehicleState);
                Console.WriteLine("Vehicle's state changed.");
            }
            else
            {
                Console.WriteLine("There is no vehicle with such license number in the garage.");
            }
        }

        private void inflateTiresToMaxUI()
        {
            Console.WriteLine("Please enter the vehicle's license number:");
            string inputLicenseNumber = Console.ReadLine();
            if (garage.CheckIfInGarage(inputLicenseNumber, false))
            {
                garage.InflateTiresToMax(inputLicenseNumber);
                Console.WriteLine("Vehicle tires were inflated to max.");
            }
            else
            {
                Console.WriteLine("There is no vehicle with such license number in the garage.");
            }
        }

        private void refuelVehicleUI()
        {
            Console.WriteLine("Please enter the vehicle's license number:");
            string inputLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the vehicle's fuel type:");
            printEnumValues(typeof(GarageLogic.eFuelType));
            int inputFuelType = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the amount of liters to fuel:");
            float inputAmountOfLitersToAdd = float.Parse(Console.ReadLine());
            if (garage.CheckIfInGarage(inputLicenseNumber, false))
            {
                garage.RefuelVehicle(inputLicenseNumber, (GarageLogic.eFuelType)inputFuelType, inputAmountOfLitersToAdd);
                Console.WriteLine("Vehicle refuled.");
            }
            else
            {
                Console.WriteLine("There is no vehicle with such license number in the garage");
            }
        }

        private void chargeVehicleUI()
        {
            Console.WriteLine("Please enter the vehicle's license number:");
            string inputLicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the amount of minutes to charge:");
            float inputAmountOfMinutesToCharge = float.Parse(Console.ReadLine());
            if (garage.CheckIfInGarage(inputLicenseNumber, false))
            {
                garage.ChargeVehicle(inputLicenseNumber, inputAmountOfMinutesToCharge);
                Console.WriteLine("Vehicle Charged.");
            }
            else
            {
                Console.WriteLine("There is no vehicle with such license number in the garage");
            }
        }

        private void printVehicleInfo()
        {
            KeyValuePair<GarageLogic.VehicleOwner, GarageLogic.Vehicle> vehicleInfo;
            Console.WriteLine("Please enter the vehicle's license number:");
            string inputLicenseNumber = Console.ReadLine();
            if (garage.CheckIfInGarage(inputLicenseNumber, false))
            {
                vehicleInfo = garage.GetVehicleDetailsByLicenseNumber(inputLicenseNumber);
                Console.WriteLine("Vehicle's owner details:");
                Console.WriteLine("========================");
                Console.WriteLine(string.Format("Owner's name: {0}", vehicleInfo.Key.OwnerName));
                Console.WriteLine(string.Format("Owner's phone number: {0}", vehicleInfo.Key.OwnerPhoneNumber));
                Console.WriteLine(string.Format("Owner's vehicle state: {0}", vehicleInfo.Key.VehicleState));
                Console.WriteLine("Vehicle details:");
                Console.WriteLine("================");
                Type typeOfVehicle = vehicleInfo.Value.GetType();
                PropertyInfo[] allProperties = typeOfVehicle.GetProperties();
                MethodInfo[] allMethods = typeOfVehicle.GetMethods();
                foreach (PropertyInfo propertyInfo in allProperties)
                {
                    if (propertyInfo.Name != "Tires")
                    {
                        Console.WriteLine(string.Format("Vehicle's {0}: {1}", fixPropertyName(propertyInfo.Name), propertyInfo.GetValue(vehicleInfo.Value, null)));
                    }
                }

                Console.WriteLine("Tires details:");
                Console.WriteLine("==============");
                for (int i = 0; i < vehicleInfo.Value.Tires.Length; i++)
                {
                    Console.WriteLine(string.Format("Tire {0} details:", i + 1));
                    Console.WriteLine(string.Format("The tire manufacturer is: {0}", vehicleInfo.Value.Tires[i].Manufacturer));
                    Console.WriteLine(string.Format("The tire air pressure is: {0}", vehicleInfo.Value.Tires[i].AirPressure));
                }
            }
            else
            {
                Console.WriteLine("There is no vehicle with such license number in the garage.");
            }
        }

        private StringBuilder fixPropertyName(string i_propertyName)
        {
            StringBuilder fixedName = new StringBuilder();
            int i = 0;

            for(i = 0; i < i_propertyName.Length - 1; i++)
            {
                fixedName.Append(i_propertyName[i]);
                if (char.IsUpper(i_propertyName[i + 1]) && char.IsUpper(i_propertyName[i]) == false)
                {
                    fixedName.Append(' ');
                }
            }

            fixedName.Append(i_propertyName[i]);
            return fixedName;
        }

        private void printEnumValues(Type i_enum)
        {
            string[] enumOptions = i_enum.GetEnumNames();
            for(int i = 0; i < enumOptions.Length; i++)
            {
                Console.WriteLine(string.Format("For {0} please enter '{1}'", fixPropertyName(enumOptions[i]), i));
            }
        }
    }
}