using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class CustomerVehicle
    {
        private string m_CustomerName;
        private string m_CustomerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public CustomerVehicle(string i_CustomerName, string i_CustomerPhoneNumber)
        {
            this.m_CustomerName = i_CustomerName;
            this.m_CustomerPhoneNumber = i_CustomerPhoneNumber;
            this.m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public string CustomerName
        {
            get
            {
                return m_CustomerName;
            }
            set
            {
                m_CustomerName = value;
            }
        }

        public string CustomerPhoneNumber
        {
            get
            {
                return m_CustomerPhoneNumber;
            }
            set
            {
                m_CustomerPhoneNumber = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            StringBuilder customerDetails = new StringBuilder();
            customerDetails.AppendLine($"Customer Name: {m_CustomerName}");
            customerDetails.AppendLine($"Phone Number: {m_CustomerPhoneNumber}");
            customerDetails.AppendLine($"Vehicle Status: {m_VehicleStatus}");
            customerDetails.AppendLine(m_Vehicle.ToString());

            return customerDetails.ToString();
        }

    }
}
