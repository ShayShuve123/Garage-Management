using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelEngine : VehicleEngine  //  m_EnergySourceRemainingPercentage;// r_EnergySourceMaxCapacity;
    {
        //data members//
        private eFuelType m_FuelType;

        public FuelEngine(float i_FuelTankRemainingPercentage, float i_TankMaxCapacity, eFuelType i_FuelType) : base(i_FuelTankRemainingPercentage, i_TankMaxCapacity)
        {
            this.m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }

        public override void FillEnergySource(float i_FuelToAdd, object i_IsFuelType = null)//clint input in litrs and we need to add presntge!!!!!!!!!!
        {
            float currentFuelInLiters = (this.RemainingEnergyPercent * this.EnergySourceMaxCapacity) / 100;
            float fuelToAddConvertedToPercent = (i_FuelToAdd * 100) / this.EnergySourceMaxCapacity;

            if (i_IsFuelType == null)
            {
                throw new ArgumentNullException(nameof(i_IsFuelType), "Missing fuel type information.");
            }
            // בדיקת אם i_IsFuelType הוא מסוג eFuelType

            if (i_IsFuelType is eFuelType fuelType) 
            {
                // בדיקת אם סוג הדלק תואם לסוג הדלק של המנוע
                if (this.m_FuelType != fuelType)
                {
                    // זרוק חריגת חוסר התאמה של סוג דלק
                    throw new ArgumentException($"Fuel type mismatch. Expected {this.m_FuelType}, but got {fuelType}.");
                }

                if (this.RemainingEnergyPercent + fuelToAddConvertedToPercent <= 100) //if under the cpacity we will add fule 
                {
                    this.RemainingEnergyPercent += fuelToAddConvertedToPercent;//// במידה והכל תקין, הוסף את כמות הדלק
                }
                else
                {
                    float maxFuelPossibleToAddInLiters = this.EnergySourceMaxCapacity - currentFuelInLiters;
                    throw new ValueOutOfRangeException(0, maxFuelPossibleToAddInLiters, "Cannot refuel beyond max tank capacity.");
                }
            }
            else
            {
                // זרוק חריגת סוג דלק לא תקין
                throw new ArgumentException("Invalid fuel type provided.");
            }
            //all the catch`s probbly need to be in the UI 



        }
 
        // Override ToString for FuelEngine
        public override string ToString()
        {
            StringBuilder engineDetails = new StringBuilder();
            engineDetails.Append($"Engine Type :Fuel");
            engineDetails.AppendLine($"Fuel Type: {m_FuelType}");
            engineDetails.AppendLine($"Remaining Fuel in the Tank: {this.RemainingEnergyPercent}% (in liter)");
            engineDetails.Append($" Max Tank Capacity: {this.EnergySourceMaxCapacity} (in liter)");

            return engineDetails.ToString();

        }
    }
}
    




