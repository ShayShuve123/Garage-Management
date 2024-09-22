using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        protected List<Wheel> m_Wheels = new List<Wheel>();
        private VehicleEngine m_Engine;

        public Vehicle(string i_LicenseNumber, string i_ModelName, VehicleEngine i_Engine, List<Wheel> i_Wheels)
        {
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_ModelName = i_ModelName;
            this.m_Engine = i_Engine;
            this.m_Wheels = i_Wheels;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }

            set
            {
                this.m_Wheels = value;
            }
        }

        public VehicleEngine Engine
        {
            get
            {
                return this.m_Engine;
            }

            set
            {
                this.m_Engine = value;
            }
        }

        public override string ToString()
        {
            int wheelNumber = 1;
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendLine($"License Number: {m_LicenseNumber}");
            vehicleDetails.AppendLine($"Model Name: {m_ModelName}");
            vehicleDetails.AppendLine("******************* Engine Details *******************");
            vehicleDetails.AppendLine($"Engine: {m_Engine}");
            vehicleDetails.AppendLine("******************* Wheels Information *******************");
           
            foreach (Wheel wheel in m_Wheels)
            {
                vehicleDetails.AppendLine($"Wheel {wheelNumber}:");
                vehicleDetails.AppendLine(wheel.ToString());
                wheelNumber++;
            }

            vehicleDetails.AppendLine("****************************");

            return vehicleDetails.ToString();
        }
    }
}
