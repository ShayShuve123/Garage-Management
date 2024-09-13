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


        //constractor//
        public FuelEngine(eFuelType fuelType)
        {

        }

        //get & set -proprtis //

        //mathods//
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
    }
}




