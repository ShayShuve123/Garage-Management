using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelEngine : VehicleEngine
    {
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

        public override void FillEnergySource(float i_FuelToAdd, object i_IsFuelType = null)
        {
            float currentFuelInLiters = (this.RemainingEnergyPercent * this.EnergySourceMaxCapacity) / 100;
            float fuelToAddConvertedToPercent = (i_FuelToAdd * 100) / this.EnergySourceMaxCapacity;

            if (i_IsFuelType == null)
            {
                throw new ArgumentNullException(nameof(i_IsFuelType), "Missing fuel type information.\n");
            }

            if (i_IsFuelType is eFuelType fuelType)
            {
                if (this.m_FuelType != fuelType)
                {
                    throw new ArgumentException($"Fuel type mismatch. Expected {this.m_FuelType}, but got {fuelType}.\n");
                }

                if (this.RemainingEnergyPercent + fuelToAddConvertedToPercent <= 100)
                {
                    this.RemainingEnergyPercent += fuelToAddConvertedToPercent;
                }
                else
                {
                    float maxFuelPossibleToAddInLiters = this.EnergySourceMaxCapacity - currentFuelInLiters;
                    throw new ValueOutOfRangeException(0, maxFuelPossibleToAddInLiters, "Cannot refuel beyond max tank capacity.\n");
                }
            }
            else
            {
                throw new ArgumentException("Invalid fuel type provided.\n");
            }

        }

        public override string ToString()
        {
            StringBuilder engineDetails = new StringBuilder();

            engineDetails.Append($"Engine Type\n:Fuel");
            engineDetails.AppendLine($"Fuel Type:{m_FuelType}");
            engineDetails.AppendLine($"Remaining Fuel in the Tank: {this.RemainingEnergyPercent}% (in liter)");
            engineDetails.Append($" Max Tank Capacity: {this.EnergySourceMaxCapacity} (in liter)");

            return engineDetails.ToString();

        }
    }
}





