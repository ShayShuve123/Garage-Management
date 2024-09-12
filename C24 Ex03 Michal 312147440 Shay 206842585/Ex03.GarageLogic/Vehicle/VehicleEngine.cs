using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class VehicleEngine//the fule Engine electic Engine hnarint 
    {
       private float m_EnergySourceRemainingPercentage;
       private readonly float r_EnergySourceMaxCapacity;

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

        public abstract void FillEnergySource(float i_AmountToAdd);

    }
}
