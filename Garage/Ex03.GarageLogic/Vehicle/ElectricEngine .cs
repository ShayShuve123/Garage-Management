using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : VehicleEngine
    {
        public ElectricEngine(float i_RemainingBatteryPercentage, float i_MaxBatteryCapacity)
                   : base(i_RemainingBatteryPercentage, i_MaxBatteryCapacity)
        {
        }

        public override void FillEnergySource(float i_HoursToAdd, object i_IsFuelType = null)
        {
            float hourslToAddConvertedToPercent = (i_HoursToAdd * 100) / this.EnergySourceMaxCapacity;
            float currentAvailableHours = (this.RemainingEnergyPercent * this.EnergySourceMaxCapacity) / 100;

            if (this.RemainingEnergyPercent + hourslToAddConvertedToPercent <= 100)
            {
                this.RemainingEnergyPercent += hourslToAddConvertedToPercent;
            }
            else
            {
                float maxPossibleHoursToAdd = this.EnergySourceMaxCapacity - currentAvailableHours;
                throw new ValueOutOfRangeException(0, maxPossibleHoursToAdd, "Cannot refuel beyond max tank capacity.");
            }
        }

        public override string ToString()
        {
            StringBuilder engineDetails = new StringBuilder();
            engineDetails.Append($"Engine Type : Electric");
            engineDetails.AppendLine($"Remaining Battery Percentage: {this.RemainingEnergyPercent}%");
            engineDetails.AppendLine($"Remaining Battery in Hours: {(this.RemainingEnergyPercent * this.EnergySourceMaxCapacity) / 100} hours");
            engineDetails.Append($"Max Battery Capacity: {this.EnergySourceMaxCapacity} hours");

            return engineDetails.ToString();

        }
    }
}
