using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Types_of_vehicles
{
    public class Truck : Vehicle                   
    {
        private bool m_IsCarryingHazardousMaterials;//maybe to chanch to v_
        private float m_CargoVolume;
        public Truck(string i_LicenseNumber, string i_ModelName, VehicleEngine i_Engine, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
            : base(i_LicenseNumber, i_ModelName, i_Engine)
        {
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            m_CargoVolume = i_CargoVolume;
        }

        // מאפיינים (Getters & Setters)
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
                m_CargoVolume = value;
            }
        }

        // פונקציית ToString להדפסת כל המידע הרלוונטי על המשאית
        public override string ToString()
        {
            StringBuilder truckDetails = new StringBuilder();
            truckDetails.AppendLine(base.ToString()); // ירושה מ-Vehicle
            truckDetails.AppendLine($"Carrying Hazardous Materials: {(m_IsCarryingHazardousMaterials ? "Yes" : "No")}");
            truckDetails.AppendLine($"Cargo Volume: {m_CargoVolume} cubic meters");
            return truckDetails.ToString();
        }

    }
}
