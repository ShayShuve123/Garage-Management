using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Types_of_vehicles
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_LicenseNumber, string i_ModelName, VehicleEngine i_Engine,
                          eLicenseType licenseType, List<Wheel> i_Wheels)
                                : base(i_LicenseNumber, i_ModelName, i_Engine, i_Wheels)
        {
            m_LicenseType = licenseType;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public override string ToString()
        {
            StringBuilder motorcycleDetails = new StringBuilder();
            motorcycleDetails.AppendLine(base.ToString());
            motorcycleDetails.AppendLine($"License Type: {m_LicenseType}");

            return motorcycleDetails.ToString();
        }

    }
}
