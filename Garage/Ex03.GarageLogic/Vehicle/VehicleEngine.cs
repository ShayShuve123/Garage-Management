using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public abstract class VehicleEngine
    {
        private float m_EnergySourceRemainingPercentage;
        private readonly float r_EnergySourceMaxCapacity;

        public VehicleEngine(float i_EnergySourceRemainingPercentage, float i_EnergySourceMaxCapacity)
        {
            this.m_EnergySourceRemainingPercentage = i_EnergySourceRemainingPercentage;
            this.r_EnergySourceMaxCapacity = i_EnergySourceMaxCapacity;
        }

        public float RemainingEnergyPercent
        {
            get
            {
                return this.m_EnergySourceRemainingPercentage;
            }

            set
            {
                this.m_EnergySourceRemainingPercentage = value;
            }
        }

        public float EnergySourceMaxCapacity
        {
            get
            {
                return this.r_EnergySourceMaxCapacity;
            }
        }

        public abstract void FillEnergySource(float i_EnergySourceAmountToAdd,
                                              object i_IsFuelType = null);

        public override string ToString()
        {
            StringBuilder engineDetails = new StringBuilder();

            engineDetails.AppendLine("********** Engine Details **********");
            engineDetails.AppendLine($"Energy Source Remaining Percentage: {m_EnergySourceRemainingPercentage}");
            engineDetails.AppendLine($"Energy Source Max Capacity: {r_EnergySourceMaxCapacity}");
            engineDetails.AppendLine("************************************");

            return engineDetails.ToString();
        }
    }
}
