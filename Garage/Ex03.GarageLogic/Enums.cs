using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Enums
    {
        public enum eVehicleType
        {
            FuelMotorcycle = 1,
            ElecricMotorcycle,
            FuelCar,
            ElectricCar,
            Truck
        }

        public enum eEngineType
        {
            Electric = 1,
            Fuel,
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three,
            Four,
            Five,
        }

        public enum eLicenseType
        {
            A1 = 1,
            A2,
            AB,
            B1,
        }

        public enum eVehicleColor
        {
            Blue = 1,
            White,
            Black,
            Red,
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired,
            Paid,
        }

        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98,
        }
    }
}
