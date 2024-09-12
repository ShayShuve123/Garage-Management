using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;        //לפנייייייייייי שמתחילים את הפרוייקט לבנות קלאס דיאגרם לא לוותר על השלב!!

namespace Ex03.GarageLogic  //fix the mathods  encpsolation -internal/public/protected/private
{
    public class Wheel
    {
        //data members//
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressureByManufacturer;


        //constractor//
        public Wheel(string i_ManufacturerName, float i_MaxAirPressureByManufacturer)
        {
            //add  validation to the ver we get from user
            this.m_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = 0;//maybe a defult val of 0
            this.r_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
        }


        //get & set -proprtis //
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
            //NO set if-InflateWheel control on the pressur with correc validation?
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

        //mathods//
        public void InflateWheel(float i_AirToAdd) //virtual or protected ? more alings   //private????
        {

            if (m_CurrentAirPressure + i_AirToAdd <= r_MaxAirPressureByManufacturer)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressureByManufacturer, "Cannot inflate beyond max air pressure.");

            }

        }


    }
}
