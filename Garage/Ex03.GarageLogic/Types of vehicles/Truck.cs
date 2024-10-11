using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Types_of_vehicles
{
    public class Truck : Vehicle
    {
        private bool m_IsCarryingHazardousMaterials;
        private float m_CargoVolume;

        public Truck(string i_LicenseNumber, string i_ModelName, VehicleEngine i_Engine,
                     bool i_IsCarryingHazardousMaterials, float i_CargoVolume, List<Wheel> i_Wheels)
                : base(i_LicenseNumber, i_ModelName, i_Engine, i_Wheels)
        {
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            m_CargoVolume = i_CargoVolume;
        }

        public bool IsCarryingHazardousMaterials
        {
            get
            {
                return m_IsCarryingHazardousMaterials;
            }
            set
            {
                m_IsCarryingHazardousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                if (value < 0)
                {
                    throw new ValueOutOfRangeException(0, float.MaxValue, "Cargo volume cannot be negative.");
                }

                m_CargoVolume = value;
            }
        }

        public override string ToString()
        {
            StringBuilder truckDetails = new StringBuilder();
            truckDetails.AppendLine(base.ToString());
            truckDetails.AppendLine($"Carrying Hazardous Materials: {(m_IsCarryingHazardousMaterials ? "Yes" : "No")}");
            truckDetails.AppendLine($"Cargo Volume: {m_CargoVolume} cubic meters");

            return truckDetails.ToString();
        }

    }
}
