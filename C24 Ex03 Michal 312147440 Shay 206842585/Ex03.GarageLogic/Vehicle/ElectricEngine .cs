using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : VehicleEngine     //  m_EnergySourceRemainingPercentage;// r_EnergySourceMaxCapacity;
    {
        //NO data members

        //constractor//


        //get & set -proprtis //


        //mathods//
        public override void FillEnergySource(float i_HoursToAdd, object i_IsFuelType = null)
        {
            float hourslToAddConvertedToPercent = (i_HoursToAdd * 100) / this.EnergySourceMaxCapacity;
            float currentAvailableHours = (this.RemainingEnergyPercent * this.EnergySourceMaxCapacity) / 100;

            if (this.RemainingEnergyPercent + hourslToAddConvertedToPercent <= 100) //if under the cpacity we will add fule 
            {
                this.RemainingEnergyPercent += hourslToAddConvertedToPercent;
            }
            else
            {
                float maxPossibleHoursToAdd = this.EnergySourceMaxCapacity - currentAvailableHours;
                throw new ValueOutOfRangeException(0, maxPossibleHoursToAdd, "Cannot refuel beyond max tank capacity.");
            }
        }
    }
}
