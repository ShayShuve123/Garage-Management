using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressureByManufacturer;

        public Wheel(string i_ManufacturerName, float i_MaxAirPressureByManufacturer,
                     float i_CurrentAirPressure)
        {
            this.m_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.r_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                this.m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                this.m_CurrentAirPressure = value;
            }

        }

        public float MaxAirPressureByManufacturer
        {
            get
            {
                return r_MaxAirPressureByManufacturer;
            }
        }

        public void InflateWheel(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd <= r_MaxAirPressureByManufacturer)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressureByManufacturer,"Cannot inflate beyond the maximum air pressure. The wheels are already fully inflated.");
            }
        }

        public override string ToString()
        {
            StringBuilder wheelDetails = new StringBuilder();

            wheelDetails.AppendLine($"Manufacturer: {m_ManufacturerName}");
            wheelDetails.AppendLine($"Current Air Pressure: {m_CurrentAirPressure}");
            wheelDetails.AppendLine($"Max Air Pressure: {r_MaxAirPressureByManufacturer}");

            return wheelDetails.ToString();
        }

    }
}
