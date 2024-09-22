using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Types_of_vehicles
{
    public class Car : Vehicle
    {
        private eVehicleColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_LicenseNumber, string i_ModelName, VehicleEngine i_Engine,
                    eVehicleColor i_Color, eNumberOfDoors i_NumberOfDoors, List<Wheel> i_Wheels) :
                            base(i_LicenseNumber, i_ModelName, i_Engine, i_Wheels)
        {
            this.m_Color = i_Color;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }
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

        public override string ToString()
        {
            StringBuilder carDetails = new StringBuilder();
            carDetails.AppendLine(base.ToString());
            carDetails.AppendLine($"Color: {m_Color}");
            carDetails.AppendLine($"Number of Doors: {m_NumberOfDoors}");

            return carDetails.ToString();
        }

    }
}
