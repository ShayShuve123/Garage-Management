using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, CustomerVehicle> m_CustomersVehicles =
                        new Dictionary<string, CustomerVehicle>();
        bool isNotAlreadyInTheGarage = true;


        public Dictionary<string, CustomerVehicle> CustomerVehicles
        {
            get
            {
                return this.m_CustomersVehicles;
            }

            set
            {
                this.m_CustomersVehicles = value;
            }
        }

        public bool ShowFullVehicleDetails(string i_LicenseNumber)
        {
            isNotAlreadyInTheGarage = true;

            if (!m_CustomersVehicles.ContainsKey(i_LicenseNumber))
            {
                isNotAlreadyInTheGarage = false;
            }

            CustomerVehicle customerVehicle = m_CustomersVehicles[i_LicenseNumber];

            Console.WriteLine(customerVehicle.ToString());

            return isNotAlreadyInTheGarage;
        }

        public bool chargeBattery(string i_LicenseNumber, float i_HoursToCharge)
        {
            isNotAlreadyInTheGarage = true;

            if (!m_CustomersVehicles.ContainsKey(i_LicenseNumber))
            {
                isNotAlreadyInTheGarage = false;
            }

            CustomerVehicle customerVehicle = m_CustomersVehicles[i_LicenseNumber];

            if (customerVehicle.Vehicle.Engine is ElectricEngine electricEngine)
            {
                electricEngine.FillEnergySource(i_HoursToCharge);
            }
            else
            {
                throw new ArgumentException("The vehicle does not have an electric engine and cannot be charged.");
            }

            return isNotAlreadyInTheGarage;
        }

        public bool refuelVehicle(string i_LicenseNumber, float i_FuelToAdd, eFuelType i_FuelType)
        {
            isNotAlreadyInTheGarage = true;

            if (!m_CustomersVehicles.ContainsKey(i_LicenseNumber))
            {
                isNotAlreadyInTheGarage = false;
            }

            CustomerVehicle customerVehicle = m_CustomersVehicles[i_LicenseNumber];

            if (customerVehicle.Vehicle.Engine is FuelEngine fuelEngine)
            {
                fuelEngine.FillEnergySource(i_FuelToAdd, i_FuelType);
            }
            else
            {
                throw new ArgumentException("The vehicle does not have a fuel engine and cannot be refuled.");
            }

            return isNotAlreadyInTheGarage;
        }

        public bool ChangeVehicleStatus(string i_LicenseNumber, Enums.eVehicleStatus eVehicleStatus)
        {
            bool isNotAlreadyInTheGarage = true;

            if (!m_CustomersVehicles.ContainsKey(i_LicenseNumber))
            {
                isNotAlreadyInTheGarage = false;
            }

            m_CustomersVehicles[i_LicenseNumber].VehicleStatus = eVehicleStatus;

            return isNotAlreadyInTheGarage;
        }

        public void AddVehicle(
                        string i_CustomerName, string i_CustomerPhone,
                        string i_LicenseNumber,
                        Enums.eLicenseType i_LicenseType,
                        Enums.eVehicleType i_VehicleType,
                        string i_ModelName,
                        float i_LeftEnergy,
                        string i_WheelsManufactorerName,
                        float i_AirInWheels,
                        Enums.eVehicleColor i_Color,
                        Enums.eNumberOfDoors i_NumDoors,
                        float i_TruckCargoVolume,
                        bool i_IsTransportingDangerousLoads)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            Vehicle vehicle = vehicleFactory.CreateNewVehicle(
                        i_LicenseNumber, i_VehicleType, i_LicenseType,
                        i_ModelName, i_LeftEnergy,
                        i_WheelsManufactorerName, i_AirInWheels, i_Color,
                        i_NumDoors,
                        i_TruckCargoVolume,
                        i_IsTransportingDangerousLoads);

            CustomerVehicle customerVehicle = new CustomerVehicle(i_CustomerName, i_CustomerPhone);
            customerVehicle.Vehicle = vehicle;
            customerVehicle.VehicleStatus = eVehicleStatus.InRepair;
            m_CustomersVehicles[i_LicenseNumber] = customerVehicle;
        }

        public bool InflateAllTiresToMax(string i_LicenseNumber)
        {
            isNotAlreadyInTheGarage = true;

            if (!m_CustomersVehicles.ContainsKey(i_LicenseNumber))
            {
                isNotAlreadyInTheGarage = false;
            }

            foreach (Wheel wheel in this.m_CustomersVehicles[i_LicenseNumber].Vehicle.Wheels)
            {
                wheel.InflateWheel(wheel.MaxAirPressureByManufacturer - wheel.CurrentAirPressure);
            }

            return isNotAlreadyInTheGarage;
        }

    }

}

