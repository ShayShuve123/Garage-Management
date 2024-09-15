using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Types_of_vehicles
{
    public class Motorcycle : Vehicle
    {
        //data members//
        private eLicenseType m_LicenseType;
        private int m_EngineVolumeCC;

        public Motorcycle(string i_LicenseNumber, string i_ModelName, VehicleEngine i_Engine, eLicenseType licenseType, int engineVolumeCC) : base(i_LicenseNumber, i_ModelName, i_Engine)
        {
            m_LicenseType = licenseType;
            m_EngineVolumeCC = engineVolumeCC;
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

        public int EngineVolumeCC
        {
            get
            {
                return m_EngineVolumeCC;
            }
            set
            {
                m_EngineVolumeCC = value;
            }
        }

        public override string ToString()
        {
            StringBuilder motorcycleDetails = new StringBuilder();
            motorcycleDetails.AppendLine(base.ToString()); // Inherited properties from Vehicle
            motorcycleDetails.AppendLine($"License Type: {m_LicenseType}");
            motorcycleDetails.AppendLine($"Engine Volume (CC): {m_EngineVolumeCC}");
            return motorcycleDetails.ToString();
        }

    }
}
