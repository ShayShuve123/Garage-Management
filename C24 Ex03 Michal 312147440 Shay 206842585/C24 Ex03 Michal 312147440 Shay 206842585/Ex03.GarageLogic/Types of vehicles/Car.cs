using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Types_of_vehicles
{
    public class Car : Vehicle 
    {
        //data members//
        private eVehicleColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_LicenseNumber, string i_ModelName, VehicleEngine i_Engine, eVehicleColor i_Color, eNumberOfDoors i_NumberOfDoors) : base(i_LicenseNumber, i_ModelName, i_Engine)
        {
            this.m_Color = i_Color;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }


        //get & set - proprtis //
        public eVehicleColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        // Methods //
        public override string ToString()
        {
            // The full details of the car, including inherited properties from Vehicle
            StringBuilder carDetails = new StringBuilder();
            carDetails.AppendLine(base.ToString()); // Inherited properties from Vehicle
            carDetails.AppendLine($"Color: {m_Color}");
            carDetails.AppendLine($"Number of Doors: {m_NumberOfDoors}");
            return carDetails.ToString();
        }

    }
}
