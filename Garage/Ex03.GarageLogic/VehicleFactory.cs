using Ex03.GarageLogic.Types_of_vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public Vehicle CreateNewVehicle(string i_LicenseNumber,
                                        eVehicleType i_VehicleType,
                                        eLicenseType i_LicenseType,
                                        string i_ModelName,
                                        float i_LeftEnergy,
                                        string i_WheelsManufactorerName,
                                        float i_AirInWheels,
                                        eVehicleColor i_Color,
                                        eNumberOfDoors i_NumDoors,
                                        float i_TruckCargoVolume,
                                        bool i_IsTransportingDangerousLoads
                                        )
        {
            Vehicle vehicle = null;

            if (i_VehicleType == eVehicleType.FuelCar)
            {
                FuelEngine fuelEngine = new FuelEngine(i_LeftEnergy / 49f * 100f, 49, eFuelType.Octan95);
                List<Wheel> Wheels = new List<Wheel>();
                for (int i = 0; i < 5; i++)
                {
                    Wheels.Add(new Wheel(i_WheelsManufactorerName, 33f, i_AirInWheels));
                }
                vehicle = new Car(i_LicenseNumber, i_ModelName, fuelEngine, i_Color, i_NumDoors, Wheels);
            }

            else if (i_VehicleType == eVehicleType.ElectricCar)
            {
                ElectricEngine electricEngine = new ElectricEngine(i_LeftEnergy / 5f * 100f, 5);
                List<Wheel> Wheels = new List<Wheel>();
                for (int i = 0; i < 5; i++)
                {
                    Wheels.Add(new Wheel(i_WheelsManufactorerName, 33f, i_AirInWheels));
                }
                vehicle = new Car(i_LicenseNumber, i_ModelName, electricEngine, i_Color, i_NumDoors, Wheels);
            }

            else if (i_VehicleType == eVehicleType.FuelMotorcycle)
            {
                FuelEngine fuelEngine = new FuelEngine(i_LeftEnergy / 6f * 100f, 6f, eFuelType.Octan98);
                List<Wheel> Wheels = new List<Wheel>();
                for (int i = 0; i < 2; i++)
                {
                    Wheels.Add(new Wheel(i_WheelsManufactorerName, 33f, i_AirInWheels));
                }
                vehicle = new Motorcycle(i_LicenseNumber, i_ModelName, fuelEngine, i_LicenseType, Wheels);
            }

            else if (i_VehicleType == eVehicleType.ElecricMotorcycle)
            {
                ElectricEngine electricEngine = new ElectricEngine(i_LeftEnergy / 2.7f * 100f, 2.7f);
                List<Wheel> Wheels = new List<Wheel>();
                for (int i = 0; i < 2; i++)
                {
                    Wheels.Add(new Wheel(i_WheelsManufactorerName, 33f, i_AirInWheels));
                }
                vehicle = new Motorcycle(i_LicenseNumber, i_ModelName, electricEngine, i_LicenseType, Wheels);
            }

            else if (i_VehicleType == eVehicleType.Truck)
            {
                FuelEngine fuelEngine = new FuelEngine(i_LeftEnergy / 49f * 100f, 49f, eFuelType.Octan95);
                List<Wheel> Wheels = new List<Wheel>();
                for (int i = 0; i < 14; i++)
                {
                    Wheels.Add(new Wheel(i_WheelsManufactorerName, 33f, i_AirInWheels));
                }
                vehicle = new Truck(i_LicenseNumber, i_ModelName, fuelEngine,
                                   i_IsTransportingDangerousLoads, i_TruckCargoVolume, Wheels);
            }

            return vehicle;
        }
    }
}
